using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Reinforce.BulkApi2;
using Reinforce.Constants;
using Xunit;

namespace ReinforceTests.BulkApi2Tests
{
    public class IUploadJobDataTests
    {
        private const string CSV = "Name,Phone\nTest,555-555-5555\n\"AnotherTest\",\"(555) 555-5555\"";

        [Theory, AutoData]
        public async Task IUploadJobData(string jobID)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(null))
            {
                var api = handler.SetupApi<IUploadJobData>();
                await api.PutAsync(jobID, Encoding.ASCII.GetBytes(CSV));
                handler.ConfirmPath($"/services/data/{Api.Version}/jobs/ingest/{jobID}/batches");
            }
        }

        [Theory, AutoData]
        public async Task IUploadJobData_ApiVersion(string jobID)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(null))
            {
                var api = handler.SetupApi<IUploadJobData>();
                await api.PutAsync(jobID, Encoding.ASCII.GetBytes(CSV), CancellationToken.None, "v44.0");
                handler.ConfirmPath($"/services/data/v44.0/jobs/ingest/{jobID}/batches");
            }
        }
    }
}