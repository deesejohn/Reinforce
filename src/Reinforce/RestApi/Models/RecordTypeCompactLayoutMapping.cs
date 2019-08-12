using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class RecordTypeCompactLayoutMapping
    {
        public bool? Available { get; set; }
        public string CompactLayoutId { get; set; }
        public string CompactLayoutName { get; set; }
        public string RecordTypeId { get; set; }
        public string RecordTypeName { get; set; }
        public IDictionary<string, string> Urls { get; set; }
    }
}