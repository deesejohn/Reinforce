using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// SObject ApprovalLayouts
    /// Returns a list of approval layouts for a specified object. Specify a particular approval process name to limit 
    /// the return value to one specific approval layout.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_sobject_approvallayouts.htm
    /// </summary>
    public interface ISObjectApprovalLayouts
    {
        [Get("/services/data/{version}/sobjects/{sObjectName}/describe/approvalLayouts")]
        [Header("Authorization", "Bearer")]
        Task<ApprovalLayoutsResponse> GetAsync(
            [Path] string sObjectName,
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );

        [Get("/services/data/{version}/sobjects/{sObjectName}/describe/approvalLayouts/{approvalProcessName}")]
        [Header("Authorization", "Bearer")]
        Task<ApprovalLayoutsResponse> GetAsync(
            [Path] string sObjectName,
            [Path] string approvalProcessName,
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );
    }
}