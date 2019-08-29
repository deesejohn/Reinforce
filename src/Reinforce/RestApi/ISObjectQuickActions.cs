using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.RestApi.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// SObject Quick Actions
    /// Returns a list of actions and their details.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_sobject_quickactions.htm
    /// </summary>
    public interface ISObjectQuickActions
    {
        [Get("/services/data/{version}/sobjects/{sObjectName}/quickActions")]
        [Header("Authorization", "Bearer")]
        Task<IEnumerable<QuickAction>> GetAsync(
            [Path] string sObjectName,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Get("/services/data/{version}/sobjects/{sObjectName}/quickActions/{actionName}")]
        [Header("Authorization", "Bearer")]
        Task<dynamic> GetAsync(
            [Path] string sObjectName,
            [Path] string actionName,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Post("/services/data/{version}/sobjects/{sObjectName}/quickActions/{actionName}")]
        [Header("Authorization", "Bearer")]
        Task PostAsync<TAction>(
            [Path] string sObjectName,
            [Path] string actionName,
            [Body] TAction action,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Get("/services/data/{version}/sobjects/{sObjectName}/quickActions/{actionName}/describe")]
        [Header("Authorization", "Bearer")]
        Task<dynamic> DescribeAsync(
            [Path] string sObjectName,
            [Path] string actionName,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Get("/services/data/{version}/sobjects/{sObjectName}/quickActions/{actionName}/defaultValues")]
        [Header("Authorization", "Bearer")]
        Task<dynamic> DefaultValuesAsync(
            [Path] string sObjectName,
            [Path] string actionName,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Get("/services/data/{version}/sobjects/{sObjectName}/quickActions/{actionName}/defaultValues/{contextId}")]
        [Header("Authorization", "Bearer")]
        Task<dynamic> DefaultValuesAsync(
            [Path] string sObjectName,
            [Path] string actionName,
            [Path] string contextId,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}