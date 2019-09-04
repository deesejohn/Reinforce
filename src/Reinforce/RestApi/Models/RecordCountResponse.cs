using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class RecordCountResponse
    {
        public IEnumerable<RecordCount> Sobjects { get; set; }
    }
}