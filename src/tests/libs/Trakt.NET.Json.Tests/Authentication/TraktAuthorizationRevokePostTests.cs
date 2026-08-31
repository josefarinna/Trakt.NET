namespace TraktNET.Json.Authentication
{
    public sealed class TraktAuthorizationRevokePostTests
    {
        [Fact]
        public void TestTraktAuthorizationRevokePostDefaultConstructor()
        {
            var post = new TraktAuthorizationRevokePost();

            post.Token.ShouldBeNull();
            post.ClientId.ShouldBeNull();
            post.ClientSecret.ShouldBeNull();
        }

        [Fact]
        public void TestTraktAuthorizationRevokePostValidate()
        {
            var post = new TraktAuthorizationRevokePost
            {
                Token = "accessToken",
                ClientId = "clientId",
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
            act.ShouldNotThrow();
        }
    }
}

