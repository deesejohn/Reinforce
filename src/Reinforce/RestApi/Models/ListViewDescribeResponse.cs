using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class ListViewDescribeResponse
    {
        public IEnumerable<ColumnDescription> Columns { get; set; }
        public string Id { get; set; }
        public IEnumerable<OrderBy> OrderBy { get; set; }
        public string Query { get; set; }
        public string Scope { get; set; }
        public string SobjectType { get; set; }
        public WhereCondition WhereCondition { get; set; }
    }
}