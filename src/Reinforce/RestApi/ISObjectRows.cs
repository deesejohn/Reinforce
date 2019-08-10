using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// SObject Rows
    /// Accesses records based on the specified object ID. Retrieves, updates, or deletes records. This 
    /// resource can also be used to retrieve field values. Use the GET method to retrieve records or fields, 
    /// the DELETE method to delete records, and the PATCH method to update records.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_sobject_retrieve.htm
    /// </summary>
    public interface ISObjectRows
    {
        [Get("/services/data/v46.0/sobjects/{sObjectName}/{id}")]
        [Header("Authorization", "Bearer")]
        Task<TSObject> GetAsync<TSObject>(
            [Path] string sObjectName,
            [Path] string id,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        [Get("/services/data/v46.0/sobjects/{sObjectName}/{id}?fields={fields}")]
        [Header("Authorization", "Bearer")]
        Task<TSObject> GetAsync<TSObject>(
            [Path] string sObjectName,
            [Path] string id,
            [Path(UrlEncode = false)] string fields,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        [Patch("/services/data/v46.0/sobjects/{sObjectName}/{id}")]
        [Header("Authorization", "Bearer")]
        Task PatchAsync<TSObject>(
            [Path] string sObjectName,
            [Path] string id,
            [Body] TSObject sObject,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        [Delete("/services/data/v46.0/sobjects/{sObjectName}/{id}")]
        [Header("Authorization", "Bearer")]
        Task DeleteAsync(
            [Path] string sObjectName,
            [Path] string id,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }
}