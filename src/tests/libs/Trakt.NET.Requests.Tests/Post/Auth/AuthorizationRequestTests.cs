#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Auth
{
    public sealed class AuthorizationRequestTests
    {
        private const string URIPath = "oauth/token";

        [Fact]
        public void TestAuthorizationRequestHasValidURIPath()
        {
            var authorizationRequest = new AuthorizationRequest
            {
                TraktAuthorizationPost = new TraktAuthorizationPost()
            };

            authorizationRequest.BuildUri();
            authorizationRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestAuthorizationRequestHasValidOAuthRequirement()
        {
            var authorizationRequest = new AuthorizationRequest { TraktAuthorizationPost = default! };
            authorizationRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestAuthorizationRequestIsPostRequest()
        {
            var authorizationRequest = new AuthorizationRequest { TraktAuthorizationPost = default! };
            authorizationRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestAuthorizationRequestHasCorrectRequestObjectType()
        {
            var authorizationRequest = new AuthorizationRequest { TraktAuthorizationPost = default! };
            authorizationRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestAuthorizationRequestValidate()
        {
            var authorizationRequest = new AuthorizationRequest { TraktAuthorizationPost = default! };
            Action act = () => authorizationRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}

