using System.Collections.Generic;

namespace Reinforce.RestApi
{
    public class SObject
    {
        public bool? Activateable { get; set; }
        public bool? Custom { get; set; }
        public bool? CustomSetting { get; set; }
        public bool? Createable { get; set; }
        public bool? Deletable { get; set; }
        public bool? DeprecatedAndHidden { get; set; }
        public bool? FeedEnabled { get; set; }
        public string KeyPrefix { get; set; }
        public string Label { get; set; }
        public string LabelPlural { get; set; }
        public bool? Layoutable { get; set; }
        public bool? Mergeable { get; set; }
        public bool? MruEnabled { get; set; }
        public string Name { get; set; }
        public bool? Queryable { get; set; }
        public bool? Replicateable { get; set; }
        public bool? Retrieveable { get; set; }
        public bool? Searchable { get; set; }
        public bool? Triggerable { get; set; }
        public bool? Undeletable { get; set; }
        public bool? Updateable { get; set; }
        public IDictionary<string, string> Urls { get; set; }
    }
}