using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.RestApi.Models;
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
        Task<IEnumerable<DescribeLayout>> GetAsync(
            [Path] string sObjectName,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }
}