using System.Net;

namespace TraktNET.AuthModule
{
    public sealed class RefreshAuthorizationTests
    {
        private const string RefreshAuthorizationUri = "oauth/token";

        [Fact]
        public async Task TestRefreshAuthorization()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            authorizationJson.ShouldNotBeNullOrEmpty();

            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshAuthorizationUri, authorizationJson, null, null, null, null, true);

            TraktResponse<TraktAuthorization> response = await client.Auth.RefreshAuthorizationAsync(TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
        }

        [Fact]
        public async Task TestRefreshAuthorizationWithToken()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshAuthorizationUri, authorizationJson, null, null, null, null, true);

            TraktResponse<TraktAuthorization> response = await client.Auth.RefreshAuthorizationAsync(
                TestConstants.MockAuthorization.RefreshToken!,
                TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
        }

        [Fact]
        public async Task TestRefreshAuthorizationWithTokenAndClientId()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshAuthorizationUri, authorizationJson, null, null, null, null, true);

            TraktResponse<TraktAuthorization> response = await client.Auth.RefreshAuthorizationAsync(
                TestConstants.MockAuthorization.RefreshToken!,
                TestConstants.ClientID,
                TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
        }

        [Fact]
        public async Task TestRefreshAuthorizationWithAllParameters()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshAuthorizationUri, authorizationJson, null, null, null, null, true);

            TraktResponse<TraktAuthorization> response = await client.Auth.RefreshAuthorizationAsync(
                TestConstants.MockAuthorization.RefreshToken!,
                TestConstants.ClientID,
                TestConstants.ClientSecret,
                TestConstants.RedirectURI,
                TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
        }

        [Theory]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
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
        public async Task TestRefreshAuthorizationThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshAuthorizationUri, statusCode, true);

            Func<Task<TraktResponse<TraktAuthorization>>> act = () => client.Auth.RefreshAuthorizationAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestRefreshAuthorizationWithAuthorizationNullThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(RefreshAuthorizationUri);
            client.Authorization = null;

            Func<Task<TraktResponse<TraktAuthorization>>> act = () => client.Auth.RefreshAuthorizationAsync(TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }

        private static void ValidateResponse(TraktResponse<TraktAuthorization> response, TraktClient client)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktAuthorization responseAuth = response.Content;
            responseAuth.AccessToken.ShouldBe(TestConstants.MockAuthorization.AccessToken);
            responseAuth.RefreshToken.ShouldBe(TestConstants.MockAuthorization.RefreshToken);

            responseAuth.CreatedAtDateTime.ShouldBe(DateTime.UtcNow, TimeSpan.FromSeconds(10));

            client.Authorization.ShouldNotBeNull();
            client.Authorization.AccessToken.ShouldBe(responseAuth.AccessToken);
            client.Authorization.CreatedAt.ShouldBe(responseAuth.CreatedAt);
        }
    }
}
