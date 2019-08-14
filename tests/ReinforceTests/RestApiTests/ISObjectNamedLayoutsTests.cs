using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Reinforce.RestApi;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class ISObjectNamedLayoutsTests
    {
        [Theory, AutoData]
        public async Task ISObjectNamedLayouts(string sObjectName, string layoutName)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(null))
            {
                var api = handler.SetupApi<ISObjectNamedLayouts>();
                await api.GetAsync(sObjectName, layoutName);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/describe/namedLayouts/{layoutName}");
            }
        }
    }
}