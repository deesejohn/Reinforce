using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class FieldItem
    {
        public bool? Editable { get; set; }
        public string Label { get; set; }
        public IEnumerable<LayoutComponent> LayoutComponents { get; set; }
        public bool? Placeholder { get; set; }
        public bool? Required { get; set; }
    }
}