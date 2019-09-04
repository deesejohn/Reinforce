using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class Tab
    {
        public IEnumerable<ColorItem> Colors { get; set; }
        public bool? Custom { get; set; }
        public string IconUrl { get; set; }
        public IEnumerable<IconItem> Icons { get; set; }
        public string Label { get; set; }
        public string MiniIconUrl { get; set; }
        public string Name { get; set; }
        public string SobjectName { get; set; }
        public string Url { get; set; }
    }
}