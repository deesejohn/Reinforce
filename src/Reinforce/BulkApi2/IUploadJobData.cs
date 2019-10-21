using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using RestEase;

namespace Reinforce.BulkApi2
{
    /// <summary>
    /// Upload Job Data
    /// Uploads data for a job using CSV data you provide.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_bulk_v2.meta/api_bulk_v2/upload_job_data.htm
    /// </summary>
    [Header("Content-Type", "text/csv")]
    public interface IUploadJobData
    {
        [Put("/services/data/{version}/jobs/ingest/{jobID}/batches")]
        [Header("Authorization", "Bearer")]
        Task PutAsync(
            [Path] string jobID,
            [Body] byte[] body,
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        ); 
    }
}