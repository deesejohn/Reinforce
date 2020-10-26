using System;
using Microsoft.Extensions.DependencyInjection;

namespace Reinforce.HttpClientFactory
{
    public class ReinforceBuilder : IReinforceBuilder
    {
        private IHttpClientBuilder ApiClientBuilder { get; }
        public IServiceCollection Services => ApiClientBuilder.Services;

        public ReinforceBuilder(IHttpClientBuilder builder)
        {
            ApiClientBuilder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IReinforceBuilder ConfigureApiClient(Action<IHttpClientBuilder> builder)
        {
            builder(ApiClientBuilder);
            return this;
        }
    }
}