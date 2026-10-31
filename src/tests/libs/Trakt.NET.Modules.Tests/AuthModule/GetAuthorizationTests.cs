using System.Net;

namespace TraktNET.AuthModule
{
    public sealed class GetAuthorizationTests
    {
        private const string GetAuthorizationUri = "oauth/token";
        private const string MockAuthCode = "mockAuthCode";

        [Fact]
        public async Task TestGetAuthorization()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            authorizationJson.ShouldNotBeNullOrEmpty();

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, authorizationJson, null, null, null, null, true);
            client.OAuthAuthorizationCode = MockAuthCode;

            TraktResponse<TraktAuthorization> response = await client.Auth.GetAuthorizationAsync(TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
        }

        [Fact]
        public async Task TestGetAuthorizationWithCode()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, authorizationJson, null, null, null, null, true);

            TraktResponse<TraktAuthorization> response = await client.Auth.GetAuthorizationAsync(MockAuthCode, TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
        }

        [Fact]
        public async Task TestGetAuthorizationWithCodeAndClientId()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, authorizationJson, null, null, null, null, true);

            TraktResponse<TraktAuthorization> response = await client.Auth.GetAuthorizationAsync(MockAuthCode, TestConstants.ClientID, TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
        }

        [Fact]
        public async Task TestGetAuthorizationWithCodeClientIdAndClientSecret()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, authorizationJson, null, null, null, null, true);

            TraktResponse<TraktAuthorization> response = await client.Auth.GetAuthorizationAsync(
                MockAuthCode,
                TestConstants.ClientID,
                TestConstants.ClientSecret,
                TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
        }

        [Fact]
        public async Task TestGetAuthorizationWithCodeClientIdAndClientSecretWithoutContextClientSecret()
        {
            // The explicitly given client secret must be used, not the (missing) one of the context.
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, authorizationJson, null, null, null, null, true);
            client.ClientSecret = null;

            TraktResponse<TraktAuthorization> response = await client.Auth.GetAuthorizationAsync(
                MockAuthCode,
                TestConstants.ClientID,
                TestConstants.ClientSecret,
                TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("client secret with spaces")]
        public async Task TestGetAuthorizationWithCodeClientIdAndClientSecretThrowsOnInvalidClientSecret(string? clientSecret)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, "{}", null, null, null, null, true);

            Func<Task<TraktResponse<TraktAuthorization>>> act = () => client.Auth.GetAuthorizationAsync(
                MockAuthCode,
                TestConstants.ClientID,
                clientSecret!,
                TestContext.Current.CancellationToken);

            await act.ShouldThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task TestGetAuthorizationWithAllParameters()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, authorizationJson, null, null, null, null, true);

            TraktResponse<TraktAuthorization> response = await client.Auth.GetAuthorizationAsync(
                MockAuthCode,
                TestConstants.ClientID,
                TestConstants.ClientSecret,
                TestConstants.RedirectURI,
                TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
        }

        [Fact]
        public async Task TestGetAuthorizationWithPKCE()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, authorizationJson, null, null, null, null, true);

            TraktResponse<TraktAuthorization> response = await client.Auth.GetAuthorizationWithPKCEAsync(
                MockAuthCode,
                "dBjftJeZ4CVP-mB92K27uhbUJU1p1r_wW1gFWFOEjXk",
                TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
        }

        [Fact]
        public async Task TestGetAuthorizationWithPKCEAllParameters()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, authorizationJson, null, null, null, null, true);

            TraktResponse<TraktAuthorization> response = await client.Auth.GetAuthorizationWithPKCEAsync(
                MockAuthCode,
                "dBjftJeZ4CVP-mB92K27uhbUJU1p1r_wW1gFWFOEjXk",
                TestConstants.ClientID,
                null,
                TestConstants.RedirectURI,
                TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
        }

        [Fact]
        public async Task TestGetAuthorizationUsingContextCodeVerifier()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, authorizationJson, null, null, null, null, true);
            client.OAuthAuthorizationCode = MockAuthCode;
            client.CodeVerifier = "dBjftJeZ4CVP-mB92K27uhbUJU1p1r_wW1gFWFOEjXk";

            TraktResponse<TraktAuthorization> response = await client.Auth.GetAuthorizationAsync(TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
            client.CodeVerifier.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetAuthorizationWithPKCEClearsContextCodeVerifier()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, authorizationJson, null, null, null, null, true);
            client.CodeVerifier = "dBjftJeZ4CVP-mB92K27uhbUJU1p1r_wW1gFWFOEjXk";

            TraktResponse<TraktAuthorization> response = await client.Auth.GetAuthorizationWithPKCEAsync(
                MockAuthCode,
                "dBjftJeZ4CVP-mB92K27uhbUJU1p1r_wW1gFWFOEjXk",
                TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
            client.CodeVerifier.ShouldBeNull();
        }

        [Fact]
        public async Task TestGetAuthorizationWithCodeIgnoresContextCodeVerifier()
        {
            const string codeVerifier = "dBjftJeZ4CVP-mB92K27uhbUJU1p1r_wW1gFWFOEjXk";

            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, authorizationJson, null, null, null, null, true);
            client.CodeVerifier = codeVerifier;

            TraktResponse<TraktAuthorization> response = await client.Auth.GetAuthorizationAsync(MockAuthCode, TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
            client.CodeVerifier.ShouldBe(codeVerifier);
        }

        [Fact]
        public async Task TestGetAuthorizationAssignsContextAuthorization()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, authorizationJson, null, null, null, null, true);
            client.Authorization = null;

            TraktResponse<TraktAuthorization> response = await client.Auth.GetAuthorizationAsync(MockAuthCode, TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
            client.Authorization.ShouldBeSameAs(response.Content);
        }

        [Fact]
        public async Task TestGetAuthorizationFailureKeepsContextCodeVerifier()
        {
            const string codeVerifier = "dBjftJeZ4CVP-mB92K27uhbUJU1p1r_wW1gFWFOEjXk";

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, HttpStatusCode.BadRequest, true);
            client.OAuthAuthorizationCode = MockAuthCode;
            client.CodeVerifier = codeVerifier;

            Func<Task<TraktResponse<TraktAuthorization>>> act = () => client.Auth.GetAuthorizationAsync(TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktApiAuthenticationOAuthException>();

            client.CodeVerifier.ShouldBe(codeVerifier);
        }

        [Theory]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthenticationOAuthException))]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiAuthenticationOAuthException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiAuthenticationOAuthException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetAuthorizationThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetAuthorizationUri, statusCode, true);
            client.OAuthAuthorizationCode = MockAuthCode;

            Func<Task<TraktResponse<TraktAuthorization>>> act = () => client.Auth.GetAuthorizationAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        private static void ValidateResponse(TraktResponse<TraktAuthorization> response, TraktClient client)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktAuthorization responseAuth = response.Content;
            responseAuth.AccessToken.ShouldBe(TestConstants.MockAuthorization.AccessToken);
            responseAuth.TokenType.ShouldBe(TestConstants.MockAuthorization.TokenType);
            responseAuth.RefreshToken.ShouldBe(TestConstants.MockAuthorization.RefreshToken);
            responseAuth.Scope.ShouldBe(TestConstants.MockAuthorization.Scope);
            responseAuth.CreatedAtDateTime.ShouldBe(DateTime.UtcNow, TimeSpan.FromSeconds(10));

            client.Authorization.ShouldNotBeNull();
            client.Authorization.AccessToken.ShouldBe(responseAuth.AccessToken);
        }
    }
}
