namespace Reinforce.RestApi.Models
{
    public class OrderBy
    {
        public string FieldNameOrPath { get; set; }
        public string NullsPosition { get; set; }
        public string SortDirection { get; set; }
    }
}