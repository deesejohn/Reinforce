using System.Threading;
using System.Threading.Tasks;
using Reinforce.BulkApi2.Models;
using Reinforce.Constants;
using RestEase;

namespace Reinforce.BulkApi2
{
    /// <summary>
    /// Create a Job
    /// Creates a job, which represents a bulk operation (and associated data) that is sent to 
    /// Salesforce for asynchronous processing. Provide job data via an Upload Job Data request, or 
    /// as part of a multipart create job request.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_bulk_v2.meta/api_bulk_v2/create_job.htm
    /// </summary>
    public interface ICreateAJob
    {
        [Post("/services/data/{version}/jobs/ingest")]
        [Header("Authorization", "Bearer")]
        Task<JobInfo> PostAsync(
            [Body] CreateAJobRequest body,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}