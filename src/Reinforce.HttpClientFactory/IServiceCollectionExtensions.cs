using System;
using Microsoft.Extensions.DependencyInjection;
using RestEase;
using Reinforce.HttpClientFactory.Authentication;
using Reinforce.RestApi;

namespace Reinforce.HttpClientFactory
{
    public static class IServiceCollectionExtensions
    {
        public static IReinforceBuilder AddReinforce(this IServiceCollection services)
            => new ReinforceBuilder(
                services
                    .AddRestApis()
                    .AddTransient<AuthenticationHandler>()
            );

        private static IServiceCollection AddAuthenticatedApi<TApi>(this IServiceCollection services) where TApi : class
            => services
                .AddHttpClient(typeof(TApi).FullName)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://login.salesforce.com"))
                .AddHttpMessageHandler<AuthenticationHandler>()
                .AddTypedClient((client) => new RestClient(client).For<TApi>())
                .Services;

        private static IServiceCollection AddRestApis(this IServiceCollection services)
            => services
                .AddAuthenticatedApi<IVersions>()
                .AddAuthenticatedApi<IResourcesByVersion>()
                .AddAuthenticatedApi<ILimits>()
                .AddAuthenticatedApi<IDescribeGlobal>()
                .AddAuthenticatedApi<ISObjectBasicInformation>()
                .AddAuthenticatedApi<ISObjectDescribe>()
                .AddAuthenticatedApi<ISObjectGetDeleted>()
                .AddAuthenticatedApi<ISObjectGetUpdated>()
                .AddAuthenticatedApi<ISObjectNamedLayouts>()
                .AddAuthenticatedApi<ISObjectRows>()
                .AddAuthenticatedApi<ISObjectRowsByExternalId>()
                .AddAuthenticatedApi<ISObjectBlobRetrieve>()
                .AddAuthenticatedApi<ISObjectApprovalLayouts>()
                .AddAuthenticatedApi<ISObjectCompactLayouts>()
                .AddAuthenticatedApi<IDescribeLayouts>()
                .AddAuthenticatedApi<ISObjectPlatformAction>()
                .AddAuthenticatedApi<ISObjectQuickActions>()
                .AddAuthenticatedApi<IQuery>();
    }
}
