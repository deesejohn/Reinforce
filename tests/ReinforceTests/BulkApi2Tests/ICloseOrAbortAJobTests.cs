using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.BulkApi2;
using Reinforce.BulkApi2.Models;
using Reinforce.Constants;
using Xunit;

namespace ReinforceTests.BulkApi2Tests
{
    public class ICloseOrAbortAJobTests
    {
        [Theory, AutoData]
        public async Task ICloseOrAbortAJob(JobInfo expected, string jobID, CloseOrAbortAJobRequest body)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(expected);
            var api = handler.SetupApi<ICloseOrAbortAJob>();
            var result = await api.PatchAsync(jobID, body);
            result.Should().BeEquivalentTo(expected);
            handler.ConfirmPath($"/services/data/{Api.Version}/jobs/ingest/{jobID}");
        }
    }
}