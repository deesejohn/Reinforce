using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.Constants;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class ICompositeTests
    {
        [Theory, AutoData]
        public async Task IComposite(string expected, string sObjectName, string id)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<ISObjectRows>();
            var result = await api.GetAsync<string>(sObjectName, id);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{Api.Version}/sobjects/{sObjectName}/{id}");
        }

    }
}