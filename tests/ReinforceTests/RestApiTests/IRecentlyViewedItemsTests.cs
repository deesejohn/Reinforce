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
    public class IRecentlyViewedItemsTests
    {
        [Theory, AutoData]
        public async Task IRecentlyViewedItems(IEnumerable<RecentlyViewedItem> expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IRecentlyViewedItems>();
                var result = await api.GetAsync();
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/recent");
            }            
        }

        [Theory, AutoData]
        public async Task IRecentlyViewedItems_Limit(IEnumerable<RecentlyViewedItem> expected, int? limit)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IRecentlyViewedItems>();
                var result = await api.GetAsync(limit, CancellationToken.None, "v44.0");
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v44.0/recent?limit={limit}");
            }            
        }
    }
}