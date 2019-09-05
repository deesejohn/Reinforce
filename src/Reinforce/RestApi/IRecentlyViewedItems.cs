using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.RestApi.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Recently Viewed Items
    /// Gets the most recently accessed items that were viewed or referenced by the current user.
    /// Salesforce stores information about record views in the interface and uses it to generate a list of
    /// recently viewed and referenced records, such as in the sidebar and for the auto-complete options in
    /// search. 
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_recent_items.htm
    /// </summary>
    public interface IRecentlyViewedItems
    {
        [Get("/services/data/{version}/recent")]
        [Header("Authorization", "Bearer")]
        Task<IEnumerable<RecentlyViewedItem>> GetAsync(
            [Query] int? limit = null,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}