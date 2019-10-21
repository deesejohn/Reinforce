using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class IListViewsTests
    {
        [Theory, AutoData]
        public async Task IListViews(ListViewsResponse expected, string sobjectType)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IListViews>();
            var result = await api.GetAsync(sobjectType, CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v44.0/sobjects/{sobjectType}/listviews");
        }

        [Theory, AutoData]
        public async Task IListViewsByListViewID(ListView expected, string sobjectType, string listViewID)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IListViews>();
            var result = await api.GetAsync(sobjectType, listViewID, CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v44.0/sobjects/{sobjectType}/listviews/{listViewID}");
        }
    }
}