using System.Threading;
using System.Threading.Tasks;
using RestEase;

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
        [Header("Authorization", "Bearer")]
        Task<dynamic> HeadAsync(
            [Path] string sObjectName,
            [Path] string fieldName,
            [Path] string fieldValue,
            CancellationToken cancellationToken = default(CancellationToken)
        );
        
        [Get("/services/data/v46.0/sobjects/{sObjectName}/{fieldName}/{fieldValue}")]
        [Header("Authorization", "Bearer")]
        Task<TSObject> GetAsync<TSObject>(
            [Path] string sObjectName,
            [Path] string fieldName,
            [Path] string fieldValue,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        [Patch("/services/data/v46.0/sobjects/{sObjectName}/{fieldName}/{fieldValue}")]
        [Header("Authorization", "Bearer")]
        Task<SuccessResponse> PatchAsync<TSObject>(
            [Path] string sObjectName,
            [Path] string fieldName,
            [Path] string fieldValue,
            [Body] TSObject sObject,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        [Delete("/services/data/v46.0/sobjects/{sObjectName}/{fieldName}/{fieldValue}")]
        [Header("Authorization", "Bearer")]
        Task DeleteAsync(
            [Path] string sObjectName,
            [Path] string fieldName,
            [Path] string fieldValue,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        [Post("/services/data/v46.0/sobjects/{sObjectName}/{id}")]
        [Header("Authorization", "Bearer")]
        Task<SuccessResponse> PostAsync<TSObject>(
            [Path] string sObjectName,
            [Path] string id,
            [Body] TSObject sObject,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }
}