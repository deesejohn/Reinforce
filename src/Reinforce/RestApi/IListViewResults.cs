using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// List View Results
    /// Executes the SOQL query for the list view and returns the resulting data and presentation information.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_listviewresults.htm
    /// </summary>
    public interface IListViewResults
    {
        [Get("/services/data/{version}/sobjects/{sobjectType}/listviews/{listViewID}/results")]
        [Header("Authorization", "Bearer")]
        Task<ListViewResultsResponse> GetAsync(
            [Path] string sobjectType,
            [Path] string listViewID,
            [Query] int? limit = null,
            [Query] int? offset = null,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}