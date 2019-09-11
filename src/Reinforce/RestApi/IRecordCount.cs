using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Record Count
    /// Lists information about object record counts in your organization.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_record_count.htm
    /// </summary>
    public interface IRecordCount
    {
        [Get("/services/data/{version}/limits/recordCount")]
        [Header("Authorization", "Bearer")]
        Task<RecordCountResponse> GetAsync(
            [Query] string sObjects = null,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}