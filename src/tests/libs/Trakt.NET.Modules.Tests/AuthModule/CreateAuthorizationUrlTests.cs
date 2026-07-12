namespace TraktNET.AuthModule
{
    public sealed class CreateAuthorizationUrlTests
    {
        private const string CustomClientID = "custom_client_id";
        private const string CustomRedirectUri = "https://example.com/redirect";
        private const string CustomState = "custom_state";
        private const string RequestUri = "request_uri";

        [Fact]
        public async Task TestCreateAuthorizationUrl()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI);

            string createdUrl = client.Auth.CreateAuthorizationUrl();
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithSignupTrue()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI, null, true);

            string createdUrl = client.Auth.CreateAuthorizationUrl(true);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithForceLoginPromptTrue()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI, null, null, true);

            string createdUrl = client.Auth.CreateAuthorizationUrl(forceLoginPrompt: true);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlInSandbox()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClientForSandbox(RequestUri, "{}", null, null, null, null);
            string encodedStagingUrl = await TestUtility.BuildEncodedAuthorizeUrl(true, TestConstants.ClientID, TestConstants.RedirectURI);

            string createdUrl = client.Auth.CreateAuthorizationUrl();
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedStagingUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithClientId()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CustomClientID, TestConstants.RedirectURI);

            string createdUrl = client.Auth.CreateAuthorizationUrl(CustomClientID);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithClientIdAndRedirectUri()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CustomClientID, CustomRedirectUri);

            string createdUrl = client.Auth.CreateAuthorizationUrl(CustomClientID, CustomRedirectUri);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);

            client.Auth.RedirectUri = CustomRedirectUri;
            createdUrl = client.Auth.CreateAuthorizationUrl(CustomClientID);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithAllParameters()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CustomClientID, CustomRedirectUri, CustomState, true, true);

            string createdUrl = client.Auth.CreateAuthorizationUrl(CustomClientID, CustomRedirectUri, CustomState, true, true);
            createdUrl.ShouldNotBeNullOrEmpty();
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public void TestCreateAuthorizationUrlArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");

            Action act = () => client.Auth.CreateAuthorizationUrl(clientId: default!);
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrl(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrl("client id");
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrl(CustomClientID, "redirect uri");
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrl(CustomClientID, CustomRedirectUri, string.Empty);
            act.ShouldThrow<ArgumentException>();
        }
    }
}
