using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Refit;

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
        [Headers("Authorization: Bearer")]
        Task<QueryResponse<TSObject>> GetAsync<TSObject>(string q, CancellationToken cancellationToken);
    }

    public class QueryResponse<TSObject>
    {
        public bool? Done { get; set; }
        public string NextRecordsUrl { get; set; }
        public IEnumerable<TSObject> Records { get; set; }
        public int? TotalSize { get; set; }
    }
}