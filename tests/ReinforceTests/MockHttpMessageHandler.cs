using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using RestEase;

namespace ReinforceTests
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        public HttpRequestMessage Request { get; private set; }
        public Task<HttpResponseMessage> ResponseMessage { get; }

        public MockHttpMessageHandler(HttpResponseMessage responseMessage)
        {
            ResponseMessage = Task.FromResult(responseMessage);
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            Request = request;
            return ResponseMessage;
        }

        public void ConfirmPath(string path)
        {
            Request.RequestUri.PathAndQuery.Should().Be(path);
        }

        public TApi SetupApi<TApi>()
        {
            var client = new HttpClient(this)
            {
                BaseAddress = new Uri("https://localhost")
            };
            return new RestClient(client).For<TApi>();
        }

        public static MockHttpMessageHandler SetupHandler(object response)
        {
            return new MockHttpMessageHandler(new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(response)),
            });
        }

        public static MockHttpMessageHandler SetupRawHandler(string content)
        {
            return new MockHttpMessageHandler(new HttpResponseMessage()
            {
                Content = new StringContent(content),
            });
        }
    }
}