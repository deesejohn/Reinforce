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
    public class IListViewDescribeTests
    {
        [Theory, AutoData]
        public async Task IListViewDescribe(ListViewDescribeResponse expected, string sobjectType, string queryLocator)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IListViewDescribe>();
            var result = await api.GetAsync(sobjectType, queryLocator);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{Api.Version}/sobjects/{sobjectType}/listviews/{queryLocator}/describe");
        }

        [Theory, AutoData]
        public async Task IListViewDescribe_ApiVersion(ListViewDescribeResponse expected, string sobjectType, string queryLocator)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IListViewDescribe>();
            var result = await api.GetAsync(sobjectType, queryLocator, CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v44.0/sobjects/{sobjectType}/listviews/{queryLocator}/describe");
        }
    }
}