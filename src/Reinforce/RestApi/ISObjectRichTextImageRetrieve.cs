using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.RestApi.Constants;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// SObject Rich Text Image Retrieve
    /// Retrieves the specified image data from a specific rich text area field in a given record.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_sobject_rich_text_image_retrieve.htm
    /// </summary>
    public interface ISObjectRichTextImageRetrieve
    {
        [Get("/services/data/{version}/sobjects/{sObjectName}/{id}/richTextImageFields/{fieldName}/{contentReferenceId}")]
        [Header("Authorization", "Bearer")]
        Task<Stream> GetAsync(
            [Path] string sObjectName,
            [Path] string id,
            [Path] string fieldName,
            [Path] string contentReferenceId,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}