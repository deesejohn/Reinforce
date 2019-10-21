using System.Threading;
using System.Threading.Tasks;
using Reinforce.BulkApi2.Models;
using Reinforce.Constants;
using RestEase;

namespace Reinforce.BulkApi2
{
    /// <summary>
    /// Get Job Info
    /// Retrieves detailed information about a job.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_bulk_v2.meta/api_bulk_v2/get_job_info.htm
    /// </summary>
    public interface IGetJobInfo
    {
        [Get("/services/data/{version}/jobs/ingest/{jobID}")]
        [Header("Authorization", "Bearer")]
        Task<JobInfoResponse> GetAsync(
            [Path] string jobID,
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );
    }
}