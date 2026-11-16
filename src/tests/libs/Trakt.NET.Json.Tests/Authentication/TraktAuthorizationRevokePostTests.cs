namespace TraktNET.Json.Authentication
{
    public sealed class TraktAuthorizationRevokePostTests
    {
        [Fact]
        public void TestTraktAuthorizationRevokePostDefaultConstructor()
        {
            var post = new TraktAuthorizationRevokePost();

            post.Token.ShouldBeNull();
            post.ClientID.ShouldBeNull();
            post.ClientSecret.ShouldBeNull();
        }

        [Fact]
        public void TestTraktAuthorizationRevokePostValidate()
        {
            var post = new TraktAuthorizationRevokePost
            {
                Token = "accessToken",
                ClientID = "clientId",
                ClientSecret = "clientSecret"
            };

            // Valid post
            Action act = () => post.Validate();
            act.ShouldNotThrow();

            // Token validation
            post.Token = null;
            act.ShouldThrow<ArgumentException>();

            post.Token = string.Empty;
            act.ShouldThrow<ArgumentException>();

            post.Token = "   ";
            act.ShouldThrow<ArgumentException>();

            post.Token = "token with spaces";
            act.ShouldThrow<ArgumentException>();

            post.Token = "accessToken";

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
        }
    }
}
