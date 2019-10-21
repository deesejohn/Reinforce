using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using RestEase;

namespace Reinforce.BulkApi2
{
    /// <summary>
    /// Delete a Job
    /// Deletes a job. To be deleted, a job must have a state of UploadComplete, JobComplete,
    /// Aborted, or Failed.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_bulk_v2.meta/api_bulk_v2/delete_job.htm
    /// </summary>
    public interface IDeleteAJob
    {
        [Delete("/services/data/{version}/jobs/ingest/{jobID}")]
        [Header("Authorization", "Bearer")]
        Task DeleteAsync(
            [Path] string jobID,
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );
    }
}