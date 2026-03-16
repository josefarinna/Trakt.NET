namespace TraktNET.AuthModule
{
    public sealed class CreateAuthorizationUrlTests
    {
        private const string CUSTOM_CLIENT_ID = "custom_client_id";
        private const string CUSTOM_REDIRECT_URI = "https://example.com/redirect";
        private const string CUSTOM_STATE = "custom_state";
        private const string REQUEST_URI = "request_uri";

        [Fact]
        public async Task TestCreateAuthorizationUrl()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(REQUEST_URI, "{}", null, null, null, null);
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI);

            string createdUrl = client.Auth.CreateAuthorizationUrl();
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithSignupTrue()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(REQUEST_URI, "{}", null, null, null, null);
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI, null, true);

            string createdUrl = client.Auth.CreateAuthorizationUrl(true);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithForceLoginPromptTrue()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(REQUEST_URI, "{}", null, null, null, null);
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI, null, null, true);

            string createdUrl = client.Auth.CreateAuthorizationUrl(forceLoginPrompt: true);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlInSandbox()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClientForSandbox(REQUEST_URI, "{}", null, null, null, null);
            string encodedStagingUrl = await TestUtility.BuildEncodedAuthorizeUrl(true, TestConstants.ClientID, TestConstants.RedirectURI);

            string createdUrl = client.Auth.CreateAuthorizationUrl();
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedStagingUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithClientId()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(REQUEST_URI, "{}", null, null, null, null);
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, TestConstants.RedirectURI);

            string createdUrl = client.Auth.CreateAuthorizationUrl(CUSTOM_CLIENT_ID);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithClientIdAndRedirectUri()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(REQUEST_URI, "{}", null, null, null, null);
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI);

            string createdUrl = client.Auth.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithAllParameters()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(REQUEST_URI, "{}", null, null, null, null);
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, CUSTOM_STATE, true, true);

            string createdUrl = client.Auth.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, CUSTOM_STATE, true, true);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public void TestCreateAuthorizationUrlArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(REQUEST_URI, "{}", null, null, null, null);

            Action act = () => client.Auth.CreateAuthorizationUrl(clientId: null);
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrl(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrl("client id");
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, "redirect uri");
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrl(CUSTOM_CLIENT_ID, CUSTOM_REDIRECT_URI, string.Empty);
            act.ShouldThrow<ArgumentException>();
        }
    }
}
