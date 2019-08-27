using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Quick Actions
    /// Returns a list of global actions and object-specific actions.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_quickactions.htm
    /// </summary>
    public interface IQuickActions
    {
        [Get("/services/data/v46.0/quickActions")]
        [Header("Authorization", "Bearer")]
        Task<IEnumerable<QuickAction>> GetAsync(
            CancellationToken cancellationToken = default(CancellationToken)
        );

        [Post("/services/data/v46.0/quickActions/{actionName}")]
        [Header("Authorization", "Bearer")]
        Task PostAsync<TAction>(
            [Path] string actionName,
            [Body] TAction action,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }
}