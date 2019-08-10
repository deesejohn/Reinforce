using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Resources by Version
    /// Lists available resources for the specified API version, including resource name and URI.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_discoveryresource.htm
    /// </summary>
    public interface IResourcesByVersion
    {
        [Get("/services/data/v46.0")]
        [Headers("Authorization: Bearer")]
        Task<IDictionary<string, string>> GetAsync(CancellationToken cancellationToken);
    }
}