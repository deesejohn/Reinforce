using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class CompactLayout
    {
        public IEnumerable<Action> Actions { get; set; }
        public IEnumerable<FieldItem> FieldItems { get; set; }
        public string Id { get; set; }
        public IEnumerable<ImageItem> ImageItems { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
    }
}