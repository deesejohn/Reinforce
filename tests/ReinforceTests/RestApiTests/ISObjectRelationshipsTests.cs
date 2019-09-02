using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class ISObjectRelationshipsTests
    {
        [Theory, AutoData]
        public async Task ISObjectRelationships(
            QueryResponse<string> expected,
            string sObjectName,
            string id,
            string relationshipFieldName
        )
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ISObjectRelationships>();
                var result = await api.GetAsync<string>(sObjectName, id, relationshipFieldName, CancellationToken.None, "v46.0");
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/{id}/{relationshipFieldName}");
            }
        }

        [Theory, AutoData]
        public async Task ISObjectRelationships_Fields(
            QueryResponse<string> expected,
            string sObjectName,
            string id,
            string relationshipFieldName,
            string[] fields
        )
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ISObjectRelationships>();
                var result = await api.GetAsync<string>(sObjectName, id, relationshipFieldName, string.Join(",", fields), CancellationToken.None, "v46.0");
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/{id}/{relationshipFieldName}?fields={string.Join("%2C", fields)}");
            }
        }
    }
}