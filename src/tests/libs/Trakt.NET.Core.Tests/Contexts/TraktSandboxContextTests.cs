namespace TraktNET.Contexts
{
    public class TraktSandboxContextTests
    {
        private const string ClientID = "clientID";
        private const string ClientSecret = "clientSecret";

        [Fact]
        public void TestTraktSandboxContextWithClientIDAndSecret()
        {
            var context = new TraktSandboxContext(ClientID, ClientSecret);

            context.ID.ShouldNotBeNullOrEmpty();
            context.ClientID.ShouldBe(ClientID);
            context.ClientSecret.ShouldBe(ClientSecret);
            context.Authorization.ShouldBeNull();
        }

        [Fact]
        public void TestTraktSandboxContextHasCorrectBaseUri()
        {
            var context = new TraktSandboxContext(ClientID, ClientSecret);

            context.BaseUri.AbsoluteUri.ShouldBe("https://api-staging.trakt.tv/");
        }

        [Fact]
        public void TestTraktSandboxContextHasCorrectBaseAuthorizationUri()
        {
            var context = new TraktSandboxContext(ClientID, ClientSecret);

            context.BaseAuthorizationUri.AbsoluteUri.ShouldBe("https://staging.trakt.tv/");
        }

        [Fact]
        public void TestTraktSandboxContextInvalidClientID()
        {
            Action act = () => _ = new TraktSandboxContext(string.Empty, ClientSecret);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktSandboxContext("    ", ClientSecret);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktSandboxContext(" id ", ClientSecret);
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TestTraktSandboxContextInvalidClientSecret()
        {
            Action act = () => _ = new TraktSandboxContext(ClientID, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktSandboxContext(ClientID, "        ");
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktSandboxContext(ClientID, " secret ");
            act.ShouldThrow<ArgumentException>();
        }
    }
}
