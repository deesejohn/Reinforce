using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Reinforce.RestApi
{
    /// <summary>
    /// SObject Get Deleted
    /// Retrieves the list of individual records that have been deleted within the given timespan for the 
    /// specified object. SObject Get Deleted is available in API version 29.0 and later.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_getdeleted.htm
    /// </summary>
    public interface ISObjectGetDeleted
    {
        [Get("/services/data/v46.0/sobjects/{sObjectName}/deleted")]
        [Headers("Authorization: Bearer")]
        Task<SObjectGetDeleted> GetAsync(
            string sObjectName,
            CancellationToken cancellationToken,
            [Query(Format = "yyyy-MM-ddTHH:mm:ss+00:00")] DateRange range = default
        );
    }

    public class SObjectGetDeleted
    {
        public IEnumerable<DeletedRecord> DeletedRecords { get; set; }
        public DateTimeOffset? EarliestDateAvailable { get; set; }
        public DateTimeOffset? LatestDateCovered { get; set; }
    }

    public class DeletedRecord
    {
        public string Id { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
    }
}