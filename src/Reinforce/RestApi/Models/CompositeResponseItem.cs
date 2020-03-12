using System;
using System.Collections.Generic;
using System.Text;

namespace Reinforce.RestApi.Models
{
    public class CompositeResponseItem
    {
        public dynamic body { get; set; }
        public IDictionary<string, string> httpHeaders { get; set; }
        public int httpStatusCode { get; set; }
        public string referenceId { get; set; }
    }
}
