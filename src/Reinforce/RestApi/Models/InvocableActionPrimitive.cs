using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class InvocableActionPrimitive
    {
        public string ApexClass { get; set; }
        public int? ByteLength { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
        public int? MaxOccurs { get; set; }
        public string Name { get; set; }
        public IEnumerable<PicklistValue> PicklistValues { get; set; }
        public bool? Required { get; set; }
        public string SobjectType { get; set; }
        public string Type { get; set; }
    }
}