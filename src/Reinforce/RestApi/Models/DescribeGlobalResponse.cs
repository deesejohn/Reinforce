using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class DescribeGlobalResponse
    {
        public string Encoding { get; set; }
        public int? MaxBatchSize { get; set; }
        public IEnumerable<SObject> SObjects { get; set; }
    }
}