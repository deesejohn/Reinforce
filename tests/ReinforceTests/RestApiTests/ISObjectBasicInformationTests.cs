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
    public class ISObjectBasicInformationTests
    {
        [Theory, AutoData]
        public async Task ISObjectBasicInformation(SObjectBasicInformationResponse expected, string sObjectName)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ISObjectBasicInformation>();
                var result = await api.GetAsync(sObjectName, CancellationToken.None, "v44.0");
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v44.0/sobjects/{sObjectName}");
            }
        }

        [Theory, AutoData]
        public async Task ISObjectBasicInformationPost(SuccessResponse expected, string sObjectName, IDictionary<string, string> sObject)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ISObjectBasicInformation>();
                var result = await api.PostAsync(sObjectName, sObject, CancellationToken.None, "v44.0");
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v44.0/sobjects/{sObjectName}");
            }            
        }
    }
}