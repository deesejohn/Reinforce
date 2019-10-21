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
    public class IThemeTests
    {
        [Theory, AutoData]
        public async Task ITheme(ThemeResponse expected)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<ITheme>();
            var result = await api.GetAsync(CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath("/services/data/v44.0/theme");
        }

        [Theory, AutoData]
        public async Task ITheme_ApiVersion(ThemeResponse expected)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<ITheme>();
            var result = await api.GetAsync(CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{Api.Version}/theme");
        }
    }
}