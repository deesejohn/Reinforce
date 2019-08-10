using System;
using Microsoft.Extensions.DependencyInjection;

namespace Reinforce.HttpClientFactory
{
    public interface IReinforceBuilder
    {
        IServiceCollection Services { get; }
    }

    public class ReinforceBuilder : IReinforceBuilder
    {
        public IServiceCollection Services { get; }

        public ReinforceBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }
    }
}