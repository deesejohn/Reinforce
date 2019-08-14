using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Reinforce.RestApi.Models;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class ISObjectApprovalLayoutsTests
    {
        [Theory, AutoData]
        public async Task ISObjectApprovalLayouts(ApprovalLayoutsResponse expected, string sObjectName)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ISObjectApprovalLayouts>();
                var result = await api.GetAsync(sObjectName, CancellationToken.None);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/describe/approvalLayouts");
            }
        }

        [Theory, AutoData]
        public async Task ISObjectApprovalLayoutsByApprovalProcessName(ApprovalLayoutsResponse expected, string sObjectName, string approvalProcessName)
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<ISObjectApprovalLayouts>();
                var result = await api.GetAsync(sObjectName, approvalProcessName, CancellationToken.None);
                result.Should().BeEquivalentTo(expected);
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/describe/approvalLayouts/{approvalProcessName}");
            }
        }
    }
}