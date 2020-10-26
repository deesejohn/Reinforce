using System;
using Microsoft.Extensions.DependencyInjection;

namespace Reinforce.HttpClientFactory
{
    public interface IReinforceBuilder
    {
        IReinforceBuilder ConfigureApiClient(Action<IHttpClientBuilder> builder);
        IServiceCollection Services { get; }
    }
}