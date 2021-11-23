# Reinforce

> :warning: **Support ending**: [Salesforce support for OpenAPI 3.0 is coming](https://developer.salesforce.com/blogs/2021/01/learn-moar-with-spring-21-openapi-3-0-spec-for-rest-api) which means tools like [OpenAPI Generator](https://github.com/OpenAPITools/openapi-generator), [NSwag](https://github.com/RicoSuter/NSwag), or [AutoRest](https://github.com/Azure/autorest) will become supporior to this library. :warning:

[![Build Status](https://dev.azure.com/deesejohn/Reinforce/_apis/build/status/deesejohn.Reinforce?branchName=main)](https://dev.azure.com/deesejohn/Reinforce/_build/latest?definitionId=1&branchName=main)
[![GitHub license](https://img.shields.io/github/license/deesejohn/Reinforce)](LICENSE)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=deesejohn_Reinforce&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=deesejohn_Reinforce)
[![NuGet Reinforce](https://img.shields.io/nuget/v/Reinforce.svg?label=Reinforce&logo=nuget)](https://www.nuget.org/packages/Reinforce/)
[![NuGet Reinforce.HttpClientFactory](https://img.shields.io/nuget/v/Reinforce.HttpClientFactory.svg?label=Reinforce.HttpClientFactory&logo=nuget)](https://www.nuget.org/packages/Reinforce.HttpClientFactory/)

## What is Reinforce?

Reinforce is set of Rest Interfaces for Salesforce.com! It utilizes [RestEase](https://github.com/canton7/RestEase) to turn Salesforce's rest api into a dependency injection friendly C# library. Used in pair with `Reinforce.HttpClientFactory`, you can get up and running within a few minutes!

## How do I get started?

### Username Password Flow

The easiest way to get started is by using the `Reinforce.HttpClientFactory` package that includes `IServiceCollection` extensions.

```csharp
public Startup(IConfiguration configuration)
{
    Configuration = configuration;
}

public IConfiguration Configuration { get; }

public void ConfigureServices(IServiceCollection services)
{
    services.AddReinforce()
        .UseUsernamePasswordFlow(Configuration.GetSection(nameof(UsernamePasswordSettings)));
}
```

Setup your configuration.

```sh
> dotnet user-secrets set UsernamePasswordSettings:Username <Username>
> dotnet user-secrets set UsernamePasswordSettings:Password <Password>
> dotnet user-secrets set UsernamePasswordSettings:ClientId <ClientId>
> dotnet user-secrets set UsernamePasswordSettings:ClientSecret <ClientSecret>
```

Then in your application code, inject the api of your choice.

```csharp
private readonly IQuery _query;

public AccountService(IQuery query)
{
    _query = query ?? throw new ArgumentNullException(nameof(query));
}

public async Task<IEnumerable<Account>> ReadAsync(CancellationToken cancellationToken)
{
    var response = await _query.GetAsync<Account>("Select Id, Name From Account", cancellationToken);
    return response.Records ?? Enumerable.Empty<Account>();
}
```

The list of supported APIs can be found in [src/Reinforce](src/Reinforce)

## Do you have an issue?

Please create an issue for any bug you find, including sample code to re-create the issue.

## Contributing

See an issue open that you think you can help with? Please comment on the issue that you plan to contribute it and include unit tests for the included feature when you open a pull request. Don't see an issue for a feature you'd like? Open an issue first and have a discussion before writing any code. This library attempts to be an unopinionated set of interfaces, so many advance helper features, implementations, and/or abstractions may be rejected.
