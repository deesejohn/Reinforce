using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// SObject Named Layouts
    /// Retrieves information about alternate named layouts for a given object.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_sobject_named_layouts.htm
    /// </summary>
    public interface ISObjectNamedLayouts
    {
        [Get("/services/data/{version}/sobjects/{sObjectName}/describe/namedLayouts/{layoutName}")]
        [Header("Authorization", "Bearer")]
        Task<dynamic> GetAsync(
            [Path] string sObjectName,
            [Path] string layoutName,
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );
    }
}