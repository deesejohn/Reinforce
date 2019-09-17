using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    public interface ISearch
    {
        [Get("/services/data/{version}/search")]
        [Header("Authorization", "Bearer")]
        Task<SearchResponse<T>> GetAsync<T>(
            [Query] string q,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}