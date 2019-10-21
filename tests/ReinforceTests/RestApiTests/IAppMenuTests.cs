using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class IAppMenuTests
    {
        [Theory, AutoData]
        public async Task IAppMenu_AppSwitcher(AppMenuItemsResponse expected)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IAppMenu>();
            var result = await api.GetAppSwitcherAsync();
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{Api.Version}/appMenu/AppSwitcher");
        }

        [Theory, AutoData]
        public async Task IAppMenu_AppSwitcher_ApiVersion(AppMenuItemsResponse expected)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IAppMenu>();
            var result = await api.GetAppSwitcherAsync(CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v44.0/appMenu/AppSwitcher");
        }

        [Theory, AutoData]
        public async Task IAppMenu_Salesforce1(AppMenuItemsResponse expected)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IAppMenu>();
            var result = await api.GetSalesforce1Async();
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{Api.Version}/appMenu/Salesforce1");
        }

        [Theory, AutoData]
        public async Task IAppMenu_Salesforce1_ApiVersion(AppMenuItemsResponse expected)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IAppMenu>();
            var result = await api.GetSalesforce1Async(CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v44.0/appMenu/Salesforce1");
        }
    }
}