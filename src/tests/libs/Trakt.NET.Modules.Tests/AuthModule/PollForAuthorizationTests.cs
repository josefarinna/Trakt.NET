using System.Net;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace TraktNET.AuthModule
{
    public sealed class PollForAuthorizationTests
    {
        private const string PollForAuthorizationUri = "oauth/device/token";

        [Fact]
        public async Task TestPollForAuthorization()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            authorizationJson.ShouldNotBeNullOrEmpty();

            TraktClient client = ModuleTestUtility.GetOAuthClient(PollForAuthorizationUri, authorizationJson, null, null, null, null, true);
            client.Device = TestConstants.MockDevice;

            TraktResponse<TraktAuthorization> response = await client.Auth.PollForAuthorizationAsync(TestContext.Current.CancellationToken);

            ValidateSuccessResponse(response, client);
        }

        [Fact]
        public async Task TestPollForAuthorizationWithPolling()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(PollForAuthorizationUri);
            client.Device = TestConstants.MockDevice;

            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            authorizationJson.ShouldNotBeNullOrEmpty();

            string mockDeviceJson = $$"""
            {
                "code": "{{TestConstants.MockDeviceCode}}",
                "client_id": "{{TestConstants.ClientID}}",
                "client_secret": "{{TestConstants.ClientSecret}}"
            }
            """;

            ModuleTestUtility.AddMockExpectationResponse(client, PollForAuthorizationUri, mockDeviceJson, HttpStatusCode.BadRequest);

            ModuleTestUtility.AddMockExpectationResponse(client, PollForAuthorizationUri, mockDeviceJson, authorizationJson);

            TraktResponse<TraktAuthorization> response = await client.Auth.PollForAuthorizationAsync(TestContext.Current.CancellationToken);

            ValidateSuccessResponse(response, client);
        }

        [Fact]
        public async Task TestPollForAuthorizationWithDevice()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            authorizationJson.ShouldNotBeNullOrEmpty();

            TraktClient client = ModuleTestUtility.GetOAuthClient(PollForAuthorizationUri, authorizationJson, null, null, null, null, true);

            TraktResponse<TraktAuthorization> response = await client.Auth.PollForAuthorizationAsync(
                TestConstants.MockDevice,
                TestContext.Current.CancellationToken);

            ValidateSuccessResponse(response, client);
        }

        [Fact]
        public async Task TestPollForAuthorizationWithDeviceAndClientId()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            authorizationJson.ShouldNotBeNullOrEmpty();

            TraktClient client = ModuleTestUtility.GetOAuthClient(PollForAuthorizationUri, authorizationJson, null, null, null, null, true);

            TraktResponse<TraktAuthorization> response = await client.Auth.PollForAuthorizationAsync(
                TestConstants.MockDevice,
                TestConstants.ClientID,
                TestContext.Current.CancellationToken);

            ValidateSuccessResponse(response, client);
        }

        [Fact]
        public async Task TestPollForAuthorizationWithAllParameters()
        {
            string authorizationJson = TestUtility.SerializeObject(TestConstants.MockAuthorization);
            authorizationJson.ShouldNotBeNullOrEmpty();

            TraktClient client = ModuleTestUtility.GetOAuthClient(PollForAuthorizationUri, authorizationJson, null, null, null, null, true);

            TraktResponse<TraktAuthorization> response = await client.Auth.PollForAuthorizationAsync(
                TestConstants.MockDevice,
                TestConstants.ClientID,
                TestConstants.ClientSecret,
                TestContext.Current.CancellationToken);

            ValidateSuccessResponse(response, client);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiAuthenticationDeviceException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiAuthenticationDeviceException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiAuthenticationDeviceException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiAuthenticationDeviceException))]
#endif
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestPollForAuthorizationThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(PollForAuthorizationUri, statusCode, true);
            client.Device = TestConstants.MockDevice;

            Func<Task<TraktResponse<TraktAuthorization>>> act = () => client.Auth.PollForAuthorizationAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        private static void ValidateSuccessResponse(TraktResponse<TraktAuthorization> response, TraktClient client)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktAuthorization auth = response.Content;
            auth.AccessToken.ShouldBe(TestConstants.MockAuthorization.AccessToken);
            auth.RefreshToken.ShouldBe(TestConstants.MockAuthorization.RefreshToken);
            auth.Scope.ShouldBe(TestConstants.MockAuthorization.Scope);
            auth.TokenType.ShouldBe(TestConstants.MockAuthorization.TokenType);
            

            auth.CreatedAtDateTime.ShouldBe(DateTime.UtcNow, TimeSpan.FromSeconds(15));

            client.Authorization.ShouldNotBeNull();
            client.Authorization.AccessToken.ShouldBe(auth.AccessToken);
            client.Authorization.RefreshToken.ShouldBe(auth.RefreshToken);
        }
    }
}
