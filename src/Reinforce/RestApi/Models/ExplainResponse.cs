using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class ExplainResponse
    {
        public IEnumerable<Plan> Plans { get; set; }
        public string SourceQuery { get; set; }
    }
}