using System;
using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class SObjectGetDeleted
    {
        public IEnumerable<DeletedRecord> DeletedRecords { get; set; }
        public DateTimeOffset? EarliestDateAvailable { get; set; }
        public DateTimeOffset? LatestDateCovered { get; set; }
    }
}