namespace TraktNET.AuthModule
{
    public sealed class CreateAuthorizationUrlWithPKCETests
    {
        private const string CustomClientID = "custom_client_id";
        private const string CustomRedirectUri = "https://example.com/redirect";
        private const string CustomState = "custom_state";
        private const string RequestUri = "request_uri";

        // RFC 7636, Appendix B
        private const string CodeVerifier = "dBjftJeZ4CVP-mB92K27uhbUJU1p1r_wW1gFWFOEjXk";
        private const string CodeChallenge = "E9Melhoa2OwvFrEMTJguCHaoeK1t8URWbuGJSstw-cM";

        private static readonly TraktPKCEChallenge s_pkce = new(CodeVerifier, CodeChallenge);

        [Fact]
        public void TestRfc7636CodeChallengeVector()
            => TraktPKCE.CalculateCodeChallenge(CodeVerifier).ShouldBe(CodeChallenge);

        [Fact]
        public async Task TestCreateAuthorizationUrlWithPKCE()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI,
                null, null, null, CodeChallenge, TraktPKCE.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithPKCE(s_pkce);
            createdUrl.ShouldBe(encodedUrl);
            client.CodeVerifier.ShouldBe(CodeVerifier);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithPKCEWithSignupAndForceLogin()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI,
                null, true, true, CodeChallenge, TraktPKCE.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithPKCE(s_pkce, true, true);
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithPKCEInSandbox()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClientForSandbox(RequestUri, "{}", null, null, null, null);
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(true, TestConstants.ClientID, TestConstants.RedirectURI,
                null, null, null, CodeChallenge, TraktPKCE.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithPKCE(s_pkce);
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithPKCEWithClientId()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CustomClientID, TestConstants.RedirectURI,
                null, null, null, CodeChallenge, TraktPKCE.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithPKCE(s_pkce, CustomClientID);
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithPKCEWithAllParameters()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CustomClientID, CustomRedirectUri,
                CustomState, true, true, CodeChallenge, TraktPKCE.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithPKCE(s_pkce, CustomClientID, CustomRedirectUri, CustomState, true, true);
            createdUrl.ShouldBe(encodedUrl);
            client.CodeVerifier.ShouldBe(CodeVerifier);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateAndPKCE()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, TestConstants.ClientID, TestConstants.RedirectURI,
                client.AntiForgeryToken, null, null, CodeChallenge, TraktPKCE.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultStateAndPKCE(s_pkce);
            createdUrl.ShouldBe(encodedUrl);
            client.CodeVerifier.ShouldBe(CodeVerifier);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateAndPKCEWithClientId()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CustomClientID, TestConstants.RedirectURI,
                client.AntiForgeryToken, null, null, CodeChallenge, TraktPKCE.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultStateAndPKCE(s_pkce, CustomClientID);
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public async Task TestCreateAuthorizationUrlWithDefaultStateAndPKCEWithAllParameters()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");
            string encodedUrl = await TestUtility.BuildEncodedAuthorizeUrl(false, CustomClientID, CustomRedirectUri,
                client.AntiForgeryToken, true, true, CodeChallenge, TraktPKCE.S256);

            string createdUrl = client.Auth.CreateAuthorizationUrlWithDefaultStateAndPKCE(s_pkce, CustomClientID, CustomRedirectUri, true, true);
            createdUrl.ShouldBe(encodedUrl);
        }

        [Fact]
        public void TestCreateAuthorizationUrlWithPKCEArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");

            Action act = () => client.Auth.CreateAuthorizationUrlWithPKCE(null!);
            act.ShouldThrow<ArgumentNullException>();

            act = () => client.Auth.CreateAuthorizationUrlWithDefaultStateAndPKCE(null!);
            act.ShouldThrow<ArgumentNullException>();

            act = () => client.Auth.CreateAuthorizationUrlWithPKCE(new TraktPKCEChallenge(CodeVerifier, "invalid challenge"));
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrlWithPKCE(s_pkce, "client id");
            act.ShouldThrow<ArgumentException>();

            act = () => client.Auth.CreateAuthorizationUrlWithPKCE(s_pkce, CustomClientID, "redirect uri");
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TestCreateAuthorizationUrlWithPKCEDoesNotStoreCodeVerifierOnValidationFailure()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RequestUri, "{}");

            Action act = () => client.Auth.CreateAuthorizationUrlWithPKCE(s_pkce, "client id");
            act.ShouldThrow<ArgumentException>();

            client.CodeVerifier.ShouldBeNull();
        }
    }
}
