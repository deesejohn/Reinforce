using System.Threading;
using System.Threading.Tasks;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Platform Event Schema by Schema ID
    /// Gets the definition of a platform event in JSON format for a schema ID.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_event_eventschema.htm
    /// </summary>
    public interface IPlatformEventSchemaBySchemaID
    {
        [Get("/services/data/v46.0/event/eventSchema/{schemaId}")]
        [Header("Authorization", "Bearer")]
        Task<TPayload> GetAsync<TPayload>(
            [Path] string schemaId,
            [Query] string payloadFormat = null,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }
}