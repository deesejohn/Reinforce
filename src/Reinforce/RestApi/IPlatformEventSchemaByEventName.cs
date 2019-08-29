using System.Threading;
using System.Threading.Tasks;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Platform Event Schema by Event Name
    /// Gets the definition of a platform event in JSON format for an event name.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_sobject_eventschema.htm
    /// </summary>
    public interface IPlatformEventSchemaByEventName
    {
        [Get("/services/data/v46.0/sobjects/{eventName}/eventSchema")]
        [Header("Authorization", "Bearer")]
        Task<TPayload> GetAsync<TPayload>(
            [Path] string eventName,
            [Query] string payloadFormat = null,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }
}