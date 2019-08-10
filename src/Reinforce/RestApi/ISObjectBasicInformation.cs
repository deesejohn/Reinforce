using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        [Get("/services/data/v46.0/sobjects/{sObjectName}")]
        [Header("Authorization", "Bearer")]
        Task<SObjectBasicInformationResponse> GetAsync([Path] string sObjectName, CancellationToken cancellationToken = default);

        [Post("/services/data/v46.0/sobjects/{sObjectName}")]
        [Header("Authorization", "Bearer")]
        Task<SuccessResponse> PostAsync<TSObject>([Path] string sObjectName, [Body] TSObject sObject, CancellationToken cancellationToken = default);
    }
    
    public class SObjectBasicInformationResponse
    {
        public SObject ObjectDescribe { get; set; }
        public IEnumerable<RecentItem> RecentItems { get; set; }
    }

    public class RecentItem
    {
        public IDictionary<string, string> Attributes { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}