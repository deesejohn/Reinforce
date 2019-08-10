using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Refit;

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
        [Headers("Authorization: Bearer")]
        Task<IEnumerable<VersionResponse>> GetAsync(CancellationToken cancellationToken);
    }

    public class VersionResponse
    {
        public string Version { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
    }
}