using System;
using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class SObjectGetUpdatedResponse
    {
        public IEnumerable<string> Ids { get; set; }
        public DateTimeOffset? LatestDateCovered { get; set; }
    }
}