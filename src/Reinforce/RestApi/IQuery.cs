using System.Threading;
using System.Threading.Tasks;
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
        [Get("/services/data/v46.0/query")]
        [Header("Authorization", "Bearer")]
        Task<ExplainResponse> GetAsync(
            [Query] string explain,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        [Get("/services/data/v46.0/query")]
        [Header("Authorization", "Bearer")]
        Task<QueryResponse<TSObject>> GetAsync<TSObject>(
            [Query] string q,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }
}