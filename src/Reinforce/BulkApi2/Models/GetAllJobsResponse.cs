using System.Collections.Generic;

namespace Reinforce.BulkApi2.Models
{
    public class GetAllJobsResponse
    {
        public bool? Done { get; set; }
        public IEnumerable<JobInfo> Records { get; set; }
        public string NextRecordsUrl { get; set; }
    }
}