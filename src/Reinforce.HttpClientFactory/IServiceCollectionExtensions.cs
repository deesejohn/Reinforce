using System;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using Reinforce.Authentication.Flows;
using Reinforce.HttpClientFactory.Authentication;
using Reinforce.RestApi;

namespace Reinforce.HttpClientFactory
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddReinforce(this IServiceCollection services, UsernamePasswordSettings settings, Uri authenticationUri = null)
        {
            services.AddAuthentication(authenticationUri);
            services.AddMemoryCache();
            services.AddRestApis();
            services.AddSingleton(_ => settings);
            services.AddTransient<IAuthenticationProvider, UsernamePassword>();
            return services;
        }
        private static IHttpClientBuilder AddAuthentication(this IServiceCollection services, Uri authenticationUri)
            => services
                .AddTransient<AuthenticationHandler>()
                .AddRefitClient<IUsernamePasswordOauth>(new RefitSettings
                {
                    ContentSerializer = new JsonContentSerializer(new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = new SnakeCaseNamingStrategy()
                        }
                    })
                })
                .ConfigureHttpClient(c => c.BaseAddress = authenticationUri ?? new Uri("https://login.salesforce.com"));

        private static IHttpClientBuilder AddAuthenticatedApi<TApi>(this IServiceCollection services) where TApi : class
            => services
                .AddRefitClient<TApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://login.salesforce.com"))
                .AddHttpMessageHandler<AuthenticationHandler>();

        private static IServiceCollection AddRestApis(this IServiceCollection services)
        {
            services.AddAuthenticatedApi<IVersions>();
            services.AddAuthenticatedApi<IResourcesByVersion>();
            services.AddAuthenticatedApi<ILimits>();
            services.AddAuthenticatedApi<IDescribeGlobal>();
            services.AddAuthenticatedApi<ISObjectBasicInformation>();
            services.AddAuthenticatedApi<ISObjectDescribe>();
            services.AddAuthenticatedApi<ISObjectGetDeleted>();
            services.AddAuthenticatedApi<ISObjectGetUpdated>();
            services.AddAuthenticatedApi<ISObjectNamedLayouts>();
            services.AddAuthenticatedApi<ISObjectRows>();
            services.AddAuthenticatedApi<ISObjectRowsByExternalId>();
            services.AddAuthenticatedApi<ISObjectBlobRetrieve>();
            services.AddAuthenticatedApi<ISObjectApprovalLayouts>();
            services.AddAuthenticatedApi<ISObjectCompactLayouts>();
            services.AddAuthenticatedApi<IDescribeLayouts>();

            services.AddAuthenticatedApi<IQuery>();
            return services;
        }
                
    }
}
