using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Reinforce.RestApi
{
    /// <summary>
    /// SObject Rows by External ID
    /// Creates new records or updates existing records (upserts records) based on the value of a specified 
    /// external ID field.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_sobject_upsert.htm
    /// </summary>
    public interface ISObjectRowsByExternalId
    {
        [Head("/services/data/v46.0/sobjects/{sObjectName}/{fieldName}/{fieldValue}")]
        [Headers("Authorization: Bearer")]
        Task<dynamic> HeadAsync(
            string sObjectName,
            string fieldName,
            string fieldValue,
            CancellationToken cancellationToken
        );
        
        [Get("/services/data/v46.0/sobjects/{sObjectName}/{fieldName}/{fieldValue}")]
        [Headers("Authorization: Bearer")]
        Task<TSObject> GetAsync<TSObject>(
            string sObjectName,
            string fieldName,
            string fieldValue,
            CancellationToken cancellationToken
        );

        [Patch("/services/data/v46.0/sobjects/{sObjectName}/{fieldName}/{fieldValue}")]
        [Headers("Authorization: Bearer")]
        Task<SuccessResponse> PatchAsync<TSObject>(
            string sObjectName,
            string fieldName,
            string fieldValue,
            [Body] TSObject sObject,
            CancellationToken cancellationToken
        );

        [Delete("/services/data/v46.0/sobjects/{sObjectName}/{fieldName}/{fieldValue}")]
        [Headers("Authorization: Bearer")]
        Task DeleteAsync(
            string sObjectName,
            string fieldName,
            string fieldValue,
            CancellationToken cancellationToken
        );

        [Post("/services/data/v46.0/sobjects/{sObjectName}/{id}")]
        [Headers("Authorization: Bearer")]
        Task<SuccessResponse> PostAsync<TSObject>(
            string sObjectName,
            string id,
            [Body] TSObject sObject,
            CancellationToken cancellationToken
        );
    }
}