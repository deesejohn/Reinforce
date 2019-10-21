using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.BulkApi2;
using Reinforce.Constants;
using Xunit;

namespace ReinforceTests.BulkApi2Tests
{
    public class IGetJobUnprocessedRecordResultsTests
    {
        private const string CSV = "Name,Phone\nTest,555-555-5555\n\"AnotherTest\",\"(555) 555-5555\"";

        [Theory, AutoData]
        public async Task IGetJobUnprocessedRecordResults(string jobID)
        {
            using var handler = MockHttpMessageHandler.SetupRawHandler(CSV);
            var api = handler.SetupApi<IGetJobUnprocessedRecordResults>();
            var result = await api.GetAsync(jobID);
            result.Should().BeEquivalentTo(CSV);
            handler.ConfirmPath($"/services/data/{Api.Version}/jobs/ingest/{jobID}/unprocessedrecords");
        }

        [Theory, AutoData]
        public async Task IGetJobUnprocessedRecordResults_ApiVersion(string jobID)
        {
            using var handler = MockHttpMessageHandler.SetupRawHandler(CSV);
            var api = handler.SetupApi<IGetJobUnprocessedRecordResults>();
            var result = await api.GetAsync(jobID, CancellationToken.None, "v44.0");
            result.Should().BeEquivalentTo(CSV);
            handler.ConfirmPath($"/services/data/v44.0/jobs/ingest/{jobID}/unprocessedrecords");
        }
    }
}