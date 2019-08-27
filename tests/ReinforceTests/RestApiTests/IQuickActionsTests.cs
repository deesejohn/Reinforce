using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class IQuickActionsTests
    {
        [Theory, AutoData]
        public async Task IQuickActions(IEnumerable<QuickAction> expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IQuickActions>();
                var result = await api.GetAsync();
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v46.0/quickActions");
            }
        }

        [Theory, AutoData]
        public async Task IQuickActionsPost(string expected, string actionName)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IQuickActions>();
                await api.PostAsync(actionName, expected);
                handler.ConfirmPath($"/services/data/v46.0/quickActions/{actionName}");
            }
        }
    }
}