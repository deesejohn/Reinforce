using System.Threading;
using System.Threading.Tasks;
using Reinforce.BulkApi2.Models;
using Reinforce.Constants;
using RestEase;

namespace Reinforce.BulkApi2
{
    /// <summary>
    /// Close or Abort a Job
    /// Closes or aborts a job. If you close a job, Salesforce queues the job and uploaded data for
    /// processing, and you can’t add any additional job data. If you abort a job, the job does not
    /// get queued or processed.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_bulk_v2.meta/api_bulk_v2/close_job.htm
    /// </summary>
    public interface ICloseOrAbortAJob
    {
        [Patch("/services/data/{version}/jobs/ingest/{jobID}")]
        [Header("Authorization", "Bearer")]
        Task<JobInfo> PatchAsync(
            [Path] string jobID,
            [Body] CloseOrAbortAJobRequest body,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}