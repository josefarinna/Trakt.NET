#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Auth
{
    public sealed class AuthorizationRevokeRequestTests
    {
        private const string URIPath = "oauth/revoke";

        [Fact]
        public void TestAuthorizationRevokeRequestHasValidURIPath()
        {
            var authorizationRevokeRequest = new AuthorizationRevokeRequest
            {
                TraktAuthorizationRevokePost = new TraktAuthorizationRevokePost()
            };

            authorizationRevokeRequest.BuildUri();
            authorizationRevokeRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestAuthorizationRevokeRequestHasValidOAuthRequirement()
        {
            var authorizationRevokeRequest = new AuthorizationRevokeRequest { TraktAuthorizationRevokePost = default! };
            authorizationRevokeRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestAuthorizationRevokeRequestIsPostRequest()
        {
            var authorizationRevokeRequest = new AuthorizationRevokeRequest { TraktAuthorizationRevokePost = default! };
            authorizationRevokeRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestAuthorizationRevokeRequestHasCorrectRequestObjectType()
        {
            var authorizationRevokeRequest = new AuthorizationRevokeRequest { TraktAuthorizationRevokePost = default! };
            authorizationRevokeRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestAuthorizationRevokeRequestValidate()
        {
            var authorizationRevokeRequest = new AuthorizationRevokeRequest { TraktAuthorizationRevokePost = default! };
            Action act = () => authorizationRevokeRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}

