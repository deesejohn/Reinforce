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
        [Theory, AutoData]
        public async Task IQuery_Explain(ExplainResponse expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var query = "Select Id, Name From Account Where Active__c = 'Yes'";
                var api = handler.SetupApi<IQuery>();
                var result = await api.GetAsync(query, CancellationToken.None);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath("/services/data/v46.0/query?explain=Select+Id%2C+Name+From+Account+Where+Active__c+%3D+%27Yes%27");
            }
        }

        [Theory, AutoData]
        public async Task IQuery_Query(QueryResponse<string> expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var query = "Select Id, Name From Account Where Active__c = 'Yes'";
                var api = handler.SetupApi<IQuery>();
                var result = await api.GetAsync<string>(query, CancellationToken.None);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath("/services/data/v46.0/query?q=Select+Id%2C+Name+From+Account+Where+Active__c+%3D+%27Yes%27");
            }
        }
    }
}