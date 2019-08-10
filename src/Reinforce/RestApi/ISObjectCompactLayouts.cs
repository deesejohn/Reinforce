using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// SObject CompactLayouts
    /// Returns a list of compact layouts for a specific object.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_sobject_compactlayouts.htm
    /// </summary>
    public interface ISObjectCompactLayouts
    {
        [Get("/services/data/v46.0/sobjects/{sObjectName}/describe/compactLayouts")]
        [Header("Authorization", "Bearer")]
        Task<CompactLayoutsResponse> GetAsync(
            [Path] string sObjectName,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }

    public class Action
    {
        public bool? Custom { get; set; }
        public dynamic Icons { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
    }

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
        public IEnumerable<dynamic> PicklistValues { get; set; }
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

    public class LayoutComponent
    {
        public IEnumerable<dynamic> Components { get; set; }
        public Details Details { get; set; }
        public int? DisplayLines { get; set; }
        public int? TabOrder { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class FieldItem
    {
        public bool? Editable { get; set; }
        public string Label { get; set; }
        public IEnumerable<LayoutComponent> LayoutComponents { get; set; }
        public bool? Placeholder { get; set; }
        public bool? Required { get; set; }
    }

    public class ImageItem
    {
        public bool? Editable { get; set; }
        public string Label { get; set; }
        public IEnumerable<LayoutComponent> LayoutComponents { get; set; }
        public bool? Placeholder { get; set; }
        public bool? Required { get; set; }
    }

    public class CompactLayout
    {
        public IEnumerable<Action> Actions { get; set; }
        public IEnumerable<FieldItem> FieldItems { get; set; }
        public string Id { get; set; }
        public IEnumerable<ImageItem> ImageItems { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
    }

    public class RecordTypeCompactLayoutMapping
    {
        public bool? Available { get; set; }
        public string CompactLayoutId { get; set; }
        public string CompactLayoutName { get; set; }
        public string RecordTypeId { get; set; }
        public string RecordTypeName { get; set; }
        public IDictionary<string, string> Urls { get; set; }
    }

    public class CompactLayoutsResponse
    {
        public IEnumerable<CompactLayout> CompactLayouts { get; set; }
        public string DefaultCompactLayoutId { get; set; }
        public IEnumerable<RecordTypeCompactLayoutMapping> RecordTypeCompactLayoutMappings { get; set; }
        public IDictionary<string, string> Urls { get; set; }
    }
}