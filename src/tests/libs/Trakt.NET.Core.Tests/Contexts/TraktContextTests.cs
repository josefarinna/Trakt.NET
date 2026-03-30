namespace TraktNET.Contexts
{
    public class TraktContextTests
    {
        private const string ClientID = "clientID";
        private const string ClientSecret = "clientSecret";

        [Fact]
        public void TestTraktContextWithClientIDAndSecret()
        {
            var context = new TraktDefaultContext(ClientID, ClientSecret, null);

            context.ID.ShouldNotBeNullOrEmpty();
            context.ClientID.ShouldBe(ClientID);
            context.ClientSecret.ShouldBe(ClientSecret);
            context.Authorization.ShouldBeNull();
        }

        [Fact]
        public void TestTraktContextHasCorrectBaseUri()
        {
            var context = new TraktDefaultContext(ClientID, ClientSecret, null);

            context.BaseUri.AbsoluteUri.ShouldBe("https://api.trakt.tv/");
        }

        [Fact]
        public void TestTraktContextHasCorrectBaseAuthorizationUri()
        {
            var context = new TraktDefaultContext(ClientID, ClientSecret, null);

            context.BaseAuthorizationUri.AbsoluteUri.ShouldBe("https://trakt.tv/");
        }

        [Fact]
        public void TestTraktContextInvalidClientID()
        {
            Action act = () => _ = new TraktDefaultContext(string.Empty, ClientSecret, null);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktDefaultContext("    ", ClientSecret, null);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktDefaultContext(" id ", ClientSecret, null);
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TestTraktContextInvalidClientSecret()
        {
            Action act = () => _ = new TraktDefaultContext(ClientID, string.Empty, null);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktDefaultContext(ClientID, "        ", null);
            act.ShouldThrow<ArgumentException>();

            act = () => _ = new TraktDefaultContext(ClientID, " secret ", null);
            act.ShouldThrow<ArgumentException>();
        }
    }
}
