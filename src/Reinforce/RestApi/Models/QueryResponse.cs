using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    
    public class QueryResponse<TSObject>
    {
        public bool? Done { get; set; }
        public string NextRecordsUrl { get; set; }
        public IEnumerable<TSObject> Records { get; set; }
        public int? TotalSize { get; set; }
    }
}