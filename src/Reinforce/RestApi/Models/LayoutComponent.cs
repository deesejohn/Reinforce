using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class LayoutComponent
    {
        public IEnumerable<dynamic> Components { get; set; }
        public Details Details { get; set; }
        public int? DisplayLines { get; set; }
        public int? TabOrder { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}