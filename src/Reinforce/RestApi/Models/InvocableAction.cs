using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class InvocableAction
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public IEnumerable<InvocableActionPrimitive> Inputs { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public IEnumerable<InvocableActionPrimitive> Outputs { get; set; }
        public bool? Standard { get; set; }
        public string TargetEntityName { get; set; }
        public string Type { get; set; }
    }
}