using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Composite
    {
        public bool AllOrNone { get; set; }
        public bool CollateSubrequests { get; set; }
        public IEnumerable<CompositeRequestItem> CompositeRequest { get; set; }
    }
}
