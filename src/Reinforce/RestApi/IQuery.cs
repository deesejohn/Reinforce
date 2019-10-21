using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Query
    /// Executes the specified SOQL query.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_query.htm#resources_query
    /// </summary>
    public interface IQuery
    {
        [Get("/services/data/{version}/query")]
        [Header("Authorization", "Bearer")]
        Task<ExplainResponse> GetAsync(
            [Query] string explain,
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );

        [Get("/services/data/{version}/query")]
        [Header("Authorization", "Bearer")]
        Task<QueryResponse<TSObject>> GetAsync<TSObject>(
            [Query] string q,
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );
    }
}