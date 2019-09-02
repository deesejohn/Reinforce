using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.RestApi;
using Xunit;

namespace ReinforceTests.RestApiTests
{
    public class ISObjectRichTextImageRetrieveTests
    {
        [Theory, AutoData]
        public async Task ISObjectQuickActions(
            string sObjectName,
            string id,
            string fieldName,
            string contentReferenceId
        )
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(null))
            {
                var api = handler.SetupApi<ISObjectRichTextImageRetrieve>();
                await api.GetAsync(sObjectName, id, fieldName, contentReferenceId, CancellationToken.None, "v46.0");
                handler.ConfirmPath($"/services/data/v46.0/sobjects/{sObjectName}/{id}/richTextImageFields/{fieldName}/{contentReferenceId}");
            }
        }
    }
}