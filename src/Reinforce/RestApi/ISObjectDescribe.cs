using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// SObject Describe
    /// Completely describes the individual metadata at all levels for the specified object. For example, this 
    /// can be used to retrieve the fields, URLs, and child relationships for the Account object.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_sobject_describe.htm
    /// </summary>
    public interface ISObjectDescribe
    {
        [Get("/services/data/{version}/sobjects/{sObjectName}/describe")]
        [Header("Authorization", "Bearer")]
        Task<dynamic> GetAsync(
            [Path] string sObjectName,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}