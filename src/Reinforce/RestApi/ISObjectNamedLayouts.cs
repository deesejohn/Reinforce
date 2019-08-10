using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Reinforce.RestApi
{
    /// <summary>
    /// SObject Named Layouts
    /// Retrieves information about alternate named layouts for a given object.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_sobject_named_layouts.htm
    /// </summary>
    public interface ISObjectNamedLayouts
    {
        [Get("/services/data/v46.0/sobjects/{sObjectName}/describe/namedLayouts/{layoutName}")]
        [Headers("Authorization: Bearer")]
        Task<dynamic> GetAsync(string sObjectName, string layoutName, CancellationToken cancellationToken);
    }
}