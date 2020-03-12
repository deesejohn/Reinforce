using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.Constants;
using Xunit;
using Reinforce.RestApi.Models;

namespace ReinforceTests.RestApiTests
{
    public class ICompositeTests
    {
        [Theory, AutoData]
        public async Task IComposite_PostAsync(CompositeResponse<dynamic> expected, Composite request)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IComposite>();
            var result = await api.PostAsync(request);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{Api.Version}/composite");
        }

        [Theory]
        [InlineAutoData("v35.0")]
        public async Task IComposite_PostAsync_Args(string apiVersion, CompositeResponse<dynamic> expected, Composite request)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IComposite>();
            var result = await api.PostAsync(request, CancellationToken.None, apiVersion);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{apiVersion}/composite");
        }

        [Theory, AutoData]
        public async Task IComposite_PostAsync_T(CompositeResponse<string> expected, Composite request)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IComposite>();
            var result = await api.PostAsync<string>(request);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{Api.Version}/composite");
        }

        [Theory]
        [InlineAutoData("v35.0")]
        public async Task IComposite_PostAsync_T_Args(string apiVersion, CompositeResponse<string> expected, Composite request)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IComposite>();
            var result = await api.PostAsync<string>(request, CancellationToken.None, apiVersion);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{apiVersion}/composite");
        }
    }
}