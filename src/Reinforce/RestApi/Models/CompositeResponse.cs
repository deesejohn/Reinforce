using System;
using System.Collections.Generic;
using System.Text;

namespace Reinforce.RestApi.Models
{
    public class CompositeResponse
    {
        public IEnumerable<CompositeRequestItem> items { get; set; }
    }
}
