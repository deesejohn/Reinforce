using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class IDescribeLayoutsTests
    {
        [Theory, AutoData]
        public async Task IDescribeLayouts(IEnumerable<DescribeLayout> expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IDescribeLayouts>();
                var result = await api.GetAsync(CancellationToken.None);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath("/services/data/v46.0/sobjects/Global/describe/layouts");
            }
        }

        [Theory, AutoData]
        public async Task IDescribeLayoutsBySObjectName(IEnumerable<DescribeLayout> expected, string sObjectName)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IDescribeLayouts>();
                var result = await api.GetAsync(sObjectName, CancellationToken.None);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/describe/layouts");
            }
        }
    }
}