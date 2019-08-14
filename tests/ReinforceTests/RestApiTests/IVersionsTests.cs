using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class IVersionsTests
    {
        [Theory, AutoData]
        public async Task IVersions(IEnumerable<VersionResponse> expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IVersions>();
                var result = await api.GetAsync();
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data");
            }
        }
    }
}