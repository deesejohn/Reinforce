using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class QuickAction
    {
        public string ActionEnumOrId { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IDictionary<string, string> Urls { get; set; }
    }
}