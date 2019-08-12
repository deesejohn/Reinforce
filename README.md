Reinforce
==================================
[![Build Status](https://dev.azure.com/deesejohn/Reinforce/_apis/build/status/deesejohn.Reinforce?branchName=master)](https://dev.azure.com/deesejohn/Reinforce/_build/latest?definitionId=1&branchName=master)
[![GitHub license](https://img.shields.io/github/license/deesejohn/Reinforce)](https://github.com/deesejohn/Reinforce/blob/master/LICENSE)
[![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/deesejohn/reinforce)](https://www.codefactor.io/repository/github/deesejohn/reinforce)
[![NuGet](https://img.shields.io/nuget/v/Reinforce.svg?label=Reinforce&logo=nuget)](https://www.nuget.org/packages/Reinforce/)
[![NuGet](https://img.shields.io/nuget/v/Reinforce.HttpClientFactory.svg?label=Reinforce.HttpClientFactory&logo=nuget)](https://www.nuget.org/packages/Reinforce.HttpClientFactory/)

### What is Reinforce?

Reinforce is a Rest Interface for Force.com! It utilizes [RestEase](https://github.com/canton7/RestEase) to turn Salesforce's rest api into a dependency injection friendly C# library.

### How do I get started?

The easiest way to get started is by using the Reinforce.HttpClientFactory package that includes IServiceCollection extensions.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddReinforce()
        .UseUsernamePasswordFlow(
            Configuration.GetSection(nameof(UsernamePasswordSettings)).Get<UsernamePasswordSettings>()
        );
}
```
Then in your application code, inject the api:

```csharp
private readonly IQuery _query;

public AccountService(IQuery query)
{
    _query = query ?? throw new ArgumentNullException(nameof(query));
}

public async Task<IEnumerable<Account>> ReadAsync(CancellationToken cancellationToken)
{
    var response = await _query.GetAsync<Account>("Select Id, Name From Account", cancellationToken);
    return response.Records;
}
```

### Do you have an issue?
This project is still a work in progress and any pull requests would be greatly appreciated.
