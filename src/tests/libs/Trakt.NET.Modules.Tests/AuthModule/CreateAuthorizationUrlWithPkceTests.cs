namespace TraktNET.AuthModule
{
    public sealed class CreateAuthorizationUrlWithPkceTests
    {
        private const string CustomClientID = "custom_client_id";
        private const string CustomRedirectUri = "https://example.com/redirect";
        private const string CustomState = "custom_state";
        private const string RequestUri = "request_uri";

        // RFC 7636, Appendix B
        private const string CodeVerifier = "dBjftJeZ4CVP-mB92K27uhbUJU1p1r_wW1gFWFOEjXk";
        private const string CodeChallenge = "E9Melhoa2OwvFrEMTJguCHaoeK1t8URWbuGJSstw-cM";

        private static readonly TraktPkceChallenge s_pkce = new(CodeVerifier, CodeChallenge);

        [Fact]
        public void TestRfc7636CodeChallengeVector()
            => TraktPkce.CalculateCodeChallenge(CodeVerifier).ShouldBe(CodeChallenge);

        [Fact]
        public async Task TestCreateAuthorizationUrlWithPkce()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI,
                null, null, null, CodeChallenge, TraktPkce.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithPkce(s_pkce);
            createdUrl.ShouldBe(encodedUrl);
            client.CodeVerifier.ShouldBe(CodeVerifier);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithPkceWithSignupAndForceLogin()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI,
                null, true, true, CodeChallenge, TraktPkce.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithPkce(s_pkce, true, true);
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithPkceInSandbox()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClientForSandbox(RequestUri, "{}", null, null, null, null);
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(true, TestConstants.ClientID, TestConstants.RedirectURI,
                null, null, null, CodeChallenge, TraktPkce.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithPkce(s_pkce);
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithPkceWithClientId()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CustomClientID, TestConstants.RedirectURI,
                null, null, null, CodeChallenge, TraktPkce.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithPkce(s_pkce, CustomClientID);
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithPkceWithAllParameters()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CustomClientID, CustomRedirectUri,
                CustomState, true, true, CodeChallenge, TraktPkce.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithPkce(s_pkce, CustomClientID, CustomRedirectUri, CustomState, true, true);
            createdUrl.ShouldBe(encodedUrl);
            client.CodeVerifier.ShouldBe(CodeVerifier);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateAndPkce()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI,
                client.AntiForgeryToken, null, null, CodeChallenge, TraktPkce.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultStateAndPkce(s_pkce);
            createdUrl.ShouldBe(encodedUrl);
            client.CodeVerifier.ShouldBe(CodeVerifier);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateAndPkceWithClientId()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CustomClientID, TestConstants.RedirectURI,
                client.AntiForgeryToken, null, null, CodeChallenge, TraktPkce.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultStateAndPkce(s_pkce, CustomClientID);
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateAndPkceWithAllParameters()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CustomClientID, CustomRedirectUri,
                client.AntiForgeryToken, true, true, CodeChallenge, TraktPkce.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultStateAndPkce(s_pkce, CustomClientID, CustomRedirectUri, true, true);
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public void TestCreateAuthorizationUrlWithPkceArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");

            Action act = () => client.Auth.CreateAuthorizationUrlWithPkce(null!);
            act.ShouldThrow<ArgumentNullException>();

            act = () => client.Auth.CreateAuthorizationUrlWithDefaultStateAndPkce(null!);
            act.ShouldThrow<ArgumentNullException>();

            act = () => client.Auth.CreateAuthorizationUrlWithPkce(new TraktPkceChallenge(CodeVerifier, "invalid challenge"));
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrlWithPkce(s_pkce, "client id");
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrlWithPkce(s_pkce, CustomClientID, "redirect uri");
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TestCreateAuthorizationUrlWithPkceDoesNotStoreCodeVerifierOnValidationFailure()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");

            Action act = () => client.Auth.CreateAuthorizationUrlWithPkce(s_pkce, "client id");
            act.ShouldThrow<ArgumentException>();

            client.CodeVerifier.ShouldBeNull();
        }
    }
}
