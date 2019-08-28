using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class ListViewsResponse
    {
        public bool? Done { get; set; }
        public IEnumerable<ListView> ListViews { get; set; }
        public string NextRecordsUrl { get; set; }
        public int? Size { get; set; }
        public string SobjectType { get; set; }
    }
}