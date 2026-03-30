namespace TraktNET.Contexts
{
    public class TraktSandboxContextTests
    {
        private const string ClientID = "clientID";
        private const string ClientSecret = "clientSecret";

        [Fact]
        public void TestTraktSandboxContextWithClientIDAndSecret()
        {
            var context = new TraktSandboxContext(ClientID, ClientSecret, null);

            context.ID.ShouldNotBeNullOrEmpty();
            context.ClientID.ShouldBe(ClientID);
            context.ClientSecret.ShouldBe(ClientSecret);
            context.Authorization.ShouldBeNull();
        }

        [Fact]
        public void TestTraktSandboxContextHasCorrectBaseUri()
        {
            var context = new TraktSandboxContext(ClientID, ClientSecret, null);

            context.BaseUri.AbsoluteUri.ShouldBe("https://api-staging.trakt.tv/");
        }

        [Fact]
        public void TestTraktSandboxContextHasCorrectBaseAuthorizationUri()
        {
            var context = new TraktSandboxContext(ClientID, ClientSecret, null);

            context.BaseAuthorizationUri.AbsoluteUri.ShouldBe("https://staging.trakt.tv/");
        }

        [Fact]
        public void TestTraktSandboxContextInvalidClientID()
        {
            Action act = () => _ = new TraktSandboxContext(string.Empty, ClientSecret, null);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktSandboxContext("    ", ClientSecret, null);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktSandboxContext(" id ", ClientSecret, null);
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TestTraktSandboxContextInvalidClientSecret()
        {
            Action act = () => _ = new TraktSandboxContext(ClientID, string.Empty, null);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktSandboxContext(ClientID, "        ", null);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktSandboxContext(ClientID, " secret ", null);
            act.ShouldThrow<ArgumentException>();
        }
    }
}
