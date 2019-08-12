using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class ApprovalLayout
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public IEnumerable<dynamic> LayoutItems { get; set; }

        public string Name { get; set; }
    }
}