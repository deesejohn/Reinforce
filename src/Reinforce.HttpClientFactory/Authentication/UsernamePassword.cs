using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Reinforce.Authentication;
using Reinforce.Authentication.Flows;

namespace Reinforce.HttpClientFactory.Authentication
{
    public class UsernamePassword : IAuthenticationProvider
    {
        private readonly IMemoryCache _cache;
        private readonly IUsernamePasswordOauth _api;
        private readonly UsernamePasswordSettings _settings;

        public UsernamePassword(IMemoryCache cache, IUsernamePasswordOauth api, UsernamePasswordSettings settings)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _api = api ?? throw new ArgumentNullException(nameof(api));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public Task<AuthenticationResponse> GetAsync(CancellationToken cancellationToken)
        {
            return _cache.GetOrCreateAsync("Reinforce.HttpClientFactory.Authentication.UsernamePassword", entry => 
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
                return _api.PostAsync(
                    _settings.GrantType,
                    _settings.ClientId,
                    _settings.ClientSecret,
                    _settings.Username,
                    _settings.Password,
                    cancellationToken
                );
            });
        }
    }
}