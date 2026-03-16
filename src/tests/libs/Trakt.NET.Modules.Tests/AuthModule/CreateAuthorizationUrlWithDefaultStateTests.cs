namespace TraktNET.AuthModule
{
    public sealed class CreateAuthorizationUrlWithDefaultStateTests
    {
        private const string CUSTOM_CLIENT_ID = "custom_client_id";
        private const string CUSTOM_REDIRECT_URI = "https://example.com/redirect";
        private const string REQUEST_URI = "request_uri";

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultState()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(REQUEST_URI, "{}", null, null, null, null);
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI, client.AntiForgeryToken);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultState();
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateWithSignupTrue()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(REQUEST_URI, "{}", null, null, null, null);
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI, client.AntiForgeryToken, true);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultState(true);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateWithForceLoginPromptTrue()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(REQUEST_URI, "{}", null, null, null, null);
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI, client.AntiForgeryToken, null, true);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultState(forceLoginPrompt: true);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateInSandbox()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClientForSandbox(REQUEST_URI, "{}", null, null, null, null);
            string encodedStagingUrl = await TestUtility.BuildEncodedAuthorizeUrl(true, TestConstants.ClientID, TestConstants.RedirectURI, client.AntiForgeryToken);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultState();
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedStagingUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateWithClientId()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(REQUEST_URI, "{}", null, null, null, null);
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, TestConstants.RedirectURI, client.AntiForgeryToken);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateWithClientIdAndRedirectUri()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(REQUEST_URI, "{}", null, null, null, null);
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.AntiForgeryToken);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateWithAllParameters()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(REQUEST_URI, "{}", null, null, null, null);
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, client.AntiForgeryToken, true, true);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, true, true);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public void TestCreateAuthorizationUrlWithDefaultStateArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(REQUEST_URI, "{}", null, null, null, null);

            Action act = () => client.Auth.CreateAuthorizationUrlWithDefaultState(clientId: null);
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrlWithDefaultState(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrlWithDefaultState("client id");
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrlWithDefaultState(CUSTOM_CLIENT_ID, "redirect uri");
            act.ShouldThrow<ArgumentException>();
        }
    }
}
