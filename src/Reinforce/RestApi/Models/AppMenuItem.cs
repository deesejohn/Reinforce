using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class AppMenuItem
    {
        public IEnumerable<ColorItem> Colors { get; set; }
        public dynamic Content { get; set; }
        public IEnumerable<IconItem> Icons { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
    }
}