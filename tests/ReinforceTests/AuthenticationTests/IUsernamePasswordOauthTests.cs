using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Reinforce.Authentication;
using Reinforce.Authentication.Flows;
using Xunit;

namespace ReinforceTests.AuthenticationTests
{
    public class IUsernamePasswordOauthTests
    {
        [Theory, AutoData]
        public async Task IApexRestPost(
            AuthenticationResponse expected,
            string grantType,
            string clientId,
            string clientSecret,
            string username,
            string password
        )
        {
            using(var handler = MockHttpMessageHandler.SetupHandler(expected))
            {
                var api = handler.SetupApi<IUsernamePasswordOauth>();
                var result = await api.PostAsync(
                    grantType,
                    clientId,
                    clientSecret,
                    username,
                    password,
                    CancellationToken.None
                );
                result.Should().BeEquivalentTo(expected);
                var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
                query["grant_type"] = grantType;
                query["client_id"] = clientId;
                query["client_secret"] = clientSecret;
                query["username"] = username;
                query["password"] = password;
                handler.ConfirmPath($"/services/oauth2/token?{query}");
            }
        }
    }
}