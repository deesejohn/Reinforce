using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class IQueryTests
    {
        [Theory]
        [InlineAutoData("Select Id, Name From Account")]
        [InlineAutoData("Select Id, Name From Account Where Active__c = 'Yes' and Name like %Test%")]
        [InlineAutoData("Select Id, Name From Account Where Active__c = 'Yes' Limit 10")]
        public async Task IQuery_Explain(string q, ExplainResponse expected)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IQuery>();
            var result = await api.GetAsync(q, CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath("/services/data/v44.0/query?explain=", q);
        }

        [Theory]
        [InlineAutoData("Select Id, Name From Account")]
        [InlineAutoData("Select Id, Name From Account Where Active__c = 'Yes' and Name like %Test%")]
        [InlineAutoData("Select Id, Name From Account Where Active__c = 'Yes' Limit 10")]
        public async Task IQuery_Query(string q, QueryResponse<string> expected)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IQuery>();
            var result = await api.GetAsync<string>(q, CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath("/services/data/v44.0/query?q=", q);
        }
    }
}