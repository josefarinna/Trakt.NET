namespace TraktNET.Json.Authentication
{
    public sealed class TraktAuthorizationPostTests
    {
        [Fact]
        public void TestTraktAuthorizationPostDefaultConstructor()
        {
            var post = new TraktAuthorizationPost();

            post.Code.ShouldBeNull();
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

            // ClientSecret validation
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
    }
}

