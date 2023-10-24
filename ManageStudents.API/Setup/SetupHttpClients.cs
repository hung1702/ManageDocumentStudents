using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ManageStudents.API.Abstraction;
//using ManageStudents.API.Application.Abstractions;
using ManageStudents.API.Application.Authorization;
//using ManageStudents.API.Application.Services;
using System.Net.Http;

namespace ManageStudents.API.Setup
{
    public static class SetupHttpClients
    {
        public static IServiceCollection ConfigureHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddHttpClient<IUsersService, UsersService>().ConfigureHttpClient(configuration);
            //services.AddHttpClient<ILocationServices, LocationsService>().ConfigureHttpClient(configuration);
            //services.AddHttpClient<IEventServices, EventServices>().ConfigureHttpClient(configuration);

            return services;
        }

        public static IHttpClientBuilder ConfigureDangerousAcceptAnyServerCertificateValidator(this IHttpClientBuilder builder, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("DangerousAcceptAnyServerCertificateValidator", false))
            {
                return builder.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                });
            }
            return builder;
        }

        private static IHttpClientBuilder ConfigureHttpClient(this IHttpClientBuilder httpClientBuilder, IConfiguration configuration)
        {
            return httpClientBuilder
                .ConfigureDangerousAcceptAnyServerCertificateValidator(configuration)
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
        }
    }
}