using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.BulkApi2;
using Reinforce.Constants;
using Xunit;

namespace ReinforceTests.BulkApi2Tests
{
    public class IGetJobSuccessfulRecordResultsTests
    {
        private const string CSV = "sf__Created,sf__Id,Name,Phone\ntrue,fakeid,Test,555-555-5555\ntrue,fakeid2,\"AnotherTest\",\"(555) 555-5555\"";

        [Theory, AutoData]
        public async Task IGetJobSuccessfulRecordResults(string jobID)
        {
            using(var handler = MockHttpMessageHandler.SetupRawHandler(CSV))
            {
                var api = handler.SetupApi<IGetJobSuccessfulRecordResults>();
                var result = await api.GetAsync(jobID);
                result.Should().BeEquivalentTo(CSV);
                handler.ConfirmPath($"/services/data/{Api.Version}/jobs/ingest/{jobID}/successfulResults");
            }
        }

        [Theory, AutoData]
        public async Task IGetJobSuccessfulRecordResults_ApiVersion(string jobID)
        {
            using(var handler = MockHttpMessageHandler.SetupRawHandler(CSV))
            {
                var api = handler.SetupApi<IGetJobSuccessfulRecordResults>();
                var result = await api.GetAsync(jobID, CancellationToken.None, "v44.0");
                result.Should().BeEquivalentTo(CSV);
                handler.ConfirmPath($"/services/data/v44.0/jobs/ingest/{jobID}/successfulResults");
            }
        }
    }
}