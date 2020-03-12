using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AccountApi.Models;
using Reinforce.RestApi.Models;

namespace AccountApi.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> ReadAsync(CancellationToken cancellationToken);
        Task<Account> ReadAsync(string id, CancellationToken cancellationToken);
        Task UpdateAsync(string id, AccountUpdate account, CancellationToken cancellationToken);
        Task UpdateAsync(IEnumerable<Account> accounts, CancellationToken cancellationToken);
        Task<IEnumerable<Account>> GetCompositeAsync(IEnumerable<string> ids, CancellationToken cancellationToken);
    }
}