using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// SObject Get Updated
    /// Retrieves the list of individual records that have been updated (added or changed) within the 
    /// given timespan for the specified object. SObject Get Updated is available in API version 29.0 and later.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_getupdated.htm
    /// </summary>
    public interface ISObjectGetUpdated
    {
        [Get("/services/data/v46.0/sobjects/{sObjectName}/updated")]
        [Header("Authorization", "Bearer")]
        Task<SObjectGetUpdatedResponse> GetAsync(
            [Path] string sObjectName,
            [Query("start", Format = "yyyy-MM-ddTHH:mm:ss+00:00")] DateTimeOffset? startDateAndTime = null,
            [Query("end", Format = "yyyy-MM-ddTHH:mm:ss+00:00")] DateTimeOffset? endDateAndTime = null,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }

    public class SObjectGetUpdatedResponse
    {
        public IEnumerable<string> Ids { get; set; }
        public DateTimeOffset? LatestDateCovered { get; set; }
    }
}