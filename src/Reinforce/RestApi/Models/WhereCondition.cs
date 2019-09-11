using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class WhereCondition
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public IEnumerable<string> Values { get; set; }
    }
}