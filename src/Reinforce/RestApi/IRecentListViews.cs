using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Recent List Views
    /// Returns the list of recently used list views for the given sObject type.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_recentlistviews.htm
    /// </summary>
    public interface IRecentListViews
    {
        [Get("/services/data/{version}/sobjects/{sobjectType}/listviews/recent")]
        [Header("Authorization", "Bearer")]
        Task<ListViewsResponse> GetAsync(
            [Path] string sobjectType,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}