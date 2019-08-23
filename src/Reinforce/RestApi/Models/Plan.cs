using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class Plan
    {
        public int? Cardinality { get; set; }
        public IEnumerable<string> Fields { get; set; }
        public string LeadingOperationType { get; set; }
        public IEnumerable<Note> Notes { get; set; }
        public double? RelativeCost { get; set; }
        public int? SobjectCardinality { get; set; }
        public string SobjectType { get; set; }
    }
}