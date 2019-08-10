using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Refit;

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
        [Headers("Authorization: Bearer")]
        Task<TSObject> GetAsync<TSObject>(
            string sObjectName,
            string id,
            CancellationToken cancellationToken //,
            // TODO: Add back once Refit 4.7.20+ is avaliable on nuget.org
            // https://github.com/reactiveui/refit/issues/522
            // [Query(CollectionFormat.Csv)] string[] fields = default
        );

        [Patch("/services/data/v46.0/sobjects/{sObjectName}/{id}")]
        [Headers("Authorization: Bearer")]
        Task PatchAsync<TSObject>(
            string sObjectName,
            string id,
            [Body] TSObject sObject,
            CancellationToken cancellationToken
        );

        [Delete("/services/data/v46.0/sobjects/{sObjectName}/{id}")]
        [Headers("Authorization: Bearer")]
        Task DeleteAsync<TSObject>(
            string sObjectName,
            string id,
            CancellationToken cancellationToken
        );
    }
}