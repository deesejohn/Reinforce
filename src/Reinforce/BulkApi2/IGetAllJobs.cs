using System.Threading;
using System.Threading.Tasks;
using Reinforce.BulkApi2.Models;
using Reinforce.Constants;
using RestEase;

namespace Reinforce.BulkApi2
{
    /// <summary>
    /// Get All Jobs
    /// Retrieves all jobs in the org.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_bulk_v2.meta/api_bulk_v2/get_all_jobs.htm
    /// </summary>
    public interface IGetAllJobs
    {
        [Get("/services/data/{version}/jobs/ingest")]
        [Header("Authorization", "Bearer")]
        Task<GetAllJobsResponse> GetAsync(
            [Query] bool? isPkChunkingEnabled = null,
            [Query] JobTypeEnum? jobType = null,
            [Query] string queryLocator = null,
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );
    }
}