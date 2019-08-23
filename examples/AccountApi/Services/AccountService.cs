using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;
using AccountApi.Models;
using RestEase;
using Reinforce.RestApi;
using System.Collections.Generic;

namespace AccountApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly ISObjectRows _sObjectRows;
        private readonly IQuery _query;

        public AccountService(ISObjectRows sObjectRows, IQuery query)
        {
            _sObjectRows = sObjectRows ?? throw new ArgumentNullException(nameof(sObjectRows));
            _query = query ?? throw new ArgumentNullException(nameof(query));
        }

        public async Task<IEnumerable<Account>> ReadAsync(CancellationToken cancellationToken)
        {
            var response = await _query.GetAsync<Account>("Select Id, Name From Account", cancellationToken);
            return response.Records;
        }

        public async Task<Account> ReadAsync(string id, CancellationToken cancellationToken)
        {
            try
            {
                return await _sObjectRows.GetAsync<Account>(nameof(Account), id, cancellationToken);
            }
            catch (ApiException exception) when (exception.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public Task UpdateAsync(string id, AccountUpdate account, CancellationToken cancellationToken)
        {
            return _sObjectRows.PatchAsync(nameof(Account), id, account, cancellationToken);
        }
    }
}