using System.Threading;
using System.Threading.Tasks;
using RestEase;

namespace Reinforce.Authentication.Flows
{
    public interface IUsernamePasswordOauth
    {
        [Post("/services/oauth2/token")]
        Task<AuthenticationResponse> PostAsync(
            [Query("grant_type")] string grantType,
            [Query("client_id")] string clientId,
            [Query("client_secret")] string clientSecret,
            [Query("username")] string username,
            [Query("password")] string password,
            CancellationToken cancellationToken
        );
    }
}