using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class IQueryAllTests
    {
        [Theory, AutoData]
        public async Task IQueryAll(QueryResponse<string> expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var query = "Select Id, Name From Account Where Active__c = 'Yes'";
                var api = handler.SetupApi<IQueryAll>();
                var result = await api.GetAsync<string>(query, CancellationToken.None, "v44.0");
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath("/services/data/v44.0/queryAll?q=Select+Id%2C+Name+From+Account+Where+Active__c+%3D+%27Yes%27");
            }
        }
    }
}