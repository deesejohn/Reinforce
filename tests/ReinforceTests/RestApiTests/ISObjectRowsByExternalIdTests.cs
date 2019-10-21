using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class ISObjectRowsByExternalIdTests
    {
        [Theory, AutoData]
        public async Task ISObjectRowsByExternalId(string expected, string sObjectName, string fieldName, string fieldValue)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<ISObjectRowsByExternalId>();
            var result = await api.GetAsync<string>(sObjectName, fieldName, fieldValue, CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v44.0/sobjects/{sObjectName}/{fieldName}/{fieldValue}");
        }

        [Theory, AutoData]
        public async Task ISObjectRowsByExternalIdPatch(SuccessResponse expected, string sObjectName, string fieldName, string fieldValue, string sObject)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<ISObjectRowsByExternalId>();
            var result = await api.PatchAsync(sObjectName, fieldName, fieldValue, sObject, CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v44.0/sobjects/{sObjectName}/{fieldName}/{fieldValue}");
        }

        [Theory, AutoData]
        public async Task ISObjectRowsByExternalIdDelete(string expected, string sObjectName, string fieldName, string fieldValue)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<ISObjectRowsByExternalId>();
            await api.DeleteAsync(sObjectName, fieldName, fieldValue, CancellationToken.None, "v44.0");
            handler.ConfirmPath($"/services/data/v44.0/sobjects/{sObjectName}/{fieldName}/{fieldValue}");
        }

        [Theory, AutoData]
        public async Task ISObjectRowsByExternalIdPost(SuccessResponse expected, string sObjectName, string id, string sObject)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<ISObjectRowsByExternalId>();
            var result = await api.PostAsync(sObjectName, id, sObject, CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v44.0/sobjects/{sObjectName}/{id}");
        }
    }
}