using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class ListViewResultsResponse
    {
        public IEnumerable<ColumnDescription> Columns { get; set; }
        public string DeveloperName { get; set; }
        public bool? Done { get; set; }
        public string Id { get; set; }
        public string Label { get; set; }
        public IEnumerable<ListViewResult> Records { get; set; }
        public int? Size { get; set; }
    }
}