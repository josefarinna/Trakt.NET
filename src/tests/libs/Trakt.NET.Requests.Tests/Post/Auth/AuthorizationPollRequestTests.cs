#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Auth
{
    public sealed class AuthorizationPollRequestTests
    {
        private const string URIPath = "oauth/device/token";

        [Fact]
        public void TestAuthorizationPollRequestHasValidURIPath()
        {
            var authorizationPollRequest = new AuthorizationPollRequest
            {
                TraktAuthorizationPollPost = new TraktAuthorizationPollPost()
            };

            authorizationPollRequest.BuildUri();
            authorizationPollRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestAuthorizationPollRequestHasValidOAuthRequirement()
        {
            var authorizationPollRequest = new AuthorizationPollRequest { TraktAuthorizationPollPost = default! };
            authorizationPollRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestAuthorizationPollRequestIsPostRequest()
        {
            var authorizationPollRequest = new AuthorizationPollRequest { TraktAuthorizationPollPost = default! };
            authorizationPollRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestAuthorizationPollRequestHasCorrectRequestObjectType()
        {
            var authorizationPollRequest = new AuthorizationPollRequest { TraktAuthorizationPollPost = default! };
            authorizationPollRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestAuthorizationPollRequestValidate()
        {
            var authorizationPollRequest = new AuthorizationPollRequest { TraktAuthorizationPollPost = default! };
            Action act = () => authorizationPollRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}

