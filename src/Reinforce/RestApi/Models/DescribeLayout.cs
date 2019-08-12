using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class DescribeLayout
    {
        public string Label { get; set; }
        public int? LimitRows { get; set; }
        public string Name { get; set; }
        public IEnumerable<SearchColumn> SearchColumns { get; set; }
    }
}