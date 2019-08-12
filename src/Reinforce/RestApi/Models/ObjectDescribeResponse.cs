using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class ObjectDescribeResponse
    {
        public SObject ObjectDescribe { get; set; }
        public IEnumerable<dynamic> RecentItems { get; set; }
    }
}