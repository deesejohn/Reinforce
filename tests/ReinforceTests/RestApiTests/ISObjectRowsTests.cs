using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Constants;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class ISObjectRowsTests
    {
        [Theory, AutoData]
        public async Task ISObjectRows(string expected, string sObjectName, string id)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ISObjectRows>();
                var result = await api.GetAsync<string>(sObjectName, id);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/sobjects/{sObjectName}/{id}");
            }
        }

        [Theory, AutoData]
        public async Task ISObjectRowsWithFields(string expected, string sObjectName, string id)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ISObjectRows>();
                var result = await api.GetAsync<string>(sObjectName, id, "Id,Name", CancellationToken.None, "v44.0");
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v44.0/sobjects/{sObjectName}/{id}?fields=Id%2CName");
            }
        }

        [Theory, AutoData]
        public async Task ISObjectRowsPatch(string sObjectName, string id, string sObject)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(null))
            {
                var api = handler.SetupApi<ISObjectRows>();
                await api.PatchAsync(sObjectName, id, sObject, CancellationToken.None, "v44.0");
                handler.ConfirmPath($"/services/data/v44.0/sobjects/{sObjectName}/{id}");
            }
        }

        [Theory, AutoData]
        public async Task ISObjectRowsDelete(string sObjectName, string id)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(null))
            {
                var api = handler.SetupApi<ISObjectRows>();
                await api.DeleteAsync(sObjectName, id, CancellationToken.None, "v44.0");
                handler.ConfirmPath($"/services/data/v44.0/sobjects/{sObjectName}/{id}");
            }
        }
    }
}