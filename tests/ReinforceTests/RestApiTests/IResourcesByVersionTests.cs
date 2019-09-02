using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class IResourcesByVersionTests
    {
        [Theory, AutoData]
        public async Task IResourcesByVersion(IDictionary<string, string> expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IResourcesByVersion>();
                var result = await api.GetAsync(CancellationToken.None, "v46.0");
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath("/services/data/v46.0");
            }
        }
    }
}