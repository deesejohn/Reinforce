using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Reinforce.RestApi;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class ISObjectBlobRetrieveTests
    {
        [Theory, AutoData]
        public async Task ISObjectBlobRetrieve(string sObjectName, string id, string blobField)
        {
            using var handler = MockHttpMessageHandler.SetupHandler(null);
            var api = handler.SetupApi<ISObjectBlobRetrieve>();
            await api.GetAsync(sObjectName, id, blobField, CancellationToken.None, "v44.0");
            handler.ConfirmPath($"/services/data/v44.0/sobjects/{sObjectName}/{id}/{blobField}");
        }
    }
}