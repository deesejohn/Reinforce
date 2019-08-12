using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{  
    public class SObjectBasicInformationResponse
    {
        public SObject ObjectDescribe { get; set; }
        public IEnumerable<RecentItem> RecentItems { get; set; }
    }
}