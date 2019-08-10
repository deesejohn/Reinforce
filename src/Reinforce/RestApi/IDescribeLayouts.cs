using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Refit;

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
        [Headers("Authorization: Bearer")]
        Task<IEnumerable<DescribeLayout>> GetAsync(CancellationToken cancellationToken);

        [Get("/services/data/v46.0/sobjects/{sObjectName}/describe/layouts")]
        [Headers("Authorization: Bearer")]
        Task<IEnumerable<DescribeLayout>> GetAsync(string sObjectName, CancellationToken cancellationToken);
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