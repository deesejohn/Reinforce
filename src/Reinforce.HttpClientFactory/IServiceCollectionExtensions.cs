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
                    .AddTransient<AuthenticationHandler>()
                    .AddRestApis()
            );

        private static IHttpClientBuilder AddRestApis(this IServiceCollection services)
            => services
                .AddHttpClient(nameof(IReinforceBuilder))
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://login.salesforce.com"))
                .AddHttpMessageHandler<AuthenticationHandler>()
                .AddRestClient<IVersions>()
                .AddRestClient<IResourcesByVersion>()
                .AddRestClient<ILimits>()
                .AddRestClient<IDescribeGlobal>()
                .AddRestClient<ISObjectBasicInformation>()
                .AddRestClient<ISObjectDescribe>()
                .AddRestClient<ISObjectGetDeleted>()
                .AddRestClient<ISObjectGetUpdated>()
                .AddRestClient<ISObjectNamedLayouts>()
                .AddRestClient<ISObjectRows>()
                .AddRestClient<ISObjectRowsByExternalId>()
                .AddRestClient<ISObjectBlobRetrieve>()
                .AddRestClient<ISObjectApprovalLayouts>()
                .AddRestClient<ISObjectCompactLayouts>()
                .AddRestClient<IDescribeLayouts>()
                .AddRestClient<ISObjectPlatformAction>()
                .AddRestClient<ISObjectQuickActions>()
                .AddRestClient<IQuery>();

        private static IHttpClientBuilder AddRestClient<TApi>(this IHttpClientBuilder builder) where TApi : class
            => builder.AddTypedClient(client => new RestClient(client).For<TApi>());
    }
}
