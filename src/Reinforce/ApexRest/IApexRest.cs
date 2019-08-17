using System.Threading;
using System.Threading.Tasks;
using RestEase;

namespace Reinforce.ApexRest
{
    /// <summary>
    /// Apex REST
    /// You can expose your Apex class and methods so that external applications can access your code and your application through the REST architecture.
    /// https://developer.salesforce.com/docs/atlas.en-us.apexcode.meta/apexcode/apex_rest_intro.htm
    /// </summary>
    public interface IApexRest
    {
        [Delete("/services/apexrest/{path}")]
        [Header("Authorization", "Bearer")]
        Task DeleteAsync(
            [Path(UrlEncode = false)] string path,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        [Get("/services/apexrest/{path}")]
        [Header("Authorization", "Bearer")]
        Task<TResponse> GetAsync<TResponse>(
            [Path(UrlEncode = false)] string path,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        [Patch("/services/apexrest/{path}")]
        [Header("Authorization", "Bearer")]
        Task PatchAsync<TRequest>(
            [Path(UrlEncode = false)] string path,
            [Body] TRequest request = null,
            CancellationToken cancellationToken = default(CancellationToken)
        ) where TRequest : class;

        [Post("/services/apexrest/{path}")]
        [Header("Authorization", "Bearer")]
        Task<TResponse> PostAsync<TRequest, TResponse>(
            [Path(UrlEncode = false)] string path,
            [Body] TRequest request = null,
            CancellationToken cancellationToken = default(CancellationToken)
        ) where TRequest : class;

        [Put("/services/apexrest/{path}")]
        [Header("Authorization", "Bearer")]
        Task PutAsync<TRequest>(
            [Path(UrlEncode = false)] string path,
            [Body] TRequest request = null,
            CancellationToken cancellationToken = default(CancellationToken)
        ) where TRequest : class;
    }
}