using System;
using Microsoft.Extensions.DependencyInjection;
using Reinforce.ApexRest;
using Reinforce.HttpClientFactory.Authentication;
using Reinforce.RestApi;
using RestEase;

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
                .AddRestClient<IApexRest>()
                .AddRestClient<IAppMenu>()
                .AddRestClient<IDescribeGlobal>()
                .AddRestClient<IDescribeLayouts>()
                .AddRestClient<IInvocableActions>()
                .AddRestClient<ILimits>()
                .AddRestClient<IListViewResults>()
                .AddRestClient<IListViews>()
                .AddRestClient<IPlatformEventSchemaByEventName>()
                .AddRestClient<IPlatformEventSchemaBySchemaID>()
                .AddRestClient<IQuery>()
                .AddRestClient<IQueryAll>()
                .AddRestClient<IQuickActions>()
                .AddRestClient<IRecentListViews>()
                .AddRestClient<IRecentlyViewedItems>()
                .AddRestClient<IRecordCount>()
                .AddRestClient<IResourcesByVersion>()
                .AddRestClient<ISObjectApprovalLayouts>()
                .AddRestClient<ISObjectBasicInformation>()
                .AddRestClient<ISObjectBlobRetrieve>()
                .AddRestClient<ISObjectCompactLayouts>()
                .AddRestClient<ISObjectDescribe>()
                .AddRestClient<ISObjectGetDeleted>()
                .AddRestClient<ISObjectGetUpdated>()
                .AddRestClient<ISObjectNamedLayouts>()
                .AddRestClient<ISObjectPlatformAction>()
                .AddRestClient<ISObjectQuickActions>()
                .AddRestClient<ISObjectRelationships>()
                .AddRestClient<ISObjectRichTextImageRetrieve>()
                .AddRestClient<ISObjectRows>()
                .AddRestClient<ISObjectRowsByExternalId>()
                .AddRestClient<ITabs>()
                .AddRestClient<ITheme>()
                .AddRestClient<IVersions>();

        private static IHttpClientBuilder AddRestClient<TApi>(this IHttpClientBuilder builder)
            where TApi : class
            => builder.AddTypedClient(client => new RestClient(client).For<TApi>());
    }
}
