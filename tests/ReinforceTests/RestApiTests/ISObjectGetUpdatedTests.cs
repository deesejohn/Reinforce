using System;
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
    public class ISObjectGetUpdatedTests
    {
        [Theory, AutoData]
        public async Task ISObjectGetUpdated(SObjectGetUpdatedResponse expected, string sObjectName)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ISObjectGetUpdated>();
                var result = await api.GetAsync(sObjectName);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/sobjects/{sObjectName}/updated");
            }
        }

        [Theory, AutoData]
        public async Task ISObjectGetUpdatedEnd(SObjectGetUpdatedResponse expected, string sObjectName, DateTimeOffset endDateAndTime)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ISObjectGetUpdated>();
                var result = await api.GetAsync(sObjectName, endDateAndTime: endDateAndTime);
                result.Should().BeEquivalentTo(expected);
                var end = Uri.EscapeDataString(endDateAndTime.ToString("yyyy-MM-ddTHH:mm:ss+00:00"));
                handler.ConfirmPath($"/services/data/{Api.Version}/sobjects/{sObjectName}/updated?end={end}");
            }
        }

        [Theory, AutoData]
        public async Task ISObjectGetUpdatedStart(SObjectGetUpdatedResponse expected, string sObjectName, DateTimeOffset startDateAndTime)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ISObjectGetUpdated>();
                var result = await api.GetAsync(sObjectName, startDateAndTime);
                result.Should().BeEquivalentTo(expected);
                var start = Uri.EscapeDataString(startDateAndTime.ToString("yyyy-MM-ddTHH:mm:ss+00:00"));
                handler.ConfirmPath($"/services/data/{Api.Version}/sobjects/{sObjectName}/updated?start={start}");
            }
        }

        [Theory, AutoData]
        public async Task ISObjectGetUpdatedStartAndEnd(SObjectGetUpdatedResponse expected, string sObjectName, DateTimeOffset startDateAndTime, DateTimeOffset endDateAndTime)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ISObjectGetUpdated>();
                var result = await api.GetAsync(sObjectName, startDateAndTime, endDateAndTime, CancellationToken.None, "v44.0");
                result.Should().BeEquivalentTo(expected);
                var start = Uri.EscapeDataString(startDateAndTime.ToString("yyyy-MM-ddTHH:mm:ss+00:00"));
                var end = Uri.EscapeDataString(endDateAndTime.ToString("yyyy-MM-ddTHH:mm:ss+00:00"));
                handler.ConfirmPath($"/services/data/v44.0/sobjects/{sObjectName}/updated?start={start}&end={end}");
            }
        }
    }
}