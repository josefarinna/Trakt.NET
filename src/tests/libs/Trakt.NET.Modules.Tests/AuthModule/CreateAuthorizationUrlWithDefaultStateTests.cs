namespace TraktNET.AuthModule
{
    public sealed class CreateAuthorizationUrlWithDefaultStateTests
    {
        private const string CustomClientID = "custom_client_id";
        private const string CustomRedirectUri = "https://example.com/redirect";
        private const string RequestUri = "request_uri";

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultState()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI, client.AntiForgeryToken);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultState();
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateWithSignupTrue()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI, client.AntiForgeryToken, true);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultState(true);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateWithForceLoginPromptTrue()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI, client.AntiForgeryToken, null, true);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultState(forceLoginPrompt: true);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateInSandbox()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClientForSandbox(RequestUri, "{}", null, null, null, null);
            string encodedStagingUrl = await TestUtility.BuildEncodedAuthorizeUrl(true, TestConstants.ClientID, TestConstants.RedirectURI, client.AntiForgeryToken);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultState();
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedStagingUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateWithClientId()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CustomClientID, TestConstants.RedirectURI, client.AntiForgeryToken);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultState(CustomClientID);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateWithClientIdAndRedirectUri()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CustomClientID, CustomRedirectUri, client.AntiForgeryToken);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultState(CustomClientID, CustomRedirectUri);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateWithAllParameters()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CustomClientID, CustomRedirectUri, client.AntiForgeryToken, true, true);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultState(CustomClientID, CustomRedirectUri, true, true);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public void TestCreateAuthorizationUrlWithDefaultStateArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");

#pragma warning disable CS8625
            Action act = () => client.Auth.CreateAuthorizationUrlWithDefaultState(clientId: null);
#pragma warning restore CS8625
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrlWithDefaultState(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrlWithDefaultState("client id");
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrlWithDefaultState(CustomClientID, "redirect uri");
            act.ShouldThrow<ArgumentException>();
        }
    }
}
