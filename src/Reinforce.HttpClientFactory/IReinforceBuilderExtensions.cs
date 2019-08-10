using System;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Reinforce.Authentication.Flows;
using Reinforce.HttpClientFactory.Authentication;
using RestEase;

namespace Reinforce.HttpClientFactory
{
    public static class IReinforceBuilderExtensions
    {
        public static IHttpClientBuilder UseUsernamePasswordFlow(
            this IReinforceBuilder builder,
            UsernamePasswordSettings settings,
            Uri authenticationUri = null
        ) => builder
                .Services
                .AddMemoryCache()
                .AddSingleton(_ => settings)
                .AddTransient<IAuthenticationProvider, UsernamePassword>()
                .AddHttpClient(nameof(IUsernamePasswordOauth))
                .ConfigureHttpClient(client => client.BaseAddress = authenticationUri ?? new Uri("https://login.salesforce.com"))
                .AddTypedClient(client => new RestClient(client)
                {
                    JsonSerializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = new SnakeCaseNamingStrategy()
                        }
                    }
                }.For<IUsernamePasswordOauth>());
    }
}