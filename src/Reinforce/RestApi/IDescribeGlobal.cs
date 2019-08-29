using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reinforce.RestApi.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Describe Global
    /// Lists the available objects and their metadata for your organization’s data. In addition, it provides
    /// the organization encoding, as well as the maximum batch size permitted in queries.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_describeGlobal.htm
    /// </summary>
    public interface IDescribeGlobal
    {
        [Get("/services/data/{version}/sobjects")]
        [Header("Authorization", "Bearer")]
        Task<DescribeGlobalResponse> GetAsync(
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}