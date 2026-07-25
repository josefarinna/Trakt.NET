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
        public void TestTraktContextCreate()
        {
            TraktContext context = TraktContext.Create(ClientID, ClientSecret);

            context.ShouldNotBeNull();
            context.ShouldBeOfType<TraktDefaultContext>();
            context.ID.ShouldNotBeNullOrEmpty();
            context.ClientID.ShouldBe(ClientID);
            context.ClientSecret.ShouldBe(ClientSecret);
            context.BaseUri.AbsoluteUri.ShouldBe("https://api.trakt.tv/");
            context.BaseAuthorizationUri.AbsoluteUri.ShouldBe("https://trakt.tv/");
        }

        [Fact]
        public void TestTraktContextCreateWithUserAgent()
        {
            const string customUserAgent = "CustomUserAgent/1.0";
            TraktContext context = TraktContext.Create(ClientID, ClientSecret, customUserAgent);

            context.ShouldNotBeNull();
            context.ShouldBeOfType<TraktDefaultContext>();
            context.ClientID.ShouldBe(ClientID);
            context.ClientSecret.ShouldBe(ClientSecret);
            context.UserAgent.ShouldBe(customUserAgent);
        }

        [Fact]
        public void TestTraktContextCreateForSandbox()
        {
            TraktContext context = TraktContext.CreateForSandbox(ClientID, ClientSecret);

            context.ShouldNotBeNull();
            context.ShouldBeOfType<TraktSandboxContext>();
            context.ID.ShouldNotBeNullOrEmpty();
            context.ClientID.ShouldBe(ClientID);
            context.ClientSecret.ShouldBe(ClientSecret);
            context.BaseUri.AbsoluteUri.ShouldBe("https://api-staging.trakt.tv/");
            context.BaseAuthorizationUri.AbsoluteUri.ShouldBe("https://staging.trakt.tv/");
        }

        [Fact]
        public void TestTraktContextCreateForSandboxWithUserAgent()
        {
            const string customUserAgent = "CustomUserAgent/1.0";
            TraktContext context = TraktContext.CreateForSandbox(ClientID, ClientSecret, customUserAgent);

            context.ShouldNotBeNull();
            context.ShouldBeOfType<TraktSandboxContext>();
            context.ClientID.ShouldBe(ClientID);
            context.ClientSecret.ShouldBe(ClientSecret);
            context.UserAgent.ShouldBe(customUserAgent);
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

