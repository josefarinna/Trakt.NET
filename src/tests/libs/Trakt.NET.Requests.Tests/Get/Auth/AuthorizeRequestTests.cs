#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Auth
{
    public sealed class AuthorizeRequestTests
    {
        private const string URIPath = "oauth/authorize/123?response_type=123&client_id=123&redirect_uri=123";

        [Fact]
        public void TestAuthorizeRequestHasValidURIPath()
        {
            var authorizeRequest = new AuthorizeRequest
            {
                ResponseType = "123",
                ClientId = "123",
                RedirectUri = "123",
                Prompt = "123"
            };

            authorizeRequest.BuildUri();
            authorizeRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestAuthorizeRequestHasValidOAuthRequirement()
        {
            var authorizeRequest = new AuthorizeRequest { ResponseType = default!, ClientId = default!, RedirectUri = default! };
            authorizeRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestAuthorizeRequestIsGetRequest()
        {
            var authorizeRequest = new AuthorizeRequest { ResponseType = default!, ClientId = default!, RedirectUri = default! };
            authorizeRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestAuthorizeRequestHasCorrectRequestObjectType()
        {
            var authorizeRequest = new AuthorizeRequest { ResponseType = default!, ClientId = default!, RedirectUri = default! };
            authorizeRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestAuthorizeRequestValidate()
        {
            var authorizeRequest = new AuthorizeRequest { ResponseType = default!, ClientId = default!, RedirectUri = default! };
            Action act = () => authorizeRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
