using System.Net;

namespace TraktNET.AuthModule
{
    public sealed class RevokeAuthorizationTests
    {
        private const string RevokeAuthorizationUri = "oauth/revoke";

        [Fact]
        public async Task TestRevokeAuthorization()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RevokeAuthorizationUri, HttpStatusCode.NoContent, true);
            client.Authorization = TestConstants.MockAuthorization;

            TraktResponse response = await client.Auth.RevokeAuthorizationAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            ValidateRevokedState(client);
        }

        [Fact]
        public async Task TestRevokeAuthorizationWithToken()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RevokeAuthorizationUri, HttpStatusCode.NoContent, true);
            client.Authorization = TestConstants.MockAuthorization;

            TraktResponse response = await client.Auth.RevokeAuthorizationAsync(
                TestConstants.MockAuthorization.AccessToken!,
                TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            ValidateRevokedState(client);
        }

        [Fact]
        public async Task TestRevokeAuthorizationWithTokenAndClientId()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RevokeAuthorizationUri, HttpStatusCode.NoContent, true);
            client.Authorization = TestConstants.MockAuthorization;

            TraktResponse response = await client.Auth.RevokeAuthorizationAsync(
                TestConstants.MockAuthorization.AccessToken!,
                TestConstants.ClientID,
                TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            ValidateRevokedState(client);
        }

        [Fact]
        public async Task TestRevokeAuthorizationWithAllParameters()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RevokeAuthorizationUri, HttpStatusCode.NoContent, true);
            client.Authorization = TestConstants.MockAuthorization;

            TraktResponse response = await client.Auth.RevokeAuthorizationAsync(
                TestConstants.MockAuthorization.AccessToken!,
                TestConstants.ClientID,
                TestConstants.ClientSecret,
                TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            ValidateRevokedState(client);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiAuthenticationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
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
        public async Task TestRevokeAuthorizationThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RevokeAuthorizationUri, statusCode, true);
            client.Authorization = TestConstants.MockAuthorization;

            Func<Task<TraktResponse>> act = () => client.Auth.RevokeAuthorizationAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        private static void ValidateRevokedState(TraktClient client)
        {
            client.Authorization.ShouldNotBeNull();
            client.Authorization.AccessToken.ShouldBeEmpty();
            client.Authorization.RefreshToken.ShouldBeEmpty();
            client.Authorization.Scope.ShouldBe(TraktAccessScope.Public);
            client.Authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            client.Authorization.IsExpired.ShouldBeTrue();
            client.Authorization.IsValid.ShouldBeFalse();
        }
    }
}
