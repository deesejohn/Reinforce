using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class Details
    {
        public bool? AutoNumber { get; set; }
        public int? ByteLength { get; set; }
        public bool? Calculated { get; set; }
        public dynamic CalculatedFormula { get; set; }
        public bool? CascadeDelete { get; set; }
        public bool? CaseSensitive { get; set; }
        public dynamic ControllerName { get; set; }
        public bool? Createable { get; set; }
        public bool? Custom { get; set; }
        public dynamic DefaultValue { get; set; }
        public dynamic DefaultValueFormula { get; set; }
        public bool? DefaultedOnCreate { get; set; }
        public bool? DependentPicklist { get; set; }
        public bool? DeprecatedAndHidden { get; set; }
        public int? Digits { get; set; }
        public bool? DisplayLocationInDecimal { get; set; }
        public bool? ExternalId { get; set; }
        public dynamic ExtraTypeInfo { get; set; }
        public bool? Filterable { get; set; }
        public bool? Groupable { get; set; }
        public bool? HtmlFormatted { get; set; }
        public bool? IdLookup { get; set; }
        public dynamic InlineHelpText { get; set; }
        public string Label { get; set; }
        public int? Length { get; set; }
        public dynamic Mask { get; set; }
        public dynamic MaskType { get; set; }
        public string Name { get; set; }
        public bool? NameField { get; set; }
        public bool? NamePointing { get; set; }
        public bool? Nillable { get; set; }
        public bool? Permissionable { get; set; }
        public IEnumerable<PicklistValue> PicklistValues { get; set; }
        public int? Precision { get; set; }
        public bool? QueryByDistance { get; set; }
        public IEnumerable<dynamic> ReferenceTo { get; set; }
        public dynamic RelationshipName { get; set; }
        public dynamic RelationshipOrder { get; set; }
        public bool? RestrictedDelete { get; set; }
        public bool? RestrictedPicklist { get; set; }
        public int? Scale { get; set; }
        public string SoapType { get; set; }
        public bool? Sortable { get; set; }
        public string Type { get; set; }
        public bool? Unique { get; set; }
        public bool? Updateable { get; set; }
        public bool? WriteRequiresMasterRead { get; set; }
    }
}