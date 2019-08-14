using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class ISObjectCompactLayoutsTests
    {
        [Theory, AutoData]
        public async Task ISObjectCompactLayouts(CompactLayoutsResponse expected, string sObjectName)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ISObjectCompactLayouts>();
                var result = await api.GetAsync(sObjectName, CancellationToken.None);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/describe/compactLayouts");
            }
        }
    }
}