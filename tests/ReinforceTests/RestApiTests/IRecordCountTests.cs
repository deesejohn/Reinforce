using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Constants;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class IRecordCountTests
    {
        [Theory, AutoData]
        public async Task IRecordCount(RecordCountResponse expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IRecordCount>();
                var result = await api.GetAsync();
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/limits/recordCount");
            }            
        }

        [Theory, AutoData]
        public async Task IRecordCount_SObjects(RecordCountResponse expected)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IRecordCount>();
                var sobjects = "Account,Contacts";
                var result = await api.GetAsync(sobjects, CancellationToken.None, "v44.0");
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v44.0/limits/recordCount?sObjects={Uri.EscapeDataString(sobjects)}");
            }            
        }
    }
}