using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.BulkApi2;
using Reinforce.Constants;
using Xunit;

namespace ReinforceTests.BulkApi2Tests
{
    public class IGetJobFailedRecordResultsTests
    {
        private const string CSV = "sf__Error,sf__Id,Name,Phone\n"
                                 + "\"Error 1: An error\",fakeid,Test,555-555-5555\n"
                                 + "\"Error 1: An error\",fakeid2,\"AnotherTest\",\"(555) 555-5555\"";

        [Theory, AutoData]
        public async Task IGetJobFailedRecordResults(string jobID)
        {
            using(var handler = MockHttpMessageHandler.SetupRawHandler(CSV))
            {
                var api = handler.SetupApi<IGetJobFailedRecordResults>();
                var result = await api.GetAsync(jobID);
                result.Should().BeEquivalentTo(CSV);
                handler.ConfirmPath($"/services/data/{Api.Version}/jobs/ingest/{jobID}/failedResults");
            }
        }

        [Theory, AutoData]
        public async Task IGetJobFailedRecordResults_ApiVersion(string jobID)
        {
            using(var handler = MockHttpMessageHandler.SetupRawHandler(CSV))
            {
                var api = handler.SetupApi<IGetJobFailedRecordResults>();
                var result = await api.GetAsync(jobID, CancellationToken.None, "v44.0");
                result.Should().BeEquivalentTo(CSV);
                handler.ConfirmPath($"/services/data/v44.0/jobs/ingest/{jobID}/failedResults");
            }
        }
    }
}