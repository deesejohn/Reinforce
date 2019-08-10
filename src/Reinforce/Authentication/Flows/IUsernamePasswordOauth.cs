using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Reinforce.Authentication.Flows
{
    public interface IUsernamePasswordOauth
    {
        [Post("/services/oauth2/token")]
        Task<AuthenticationResponse> PostAsync(
            [AliasAs("grant_type")] string grantType,
            [AliasAs("client_id")] string clientId,
            [AliasAs("client_secret")] string clientSecret,
            [AliasAs("username")] string username,
            [AliasAs("password")] string password,
            CancellationToken cancellationToken
        );
    }
}