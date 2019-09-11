using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

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
        [Get("/services/data/{version}/sobjects/{sObjectName}/deleted")]
        [Header("Authorization", "Bearer")]
        Task<SObjectGetDeleted> GetAsync(
            [Path] string sObjectName,
            [Query("start", Format = "yyyy-MM-ddTHH:mm:ss+00:00")] DateTimeOffset? startDateAndTime = null,
            [Query("end", Format = "yyyy-MM-ddTHH:mm:ss+00:00")] DateTimeOffset? endDateAndTime = null,
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}