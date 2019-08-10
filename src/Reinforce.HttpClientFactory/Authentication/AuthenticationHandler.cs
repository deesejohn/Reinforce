using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Reinforce.HttpClientFactory.Authentication
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly IAuthenticationProvider _authenticationProvider;

        public AuthenticationHandler(IAuthenticationProvider authenticationProvider)
        {
            _authenticationProvider = authenticationProvider ?? throw new ArgumentNullException(nameof(authenticationProvider));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // See if the request has an authorize header
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                var response = await _authenticationProvider.GetAsync(cancellationToken).ConfigureAwait(false);
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, response.AccessToken);
                request.RequestUri = new Uri(
                    baseUri: new Uri(response.InstanceUrl),
                    relativeUri: request.RequestUri.PathAndQuery
                );
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}