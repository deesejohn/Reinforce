using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reinforce.BulkApi2.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperationEnum
    {
        None,
        [EnumMember(Value = "insert")] Insert,
        [EnumMember(Value = "delete")] Delete,
        [EnumMember(Value = "update")] Update,
        [EnumMember(Value = "upsert")] Upsert
    }
}