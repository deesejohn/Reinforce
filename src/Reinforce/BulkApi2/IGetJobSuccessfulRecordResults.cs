using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using RestEase;

namespace Reinforce.BulkApi2
{
    /// <summary>
    /// Get Job Successful Record Results
    /// Retrieves a list of successfully processed records for a completed job.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_bulk_v2.meta/api_bulk_v2/get_job_successful_results.htm
    /// </summary>
    public interface IGetJobSuccessfulRecordResults
    {
        [Get("/services/data/{version}/jobs/ingest/{jobID}/successfulResults")]
        [Header("Authorization", "Bearer")]
        Task<string> GetAsync(
            [Path] string jobID,
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );
    }
}