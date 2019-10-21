using System.Threading;
using System.Threading.Tasks;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using RestEase;

namespace Reinforce.RestApi
{
    /// <summary>
    /// Themes
    /// Gets the list of icons and colors used by themes in the Salesforce application. Theme 
    /// information is provided for objects in your organization that use icons and colors in the 
    /// Salesforce UI.
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/resources_themes.htm
    /// </summary>
    public interface ITheme
    {
        [Get("/services/data/{version}/theme")]
        [Header("Authorization", "Bearer")]
        Task<ThemeResponse> GetAsync(
            CancellationToken cancellationToken = default,
            [Path] string version = Api.Version
        );
    }
}