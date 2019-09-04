using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class LayoutAction
    {
        public bool? Custom { get; set; }
        public IEnumerable<IconItem> Icons { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
    }
}