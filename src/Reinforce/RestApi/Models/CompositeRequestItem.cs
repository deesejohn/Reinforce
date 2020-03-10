using System;
using System.Collections.Generic;
using System.Text;

namespace Reinforce.RestApi.Models
{
    public class CompositeRequestItem
    {
        public string method { get; set; }
        public string url { get; set; }
        public string referenceId { get; set; }
        public dynamic body { get; set; }
    }
}
