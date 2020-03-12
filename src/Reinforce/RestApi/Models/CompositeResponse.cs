using System.Collections.Generic;
using Newtonsoft.Json;

namespace Reinforce.RestApi.Models
{
    public class CompositeResponse<T>
    {
        [JsonProperty("compositeResponse")]
        public IEnumerable<CompositeResponseItem<T>> CompositeResponseItems { get; set; }
    }
}
