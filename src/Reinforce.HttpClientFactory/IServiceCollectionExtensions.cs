using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Reinforce.ApexRest;
using Reinforce.BulkApi2;
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
                .AddApexRest()
                .AddBulkApi2()
                .AddRestApi()
                .AddHttpClient(nameof(IReinforceBuilder))
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://login.salesforce.com"))
                .AddHttpMessageHandler<AuthenticationHandler>();

        private static IServiceCollection AddApexRest(this IServiceCollection services)
            => services
                .AddRestClient<IApexRest>();

        private static IServiceCollection AddBulkApi2(this IServiceCollection services)
            => services
                .AddRestClient<ICloseOrAbortAJob>()
                .AddRestClient<ICreateAJob>()
                .AddRestClient<IDeleteAJob>()
                .AddRestClient<IGetAllJobs>()
                .AddRestClient<IGetJobFailedRecordResults>()
                .AddRestClient<IGetJobInfo>()
                .AddRestClient<IGetJobSuccessfulRecordResults>()
                .AddRestClient<IGetJobUnprocessedRecordResults>()
                .AddRestClient<IUploadJobData>();

        private static IServiceCollection AddRestApi(this IServiceCollection services)
            => services
                .AddRestClient<IAppMenu>()
                .AddRestClient<IDescribeGlobal>()
                .AddRestClient<IDescribeLayouts>()
                .AddRestClient<IInvocableActions>()
                .AddRestClient<ILimits>()
                .AddRestClient<IListViewDescribe>()
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
                .AddRestClient<ISearch>()
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
                .AddRestClient<IVersions>()
                .AddRestClient<IComposite>();

        private static IServiceCollection AddRestClient<TApi>(this IServiceCollection services)
            where TApi : class
            => services.AddTransient(provider => new RestClient(
                provider.GetRequiredService<IHttpClientFactory>().CreateClient(nameof(IReinforceBuilder))
            ).For<TApi>());
    }
}
