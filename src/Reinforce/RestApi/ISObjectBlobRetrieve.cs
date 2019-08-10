using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Reinforce.RestApi
{
    /// <summary>
    /// SObject Blob Retrieve
    /// Retrieves the specified blob field from an individual record.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_sobject_blob_retrieve.htm
    /// </summary>
    public interface ISObjectBlobRetrieve
    {
        [Get("/services/data/v46.0/sobjects/{sObjectName}/{id}/{blobField}")]
        [Headers("Authorization: Bearer")]
        Task<HttpResponseMessage> GetAsync(
            string sObjectName,
            string id,
            string blobField,
            CancellationToken cancellationToken
        );
    }
}