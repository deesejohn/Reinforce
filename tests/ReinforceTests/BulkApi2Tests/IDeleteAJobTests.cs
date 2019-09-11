using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Reinforce.BulkApi2;
using Reinforce.Constants;
using Xunit;

namespace ReinforceTests.BulkApi2Tests
{
    public class IDeleteAJobTests
    {
        [Theory, AutoData]
        public async Task IDeleteAJob(string jobID)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(null))
            {
                var api = handler.SetupApi<IDeleteAJob>();
                await api.DeleteAsync(jobID);
                handler.ConfirmPath($"/services/data/{Api.Version}/jobs/ingest/{jobID}");
            }
        }
    }
}