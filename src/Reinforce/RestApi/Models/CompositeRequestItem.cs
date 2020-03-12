using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Reinforce.RestApi.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class CompositeRequestItem
    {
        public string Method { get; set; }
        public string Url { get; set; }
        public string ReferenceId { get; set; }
        public dynamic Body { get; set; }
    }
}
