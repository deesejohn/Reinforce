using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// QueryAll
    /// Executes the specified SOQL query. Unlike the Query resource, QueryAll will return records that
    /// have been deleted because of a merge or delete. QueryAll will also return information about
    /// archived Task and Event records.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_queryall.htm
    /// </summary>
    public interface IQueryAll
    {
        [Get("/services/data/{version}/queryAll")]
        [Header("Authorization", "Bearer")]
        Task<QueryResponse<TSObject>> GetAsync<TSObject>(
            [Query] string q,
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );
    }
}