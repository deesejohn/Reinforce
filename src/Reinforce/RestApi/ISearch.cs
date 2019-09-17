using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Search
    /// Executes the specified SOSL search. The search string must be URL-encoded.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_search.htm
    /// </summary>
    public interface ISearch
    {
        [Get("/services/data/{version}/search")]
        [Header("Authorization", "Bearer")]
        Task<SearchResponse<T>> GetAsync<T>(
            [Query] string q,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}