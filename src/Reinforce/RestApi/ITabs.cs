using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Tabs
    /// Returns a list of all tabs—including Lightning page tabs—available to the current user, 
    /// regardless of whether the user has chosen to hide tabs via the All Tabs (+) tab 
    /// customization feature.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_tabs.htm
    /// </summary>
    public interface ITabs
    {
        [Get("/services/data/{version}/tabs")]
        [Header("Authorization", "Bearer")]
        Task<IEnumerable<Tab>> GetAsync(
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}