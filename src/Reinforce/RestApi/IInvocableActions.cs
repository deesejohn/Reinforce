using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Invocable Actions
    /// Represents a standard or custom invocable action.
    /// Use actions to add more functionality to your applications. Choose from standard actions, such as 
    /// posting to Chatter or sending email, or create actions based on your company’s needs.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_actions_invocable.htm
    /// </summary>
    public interface IInvocableActions
    {
        [Get("/services/data/{version}/actions")]
        [Header("Authorization", "Bearer")]
        Task<IDictionary<string, string>> GetAsync(
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Get("/services/data/{version}/actions/custom")]
        [Header("Authorization", "Bearer")]
        Task<IDictionary<string, string>> GetCustomAsync(
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Get("/services/data/{version}/actions/custom/{type}")]
        [Header("Authorization", "Bearer")]
        Task<ActionsResponse> GetCustomAsync(
            [Path] string type,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Get("/services/data/{version}/actions/custom/{type}/{action}")]
        [Header("Authorization", "Bearer")]
        Task<InvocableAction> GetCustomAsync(
            [Path] string type,
            [Path] string action,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Post("/services/data/{version}/actions/custom/{route}")]
        [Header("Authorization", "Bearer")]
        Task<InvokedActionResponse<TResponse>> PostCustomAsync<TRequest, TResponse>(
            [Path(UrlEncode = false)] string route,
            [Body] TRequest body,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Get("/services/data/{version}/actions/standard")]
        [Header("Authorization", "Bearer")]
        Task<ActionsResponse> GetStandardAsync(
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Get("/services/data/{version}/actions/standard/{action}")]
        [Header("Authorization", "Bearer")]
        Task<InvocableAction> GetStandardAsync(
            [Path] string action,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Post("/services/data/{version}/actions/standard/{action}")]
        [Header("Authorization", "Bearer")]
        Task<InvokedActionResponse<TResponse>> PostStandardAsync<TRequest, TResponse>(
            [Path(UrlEncode = false)] string action,
            [Body] TRequest body,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}