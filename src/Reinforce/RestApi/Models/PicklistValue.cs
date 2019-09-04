namespace Reinforce.RestApi.Models
{
    public class PicklistValue
    {
        public bool? Active { get; set; }
        public bool? DefaultValue { get; set; }
        public string Label { get; set; }
        public string ValidFor { get; set; }
        public string Value { get; set; }
    }
}