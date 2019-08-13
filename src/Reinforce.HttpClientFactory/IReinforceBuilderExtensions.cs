using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Reinforce.Authentication.Flows;
using Reinforce.HttpClientFactory.Authentication;
using RestEase;

namespace Reinforce.HttpClientFactory
{
    public static class IReinforceBuilderExtensions
    {
        public static IHttpClientBuilder UseUsernamePasswordFlow(
            this IReinforceBuilder builder,
            Func<IServiceProvider, UsernamePasswordSettings> settingsProvider,
            Uri authenticationUri = null
        ) => builder
                .Services
                .AddTransient(settingsProvider)
                .AddUsernamePasswordFlow(authenticationUri);

        public static IHttpClientBuilder UseUsernamePasswordFlow(
            this IReinforceBuilder builder,
            IConfiguration config,
            Uri authenticationUri = null
        ) => builder
                .Services
                .Configure<UsernamePasswordSettings>(config)
                .AddTransient(
                    provider => provider.GetRequiredService<IOptionsMonitor<UsernamePasswordSettings>>().CurrentValue
                )
                .AddUsernamePasswordFlow(authenticationUri);

        private static IHttpClientBuilder AddUsernamePasswordFlow(
            this IServiceCollection services,
            Uri authenticationUri = null
        ) => services
                .AddMemoryCache()
                .AddTransient<IAuthenticationProvider, UsernamePassword>()
                .AddHttpClient(nameof(IUsernamePasswordOauth))
                .ConfigureHttpClient(
                    client => client.BaseAddress = authenticationUri ?? new Uri("https://login.salesforce.com")
                )
                .AddTypedClient(client => new RestClient(client).For<IUsernamePasswordOauth>());
    }
}