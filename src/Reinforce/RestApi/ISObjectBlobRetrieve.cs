using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.RestApi.Constants;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// SObject Blob Retrieve
    /// Retrieves the specified blob field from an individual record.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_sobject_blob_retrieve.htm
    /// </summary>
    public interface ISObjectBlobRetrieve
    {
        [Get("/services/data/{version}/sobjects/{sObjectName}/{id}/{blobField}")]
        [Header("Authorization", "Bearer")]
        Task<HttpResponseMessage> GetAsync(
            [Path] string sObjectName,
            [Path] string id,
            [Path] string blobField,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}