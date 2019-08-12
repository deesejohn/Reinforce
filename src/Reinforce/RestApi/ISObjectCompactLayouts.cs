using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.RestApi.Models;
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
}