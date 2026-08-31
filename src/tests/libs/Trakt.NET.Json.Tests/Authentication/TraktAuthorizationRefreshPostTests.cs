namespace TraktNET.Json.Authentication
{
    public sealed class TraktAuthorizationRefreshPostTests
    {
        [Fact]
        public void TestTraktAuthorizationRefreshPostDefaultConstructor()
        {
            var post = new TraktAuthorizationRefreshPost();

            post.RefreshToken.ShouldBeNull();
            post.ClientId.ShouldBeNull();
            post.ClientSecret.ShouldBeNull();
            post.RedirectUri.ShouldBeNull();
            post.GrantType.ShouldBe("refresh_token");
        }

        [Fact]
        public void TestTraktAuthorizationRefreshPostValidate()
        {
            var post = new TraktAuthorizationRefreshPost
            {
                RefreshToken = "refreshToken",
                ClientId = "clientId",
                ClientSecret = "clientSecret",
                RedirectUri = "https://trakt.tv/callback"
            };

            // Valid post
            Action act = () => post.Validate();
            act.ShouldNotThrow();

            // RefreshToken validation
            post.RefreshToken = null;
            act.ShouldThrow<ArgumentException>();

            post.RefreshToken = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.RefreshToken = "   ";
            act.ShouldThrow<ArgumentException>();

            post.RefreshToken = "refreshToken with spaces";
            act.ShouldThrow<ArgumentException>();

            post.RefreshToken = "refreshToken";

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

