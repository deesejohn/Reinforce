using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// SObject Basic Information
    /// Describes the individual metadata for the specified object. Can also be used to create a new record for a
    /// given object. For example, this can be used to retrieve the metadata for the Account object using the GET
    /// method, or create a new Account object using the POST method.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_sobject_basic_info.htm
    /// </summary>
    public interface ISObjectBasicInformation
    {
        [Get("/services/data/{version}/sobjects/{sObjectName}")]
        [Header("Authorization", "Bearer")]
        Task<SObjectBasicInformationResponse> GetAsync(
            [Path] string sObjectName,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Post("/services/data/{version}/sobjects/{sObjectName}")]
        [Header("Authorization", "Bearer")]
        Task<SuccessResponse> PostAsync<TSObject>(
            [Path] string sObjectName,
            [Body] TSObject sObject,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }  
}