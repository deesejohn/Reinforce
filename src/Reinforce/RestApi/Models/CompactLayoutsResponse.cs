using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class CompactLayoutsResponse
    {
        public IEnumerable<CompactLayout> CompactLayouts { get; set; }
        public string DefaultCompactLayoutId { get; set; }
        public IEnumerable<RecordTypeCompactLayoutMapping> RecordTypeCompactLayoutMappings { get; set; }
        public IDictionary<string, string> Urls { get; set; }
    }
}