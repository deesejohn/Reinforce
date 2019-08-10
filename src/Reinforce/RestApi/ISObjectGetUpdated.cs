using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Refit;

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
        [Headers("Authorization: Bearer")]
        Task<SObjectGetUpdatedResponse> GetAsync(
            string sObjectName,
            CancellationToken cancellationToken,
            [Query(Format = "yyyy-MM-ddTHH:mm:ss+00:00")] DateRange range = default
        );
    }

    public class SObjectGetUpdatedResponse
    {
        public IEnumerable<string> Ids { get; set; }
        public DateTimeOffset? LatestDateCovered { get; set; }
    }
}