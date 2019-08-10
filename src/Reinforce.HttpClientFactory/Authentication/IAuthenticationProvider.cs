using System.Threading;
using System.Threading.Tasks;
using Reinforce.Authentication;

namespace Reinforce.HttpClientFactory.Authentication
{
    public interface IAuthenticationProvider
    {
        Task<AuthenticationResponse> GetAsync(CancellationToken cancellationToken);
    }
}