using RestEase;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Composite
    /// Executes a series of REST API requests in a single call. You can use the output of one request as the input to a subsequent 
    /// request. The response bodies and HTTP statuses of the requests are returned in a single response body. The entire request 
    /// counts as a single call toward your API limits.
    /// The requests in a composite call are called subrequests. All subrequests are executed in the context of the same user. In a
    /// subrequest’s body, you specify a reference ID that maps to the subrequest’s response. You can then refer to the ID in the 
    /// url or body fields of later subrequests by using a JavaScript-like reference notation. 
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_composite_composite.htm
    /// </summary>
    public interface IComposite
    {
        [Post("/services/data/{version}/composite")]
        [Header("Authorization", "Bearer")]
        Task<CompositeResponse<dynamic>> PostAsync(
            [Body] Composite compositeRequest,
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );

        [Post("/services/data/{version}/composite")]
        [Header("Authorization", "Bearer")]
        Task<CompositeResponse<T>> PostAsync<T>(
            [Body] Composite compositeRequest,
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );

    }
}
