using System.Threading;
using System.Threading.Tasks;
using Reinforce.RestApi.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// List Views
    /// Returns the list of list views for the specified sObject, including the ID and other basic information 
    /// about each list view. You can also get basic information for a specific list view by ID.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_listviews.htm
    /// </summary>
    public interface IListViews
    {
        [Get("/services/data/{version}/sobjects/{sobjectType}/listviews")]
        [Header("Authorization", "Bearer")]
        Task<ListViewsResponse> GetAsync(
            [Path] string sobjectType,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Get("/services/data/{version}/sobjects/{sobjectType}/listviews/{listViewID}")]
        [Header("Authorization", "Bearer")]
        Task<ListView> GetAsync(
            [Path] string sobjectType,
            [Path] string listViewID,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}