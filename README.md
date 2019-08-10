Reinforce
==================================

### What is Reinforce?

Reinforce is a Rest Interface for Force.com! It utilizes [RestEase](https://github.com/canton7/RestEase) to turn Salesforce's rest api into a dependency injection friendly C# library.

### How do I get started?

The easiest way to get started is by using the Reinforce.HttpClientFactory package that includes IServiceCollection extensions.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddReinforce()
        .UseUsernamePasswordFlow(Configuration.GetSection(nameof(UsernamePasswordSettings)).Get<UsernamePasswordSettings>());
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
    var query = "Select Id, Name From Account".Replace(' ', '+');
    var response = await _query.GetAsync<Account>(query, cancellationToken);
    return response.Records;
}
```

### Do you have an issue?
This project is still a work in progress and any pull requests would be greatly appreciated.
