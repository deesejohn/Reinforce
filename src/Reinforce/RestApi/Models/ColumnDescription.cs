namespace Reinforce.RestApi.Models
{
    public class ColumnDescription
    {
        public string AscendingLabel { get; set; }
        public string DescendingLabel { get; set; }
        public string FieldNameOrPath { get; set; }
        public bool? Hidden { get; set; }
        public string Label { get; set; }
        public string SelectListItem { get; set; }
        public string SortDirection { get; set; }
        public int? SortIndex { get; set; }
        public bool? Sortable { get; set; }
        public string Type { get; set; }
    }
}