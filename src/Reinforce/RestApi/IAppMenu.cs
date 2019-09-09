using System.Threading;
using System.Threading.Tasks;
using Reinforce.RestApi.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// AppMenu
    /// Returns a list of items in either the Salesforce app drop-down menu or the Salesforce for 
    /// Android, iOS, and mobile web navigation menu.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_appmenu.htm
    /// </summary>
    public interface IAppMenu
    {
        [Get("/services/data/{version}/appMenu/AppSwitcher/")]
        [Header("Authorization", "Bearer")]
        Task<AppMenuItemsResponse> GetAppSwitcherAsync(
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );

        [Get("/services/data/{version}/appMenu/Salesforce1/")]
        [Header("Authorization", "Bearer")]
        Task<AppMenuItemsResponse> GetSalesforce1Async(
            CancellationToken cancellationToken = default(CancellationToken),
            [Path] string version = Api.Version
        );
    }
}