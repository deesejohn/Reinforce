using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Reinforce.BulkApi2.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class CloseOrAbortAJobRequest
    {
        public CloseOrAbortAJobRequest(JobStateEnum? state)
        {
            State = state ?? throw new ArgumentNullException(nameof(state));
        }

        public JobStateEnum? State { get; set; }
    }
}