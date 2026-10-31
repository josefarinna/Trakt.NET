namespace TraktNET.Json.Authentication
{
    public sealed class TraktAuthorizationPostTests
    {
        [Fact]
        public void TestTraktAuthorizationPostDefaultConstructor()
        {
            var post = new TraktAuthorizationPost();

            post.Code.ShouldBeNull();
            post.CodeVerifier.ShouldBeNull();
            post.ClientId.ShouldBeNull();
            post.ClientSecret.ShouldBeNull();
            post.RedirectUri.ShouldBeNull();
            post.GrantType.ShouldBe("authorization_code");
        }

        [Fact]
        public void TestTraktAuthorizationPostValidate()
        {
            var post = new TraktAuthorizationPost
            {
                Code = "code",
                ClientId = "clientId",
                ClientSecret = "clientSecret",
                RedirectUri = "https://trakt.tv/callback"
            };

            // Valid post
            Action act = () => post.Validate();
            act.ShouldNotThrow();

            // Code validation
            post.Code = null;
            act.ShouldThrow<ArgumentException>();

            post.Code = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.Code = "   ";
            act.ShouldThrow<ArgumentException>();

            post.Code = "code with spaces";
            act.ShouldThrow<ArgumentException>();

            post.Code = "code";

            // ClientId validation
            post.ClientId = null;
            act.ShouldThrow<ArgumentException>();

            post.ClientId = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.ClientId = "   ";
            act.ShouldThrow<ArgumentException>();

            post.ClientId = "clientId with spaces";
            act.ShouldThrow<ArgumentException>();

            post.ClientId = "clientId";

            // ClientSecret validation (when CodeVerifier is null)
            post.ClientSecret = null;
            act.ShouldThrow<ArgumentException>();

            post.ClientSecret = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.ClientSecret = "   ";
            act.ShouldThrow<ArgumentException>();

            post.ClientSecret = "clientSecret with spaces";
            act.ShouldThrow<ArgumentException>();

            post.ClientSecret = "clientSecret";

            // RedirectUri validation
            post.RedirectUri = null;
            act.ShouldThrow<ArgumentException>();

            post.RedirectUri = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.RedirectUri = "   ";
            act.ShouldThrow<ArgumentException>();

            post.RedirectUri = "redirectUri with spaces";
            act.ShouldThrow<ArgumentException>();

            post.RedirectUri = "https://trakt.tv/callback";
            act.ShouldNotThrow();
        }

        [Fact]
        public void TestTraktAuthorizationPostValidateWithPkce()
        {
            var post = new TraktAuthorizationPost
            {
                Code = "code",
                ClientId = "clientId",
                CodeVerifier = "dBjftJeZ4CVP-mB92K27uhbUJU1p1r_wW1gFWFOEjXk",
                ClientSecret = null,
                RedirectUri = "https://trakt.tv/callback"
            };

            Action act = () => post.Validate();
            act.ShouldNotThrow();

            // CodeVerifier with spaces
            post.CodeVerifier = "invalid verifier with spaces";
            act.ShouldThrow<ArgumentException>();

            // CodeVerifier too short (< 43 chars)
            post.CodeVerifier = new string('a', 42);
            act.ShouldThrow<ArgumentException>();

            // CodeVerifier too long (> 128 chars)
            post.CodeVerifier = new string('a', 129);
            act.ShouldThrow<ArgumentException>();

            // CodeVerifier at exact boundaries (43 and 128 chars) is valid
            post.CodeVerifier = new string('a', 43);
            act.ShouldNotThrow();

            post.CodeVerifier = new string('a', 128);
            act.ShouldNotThrow();

            // CodeVerifier with characters outside [A-Za-z0-9-._~]
            post.CodeVerifier = new string('a', 42) + "+";
            act.ShouldThrow<ArgumentException>();

            post.CodeVerifier = new string('a', 42) + "/";
            act.ShouldThrow<ArgumentException>();

            post.CodeVerifier = new string('a', 42) + "=";
            act.ShouldThrow<ArgumentException>();

            // Empty or whitespace CodeVerifier is not treated as "no PKCE": it would be sent, so it must fail
            post.CodeVerifier = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.CodeVerifier = "   ";
            act.ShouldThrow<ArgumentException>();

            post.ClientSecret = "validSecret";
            post.CodeVerifier = string.Empty;
            act.ShouldThrow<ArgumentException>();
            post.ClientSecret = null;

            // Valid CodeVerifier again
            post.CodeVerifier = "dBjftJeZ4CVP-mB92K27uhbUJU1p1r_wW1gFWFOEjXk";
            act.ShouldNotThrow();

            // Optional ClientSecret alongside CodeVerifier: null is valid (not sent) ...
            post.ClientSecret = null;
            act.ShouldNotThrow();

            // ... but if provided, it must not be empty, whitespace or contain spaces
            post.ClientSecret = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.ClientSecret = "   ";
            act.ShouldThrow<ArgumentException>();

            post.ClientSecret = "invalid secret with spaces";
            act.ShouldThrow<ArgumentException>();

            post.ClientSecret = "validSecret";
            act.ShouldNotThrow();
        }
    }
}
