using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// List View Describe
    /// Returns detailed information about a list view, including the ID, the columns, and the SOQL query.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_listviewdescribe.htm
    /// </summary>
    public interface IListViewDescribe
    {
        [Get("/services/data/{version}/sobjects/{sobjectType}/listviews/{queryLocator}/describe")]
        [Header("Authorization", "Bearer")]
        Task<ListViewDescribeResponse> GetAsync(
            [Path] string sobjectType,
            [Path] string queryLocator,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}