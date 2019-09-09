using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Constants;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class IAppMenuTests
    {
        [Theory, AutoData]
        public async Task IAppMenu_AppSwitcher(AppMenuItemsResponse expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IAppMenu>();
                var result = await api.GetAppSwitcherAsync();
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/appMenu/AppSwitcher/");
            }
        }

        [Theory, AutoData]
        public async Task IAppMenu_Salesforce1(AppMenuItemsResponse expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IAppMenu>();
                var result = await api.GetSalesforce1Async();
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/appMenu/Salesforce1/");
            }
        }
    }
}