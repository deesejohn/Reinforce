using System.Collections.Generic;

namespace Reinforce.RestApi.Models
{
    public class ListViewResult
    {
        public IEnumerable<ColumnValue> Columns { get; set; }
    }
}