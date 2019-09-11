using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using RestEase;

namespace Reinforce.BulkApi2
{
    /// <summary>
    /// Get Job Failed Record Results
    /// Retrieves a list of failed records for a completed job.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_bulk_v2.meta/api_bulk_v2/get_job_failed_results.htm
    /// </summary>
    public interface IGetJobFailedRecordResults
    {
        [Get("/services/data/{version}/jobs/ingest/{jobID}/failedResults")]
        [Header("Authorization", "Bearer")]
        Task<string> GetAsync(
            [Path] string jobID,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}