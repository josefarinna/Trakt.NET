#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Auth
{
    public sealed class AuthorizationRefreshRequestTests
    {
        private const string URIPath = "oauth/token";

        [Fact]
        public void TestAuthorizationRefreshRequestHasValidURIPath()
        {
            var authorizationRefreshRequest = new AuthorizationRefreshRequest
            {
                TraktAuthorizationRefreshPost = new TraktAuthorizationRefreshPost()
            };

            authorizationRefreshRequest.BuildUri();
            authorizationRefreshRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestAuthorizationRefreshRequestHasValidOAuthRequirement()
        {
            var authorizationRefreshRequest = new AuthorizationRefreshRequest { TraktAuthorizationRefreshPost = default! };
            authorizationRefreshRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestAuthorizationRefreshRequestIsPostRequest()
        {
            var authorizationRefreshRequest = new AuthorizationRefreshRequest { TraktAuthorizationRefreshPost = default! };
            authorizationRefreshRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestAuthorizationRefreshRequestHasCorrectRequestObjectType()
        {
            var authorizationRefreshRequest = new AuthorizationRefreshRequest { TraktAuthorizationRefreshPost = default! };
            authorizationRefreshRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestAuthorizationRefreshRequestValidate()
        {
            var authorizationRefreshRequest = new AuthorizationRefreshRequest { TraktAuthorizationRefreshPost = default! };
            Action act = () => authorizationRefreshRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}

