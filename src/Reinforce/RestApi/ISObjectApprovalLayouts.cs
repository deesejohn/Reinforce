using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        [Get("/services/data/v46.0/sobjects/{sObjectName}/describe/approvalLayouts")]
        [Header("Authorization", "Bearer")]
        Task<ApprovalLayoutsResponse> GetAsync(
            [Path] string sObjectName,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        [Get("/services/data/v46.0/sobjects/{sObjectName}/describe/approvalLayouts/{approvalProcessName}")]
        [Header("Authorization", "Bearer")]
        Task<ApprovalLayoutsResponse> GetAsync(
            [Path] string sObjectName,
            [Path] string approvalProcessName,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }

    public class ApprovalLayoutsResponse
    {
        public IEnumerable<ApprovalLayout> ApprovalLayouts { get; set; }
    }

    public class ApprovalLayout
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public IEnumerable<dynamic> LayoutItems { get; set; }

        public string Name { get; set; }
    }
}