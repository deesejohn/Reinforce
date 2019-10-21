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
    public class IQuickActionsTests
    {
        [Theory, AutoData]
        public async Task IQuickActions(IEnumerable<QuickAction> expected)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IQuickActions>();
            var result = await api.GetAsync();
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{Api.Version}/quickActions");
        }

        [Theory, AutoData]
        public async Task IQuickActionsPost(string expected, string actionName)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IQuickActions>();
            await api.PostAsync(actionName, expected, CancellationToken.None, "v44.0");
            handler.ConfirmPath($"/services/data/v44.0/quickActions/{actionName}");
        }
    }
}