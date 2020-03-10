using System;
using System.Collections.Generic;
using System.Text;

namespace Reinforce.RestApi.Models
{
    public class CompositeRequest
    {
        public bool allOrNone { get; set; }
        public bool collateSubrequests { get; set; }
        public IEnumerable<CompositeRequestItem> compositeRequest { get; set; }
    }
}
