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
    public class IGetAllJobsTests
    {
        [Theory, AutoData]
        public async Task IGetAllJobs(GetAllJobsResponse expected)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IGetAllJobs>();
            var result = await api.GetAsync();
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{Api.Version}/jobs/ingest");
        }

        [Theory, AutoData]
        public async Task IGetAllJobs_ApiVersion(GetAllJobsResponse expected, bool? isPkChunkingEnabled, JobTypeEnum? jobType, string queryLocator)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<IGetAllJobs>();
            var result = await api.GetAsync(isPkChunkingEnabled, jobType, queryLocator, CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/v44.0/jobs/ingest?isPkChunkingEnabled={isPkChunkingEnabled}&jobType={jobType}&queryLocator={queryLocator}");
        }
    }
}