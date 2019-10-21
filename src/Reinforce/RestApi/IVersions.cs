using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Versions
    /// Lists summary information about each Salesforce version currently available, including the 
    /// version, label, and a link to each version's root.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_versions.htm
    /// </summary>
    public interface IVersions
    {
        [Get("/services/data")]
        [Header("Authorization", "Bearer")]
        Task<IEnumerable<VersionResponse>> GetAsync(CancellationToken cancellationToken = default);
    }
}