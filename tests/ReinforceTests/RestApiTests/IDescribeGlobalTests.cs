using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class IDescribeGlobalTests
    {
        [Theory, AutoData]
        public async Task IDescribeGlobal(DescribeGlobalResponse expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IDescribeGlobal>();
                var result = await api.GetAsync(CancellationToken.None, "v46.0");
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath("/services/data/v46.0/sobjects");
            }
        }
    }
}