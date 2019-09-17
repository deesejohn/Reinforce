using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class SearchResponse<T>
    {
        public IEnumerable<T> SearchRecords { get; set; }
    }
}