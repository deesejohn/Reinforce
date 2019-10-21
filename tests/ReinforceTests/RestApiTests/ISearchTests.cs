using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.Constants;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class ISearchTests
    {
        [Theory]
        [InlineAutoData("FIND {Joe Smith}")]
        [InlineAutoData("FIND {Joe Smith} IN Name Fields RETURNING lead")]
        [InlineAutoData("FIND {Joe Smith} IN Name Fields RETURNING lead (name, phone Where createddate = THIS_FISCAL_QUARTER)")]
        [InlineAutoData("FIND {\"Joe Smith\" OR \"Joe Smythe\"} IN Name Fields RETURNING lead")]
        public async Task ISearch(string q, SearchResponse<string> expected)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<ISearch>();
            var result = await api.GetAsync<string>(q);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{Api.Version}/search?q=", q);
        }

        [Theory, AutoData]
        public async Task ISearch_ApiVersion(string q, SearchResponse<string> expected)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<ISearch>();
            var result = await api.GetAsync<string>(q, CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v44.0/search?q=", q);
        }
    }
}