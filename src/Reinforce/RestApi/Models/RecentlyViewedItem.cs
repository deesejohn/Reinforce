using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class RecentlyViewedItem
    {
        public IDictionary<string, string> Attributes { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}