using System;
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
    public class IInvocableActionsTests
    {
        [Theory, AutoData]
        public async Task IInvocableActions(IDictionary<string, string> expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IInvocableActions>();
                var result = await api.GetAsync();
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/actions");
            }            
        }

        [Theory, AutoData]
        public async Task IInvocableActions_GetCustomAsync(IDictionary<string, string> expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IInvocableActions>();
                var result = await api.GetCustomAsync();
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/actions/custom");
            }            
        }

        [Theory, AutoData]
        public async Task IInvocableActions_GetCustomAsync_Type(ActionsResponse expected, string type)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IInvocableActions>();
                var result = await api.GetCustomAsync(type);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/actions/custom/{type}");
            }            
        }

        [Theory, AutoData]
        public async Task IInvocableActions_GetCustomAsync_Type_Action(InvocableAction expected, string type, string action)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IInvocableActions>();
                var result = await api.GetCustomAsync(type, action);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/actions/custom/{type}/{action}");
            }            
        }

        [Theory, AutoData]
        public async Task IInvocableActions_PostCustomAsync(InvokedActionResponse<string> expected, string body)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IInvocableActions>();
                var route = "/quickAction/feeditem/NewTaskFromFeedItem";
                var result = await api.PostCustomAsync<string, string>(route, body);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/actions/custom/{route}");
            }            
        }

        [Theory, AutoData]
        public async Task IInvocableActions_GetStandardAsync(ActionsResponse expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IInvocableActions>();
                var result = await api.GetStandardAsync();
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/actions/standard");
            }            
        }

        [Theory, AutoData]
        public async Task IInvocableActions_GetStandardAsync_Action(InvocableAction expected, string action)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IInvocableActions>();
                var result = await api.GetStandardAsync(action);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/actions/standard/{action}");
            }            
        }

        [Theory, AutoData]
        public async Task IInvocableActions_PostStandardAsync(InvokedActionResponse<string> expected, string action, string body)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IInvocableActions>();
                var result = await api.PostStandardAsync<string, string>(action, body);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/actions/standard/{action}");
            }            
        }
    }
}