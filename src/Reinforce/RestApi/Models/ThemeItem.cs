using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class ThemeItem
    {
        public IEnumerable<ColorItem> Colors { get; set; }
        public IEnumerable<IconItem> Icons { get; set; }

        public string Name { get; set; }
    }
}