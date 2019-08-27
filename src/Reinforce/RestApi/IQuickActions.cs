using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
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