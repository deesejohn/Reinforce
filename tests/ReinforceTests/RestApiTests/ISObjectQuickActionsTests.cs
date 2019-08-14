using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class ISObjectQuickActionsTests
    {
        [Theory, AutoData]
        public async Task ISObjectQuickActions(IEnumerable<QuickAction> expected, string sObjectName)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ISObjectQuickActions>();
                var result = await api.GetAsync(sObjectName);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/quickActions");
            }
        }

        [Theory, AutoData]
        public async Task ISObjectQuickActionsByActionName(string sObjectName, string actionName)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(null))
            {
                var api = handler.SetupApi<ISObjectQuickActions>();
                await api.GetAsync(sObjectName, actionName);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/quickActions/{actionName}");
            }
        }

        [Theory, AutoData]
        public async Task ISObjectQuickActionsPostByActionName(string sObjectName, string actionName, QuickAction action)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(null))
            {
                var api = handler.SetupApi<ISObjectQuickActions>();
                await api.PostAsync(sObjectName, actionName, action);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/quickActions/{actionName}");
            }
        }

        [Theory, AutoData]
        public async Task ISObjectQuickActionsDescribe(string sObjectName, string actionName)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(null))
            {
                var api = handler.SetupApi<ISObjectQuickActions>();
                await api.DescribeAsync(sObjectName, actionName);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/quickActions/{actionName}/describe");
            }
        }

        [Theory, AutoData]
        public async Task ISObjectQuickActionsDefaultValues(string sObjectName, string actionName)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(null))
            {
                var api = handler.SetupApi<ISObjectQuickActions>();
                await api.DefaultValuesAsync(sObjectName, actionName);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/quickActions/{actionName}/defaultValues");
            }
        }

        [Theory, AutoData]
        public async Task ISObjectQuickActionsDefaultValuesByContextId(string sObjectName, string actionName, string contextId)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(null))
            {
                var api = handler.SetupApi<ISObjectQuickActions>();
                await api.DefaultValuesAsync(sObjectName, actionName, contextId);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/quickActions/{actionName}/defaultValues/{contextId}");
            }
        }
    }
}