using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Describe Global
    /// Lists the available objects and their metadata for your organization’s data. In addition, it provides
    /// the organization encoding, as well as the maximum batch size permitted in queries.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_describeGlobal.htm
    /// </summary>
    public interface IDescribeGlobal
    {
        [Get("/services/data/v46.0/sobjects")]
        [Headers("Authorization: Bearer")]
        Task<DescribeGlobalResponse> GetAsync(CancellationToken cancellationToken);
    }

    public class DescribeGlobalResponse
    {
        public string Encoding { get; set; }
        public int? MaxBatchSize { get; set; }
        public IEnumerable<SObject> SObjects { get; set; }
    }
}