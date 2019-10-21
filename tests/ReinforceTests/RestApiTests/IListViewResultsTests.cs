using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.Constants;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class IListViewResultsTests
    {
        [Theory, AutoData]
        public async Task IListViewResults(ListViewResultsResponse expected, string sobjectType, string listViewID)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IListViewResults>();
            var result = await api.GetAsync(sobjectType, listViewID);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{Api.Version}/sobjects/{sobjectType}/listviews/{listViewID}/results");
        }

        [Theory, AutoData]
        public async Task IListViewResults_Args(ListViewResultsResponse expected, string sobjectType, string listViewID, int? limit, int? offset)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IListViewResults>();
            var result = await api.GetAsync(sobjectType, listViewID, limit, offset, CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v44.0/sobjects/{sobjectType}/listviews/{listViewID}/results?limit={limit}&offset={offset}");
        }
    }
}