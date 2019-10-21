using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class ISObjectPlatformActionTests
    {
        [Theory, AutoData]
        public async Task ISObjectPlatformAction(ObjectDescribeResponse expected, string query)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<ISObjectPlatformAction>();
            var result = await api.GetAsync(query, CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v44.0/sobjects/PlatformAction?q={query}");
        }
    }
}