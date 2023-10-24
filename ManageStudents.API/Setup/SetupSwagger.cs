using ManageStudents.API.Filters;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System;

namespace ManageStudents.API.Setup
{
    public static class SetupSwagger
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration config)
        {
            var buildVersion = typeof(Program).Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>();
            _ = services.AddSwaggerGen(opts =>
            {
                opts.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ManageStudents API",
                    Description = "ManageStudents API" +
                    $"<p><strong>Build:</strong>{buildVersion?.Version}</p>"
                });

                opts.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri($"{config.GetValue<string>("IdentityUrl")}/connect/authorize"),
                            TokenUrl = new Uri($"{config.GetValue<string>("IdentityUrl")}/connect/token"),
                            //Scopes = new Dictionary<string, string>()
                            //{
                            //   { "IdentityServerApi", "Identity API - full access" },
                            //   { "srp", "Self Reporting API - full access" },
                            //   { "lts", "Locations API - full access" },
                            //   { "ets2", "Events.V2 API - full access" }
                            //}
                        }
                    }
                });

                opts.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            return services;
        }

        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "ManageStudents.API");
                c.OAuthClientId("ManageStudentsswaggerui");
                c.OAuthAppName("ManageStudents Swagger UI");
            });

            return app;
        }
    }
}