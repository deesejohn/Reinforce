using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reinforce.BulkApi2.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConcurrencyModeEnum
    {
        None,
        Parallel
    }
}