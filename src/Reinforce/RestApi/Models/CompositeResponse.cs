using System.Collections.Generic;
using Newtonsoft.Json;

namespace Reinforce.RestApi.Models
{
    public class CompositeResponse
    {
        [JsonProperty("compositeResponse")]
        public IEnumerable<CompositeResponseItem> CompositeResponseItems { get; set; }
    }
}
