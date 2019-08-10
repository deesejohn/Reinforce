using System;
using Refit;

namespace Reinforce.RestApi
{
    public class DateRange
    {
        [AliasAs("start")]
        public DateTimeOffset? StartDateAndTime { get; set; }
        [AliasAs("end")] 
        public DateTimeOffset? EndDateAndTime { get; set; }
    }
}