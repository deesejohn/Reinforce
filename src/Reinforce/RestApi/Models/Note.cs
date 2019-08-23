using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class Note
    {
        public string Description { get; set; }
        public IEnumerable<string> Fields { get; set; }
        public string TableEnumOrId { get; set; }
    }
}