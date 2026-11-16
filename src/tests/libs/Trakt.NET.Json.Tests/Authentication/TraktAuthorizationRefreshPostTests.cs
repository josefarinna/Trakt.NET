namespace TraktNET.Json.Authentication
{
    public sealed class TraktAuthorizationRefreshPostTests
    {
        [Fact]
        public void TestTraktAuthorizationRefreshPostDefaultConstructor()
        {
            var post = new TraktAuthorizationRefreshPost();

            post.RefreshToken.ShouldBeNull();
            post.ClientID.ShouldBeNull();
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
                ClientID = "clientId",
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

            // ClientID validation
            post.ClientID = null;
            act.ShouldThrow<ArgumentException>();

            post.ClientID = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.ClientID = "   ";
            act.ShouldThrow<ArgumentException>();

            post.ClientID = "clientId with spaces";
            act.ShouldThrow<ArgumentException>();

            post.ClientID = "clientId";

            // ClientSecret is optional (valid when null for public/PKCE clients)
            post.ClientSecret = null;
            act.ShouldNotThrow();

            post.ClientSecret = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.ClientSecret = "   ";
            act.ShouldThrow<ArgumentException>();

            post.ClientSecret = "clientSecret with spaces";
            act.ShouldThrow<ArgumentException>();

            post.ClientSecret = "clientSecret";
            act.ShouldNotThrow();

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
