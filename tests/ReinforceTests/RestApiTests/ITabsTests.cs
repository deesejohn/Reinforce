using System.Collections.Generic;
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
    public class ITabsTests
    {
        [Theory, AutoData]
        public async Task ITabs(IEnumerable<Tab> expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ITabs>();
                var result = await api.GetAsync(CancellationToken.None, "v44.0");
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v44.0/tabs");
            }            
        }

        [Theory, AutoData]
        public async Task ITabs_ApiVersion(IEnumerable<Tab> expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ITabs>();
                var result = await api.GetAsync(CancellationToken.None);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/tabs");
            }            
        }
    }
}