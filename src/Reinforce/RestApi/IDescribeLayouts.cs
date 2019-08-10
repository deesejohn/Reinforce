using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Describe Layouts
    /// Returns a list of layouts and descriptions. The list of fields and the layout name are returned. 
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_sobject_layouts.htm
    /// </summary>
    public interface IDescribeLayouts
    {
        [Get("/services/data/v46.0/sobjects/Global/describe/layouts")]
        [Header("Authorization", "Bearer")]
        Task<IEnumerable<DescribeLayout>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        [Get("/services/data/v46.0/sobjects/{sObjectName}/describe/layouts")]
        [Header("Authorization", "Bearer")]
        Task<IEnumerable<DescribeLayout>> GetAsync([Path] string sObjectName, CancellationToken cancellationToken = default(CancellationToken));
    }

    public class DescribeLayout
    {
        public string Label { get; set; }
        public int? LimitRows { get; set; }
        public string Name { get; set; }
        public IEnumerable<SearchColumn> SearchColumns { get; set; }
    }

    public class SearchColumn
    {
        public string Field { get; set; }
        public object Format { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
    }
}