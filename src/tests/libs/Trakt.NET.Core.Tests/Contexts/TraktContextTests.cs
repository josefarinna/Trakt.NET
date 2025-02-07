namespace TraktNET.Contexts
{
    public class TraktContextTests
    {
        private const string ClientID = "clientID";
        private const string ClientSecret = "clientSecret";

        [Fact]
        public void TestTraktContextWithClientIDAndSecret()
        {
            var context = new TraktDefaultContext(ClientID, ClientSecret);

            context.ID.ShouldNotBeNullOrEmpty();
            context.ClientID.ShouldBe(ClientID);
            context.ClientSecret.ShouldBe(ClientSecret);
            context.Authorization.ShouldBeNull();
        }

        [Fact]
        public void TestTraktContextHasCorrectBaseUri()
        {
            var context = new TraktDefaultContext(ClientID, ClientSecret);

            context.BaseUri.AbsoluteUri.ShouldBe("https://api.trakt.tv/");
        }

        [Fact]
        public void TestTraktContextHasCorrectBaseAuthorizationUri()
        {
            var context = new TraktDefaultContext(ClientID, ClientSecret);

            context.BaseAuthorizationUri.AbsoluteUri.ShouldBe("https://trakt.tv/");
        }

        [Fact]
        public void TestTraktContextInvalidClientID()
        {
            Action act = () => _ = new TraktDefaultContext(string.Empty, ClientSecret);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktDefaultContext("    ", ClientSecret);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktDefaultContext(" id ", ClientSecret);
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TestTraktContextInvalidClientSecret()
        {
            Action act = () => _ = new TraktDefaultContext(ClientID, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktDefaultContext(ClientID, "        ");
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktDefaultContext(ClientID, " secret ");
            act.ShouldThrow<ArgumentException>();
        }
    }
}
