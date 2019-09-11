using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.BulkApi2;
using Reinforce.BulkApi2.Models;
using Reinforce.Constants;
using Xunit;

namespace ReinforceTests.BulkApi2Tests
{
    public class ICreateAJobTests
    {
        [Theory, AutoData]
        public async Task ICreateAJob(JobInfo expected, CreateAJobRequest body)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ICreateAJob>();
                var result = await api.PostAsync(body);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/{Api.Version}/jobs/ingest");
            }
        }

        [Theory, AutoData]
        public async Task ICreateAJob_ApiVersion(JobInfo expected, CreateAJobRequest body)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ICreateAJob>();
                var result = await api.PostAsync(body, CancellationToken.None, "v44.0");
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v44.0/jobs/ingest");
            }
        }
    }
}