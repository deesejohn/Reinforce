using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    public interface ISObjectRelationships
    {
        [Get("/services/data/{version}/sobjects/{sObjectName}/{id}/{relationshipFieldName}")]
        [Header("Authorization", "Bearer")]
        Task<QueryResponse<TSObject>> GetAsync<TSObject>(
            [Path] string sObjectName,
            [Path] string id,
            [Path] string relationshipFieldName,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Get("/services/data/{version}/sobjects/{sObjectName}/{id}/{relationshipFieldName}")]
        [Header("Authorization", "Bearer")]
        Task<QueryResponse<TSObject>> GetAsync<TSObject>(
            [Path] string sObjectName,
            [Path] string id,
            [Path] string relationshipFieldName,
            [Query] string fields,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}