using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.ApexRest;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.ApexRestTests
{
    public class IApexRestTests
    {
        private const string Path = "class/id?query=value";

        [Fact]
        public async Task IApexRestDelete()
        {
            using var handler = MockHttpMessageHandler.SetupHandler(null);
            var api = handler.SetupApi<IApexRest>();
            await api.DeleteAsync(Path, CancellationToken.None);
            handler.ConfirmPath($"/services/apexrest/{Path}");
        }

        [Theory, AutoData]
        public async Task IApexRest(SObject expected)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IApexRest>();
            var result = await api.GetAsync<SObject>(Path, CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/apexrest/{Path}");
        }

        [Theory, AutoData]
        public async Task IApexRestPatch(SObject request)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(null);
            var api = handler.SetupApi<IApexRest>();
            await api.PatchAsync(Path, request, CancellationToken.None);
            handler.ConfirmPath($"/services/apexrest/{Path}");
        }

        [Theory, AutoData]
        public async Task IApexRestPost(SObject expected, SObject request)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IApexRest>();
            var result = await api.PostAsync<SObject, SObject>(Path, request, CancellationToken.None);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/apexrest/{Path}");
        }

        [Theory, AutoData]
        public async Task IApexRestPut(SObject expected, SObject request)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IApexRest>();
            await api.PutAsync(Path, request, CancellationToken.None);
            handler.ConfirmPath($"/services/apexrest/{Path}");
        }
    }
}