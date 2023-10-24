using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Net.Http;

namespace ManageStudents.API.Setup
{
    public static class SetupSecurityAndAuthentication
    {
        public static IServiceCollection ConfigureSecurityAndAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
             .AddIdentityServerAuthentication(options =>
             {
                 options.Authority = configuration.GetSection("IdentityUrl").Value;
                 options.ApiName = "srp";
                 options.RoleClaimType = "role";
                 options.RequireHttpsMetadata = true;
                 options.ForwardDefaultSelector = context => SchemeSelector(context) ?? IdentityServerAuthenticationDefaults.AuthenticationScheme;

                 if (configuration.GetValue<bool>("DangerousAcceptAnyServerCertificateValidator", false))
                 {
                     options.JwtBackChannelHandler = new HttpClientHandler()
                     {
                         ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                     };
                 }
             })
            .AddOAuth2Introspection("introspection", options =>
            {
                options.Authority = configuration.GetSection("IdentityUrl").Value;
                options.ClientId = "srp";
                options.ClientSecret = "srp";
            });

            return services;
        }

        public static IApplicationBuilder ConfigureSecurityHeaders(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }
            else
            {
                app.UseHttpLogging();
            }

            app.UseHttpsRedirection();
            return app;
        }

        private static string? SchemeSelector(HttpContext context)
        {
            var (scheme, token) = GetSchemeAndCredential(context);

            if (!string.Equals(scheme, "Bearer", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            if (token.Contains('.'))
            {
                return IdentityServerAuthenticationDefaults.AuthenticationScheme;
            }
            else
            {
                return "introspection";
            }
        }

        private static (string, string) GetSchemeAndCredential(HttpContext context)
        {
            var header = context.Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(header))
            {
                return ("", "");
            }

            var parts = header.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                return ("", "");
            }

            return (parts[0], parts[1]);
        }
    }
}
