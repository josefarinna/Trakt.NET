#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Auth
{
    public sealed class AuthorizeRequestTests
    {
        [Fact]
        public void TestAuthorizeRequestHasValidURIPathWithoutOptionalParameters()
        {
            var authorizeRequest = new AuthorizeRequest
            {
                ResponseType = "code",
                ClientId = "client_id_123",
                RedirectUri = "https://example.com/callback"
            };

            authorizeRequest.BuildUri();
            authorizeRequest.RequestUri.ShouldBe(new Uri("oauth/authorize?response_type=code&client_id=client_id_123&redirect_uri=https://example.com/callback", UriKind.Relative));
        }

        [Fact]
        public void TestAuthorizeRequestHasValidURIPathWithState()
        {
            var authorizeRequest = new AuthorizeRequest
            {
                ResponseType = "code",
                ClientId = "client_id_123",
                RedirectUri = "https://example.com/callback",
                State = "state123"
            };

            authorizeRequest.BuildUri();
            authorizeRequest.RequestUri.ShouldBe(new Uri("oauth/authorize?response_type=code&client_id=client_id_123&redirect_uri=https://example.com/callback&state=state123", UriKind.Relative));
        }

        [Fact]
        public void TestAuthorizeRequestHasValidURIPathWithSignup()
        {
            var authorizeRequest = new AuthorizeRequest
            {
                ResponseType = "code",
                ClientId = "client_id_123",
                RedirectUri = "https://example.com/callback",
                Signup = true
            };

            authorizeRequest.BuildUri();
            authorizeRequest.RequestUri.ShouldBe(new Uri("oauth/authorize/true?response_type=code&client_id=client_id_123&redirect_uri=https://example.com/callback", UriKind.Relative));
        }

        [Fact]
        public void TestAuthorizeRequestHasValidURIPathWithPrompt()
        {
            var authorizeRequest = new AuthorizeRequest
            {
                ResponseType = "code",
                ClientId = "client_id_123",
                RedirectUri = "https://example.com/callback",
                Prompt = "login"
            };

            authorizeRequest.BuildUri();
            authorizeRequest.RequestUri.ShouldBe(new Uri("oauth/authorize/login?response_type=code&client_id=client_id_123&redirect_uri=https://example.com/callback", UriKind.Relative));
        }

        [Fact]
        public void TestAuthorizeRequestHasValidURIPathWithAllParameters()
        {
            var authorizeRequest = new AuthorizeRequest
            {
                ResponseType = "code",
                ClientId = "client_id_123",
                RedirectUri = "https://example.com/callback",
                Signup = true,
                Prompt = "login",
                State = "state123"
            };

            authorizeRequest.BuildUri();
            authorizeRequest.RequestUri.ShouldBe(new Uri("oauth/authorize/true/login?response_type=code&client_id=client_id_123&redirect_uri=https://example.com/callback&state=state123", UriKind.Relative));
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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void TestAuthorizeRequestValidateThrowsExceptionWhenResponseTypeIsInvalid(string? responseType)
        {
            var authorizeRequest = new AuthorizeRequest
            {
                ResponseType = responseType!,
                ClientId = "client_id_123",
                RedirectUri = "https://example.com/callback"
            };

            Action act = () => authorizeRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void TestAuthorizeRequestValidateThrowsExceptionWhenClientIdIsInvalid(string? clientId)
        {
            var authorizeRequest = new AuthorizeRequest
            {
                ResponseType = "code",
                ClientId = clientId!,
                RedirectUri = "https://example.com/callback"
            };

            Action act = () => authorizeRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void TestAuthorizeRequestValidateThrowsExceptionWhenRedirectUriIsInvalid(string? redirectUri)
        {
            var authorizeRequest = new AuthorizeRequest
            {
                ResponseType = "code",
                ClientId = "client_id_123",
                RedirectUri = redirectUri!
            };

            Action act = () => authorizeRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}

