using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Limits
    /// Lists information about limits in your org. This resource is available in REST API version 
    /// 29.0 and later for API users with the View Setup and Configuration permission.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_limits.htm
    /// </summary>
    public interface ILimits
    {
        [Get("/services/data/{version}/limits")]
        [Header("Authorization", "Bearer")]
        Task<IDictionary<string, Limit>> GetAsync(
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );
    }
}