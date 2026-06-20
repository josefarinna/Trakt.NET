using System.Net;

namespace TraktNET.AuthModule
{
    public sealed class GenerateDeviceTests
    {
        private const string GetDeviceUri = "oauth/device/code";

        [Fact]
        public async Task TestGenerateDevice()
        {
            string deviceJson = TestUtility.SerializeObject(TestConstants.MockDevice);
            deviceJson.ShouldNotBeNullOrEmpty();

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetDeviceUri, deviceJson, null, null, null, null, true);
            TraktResponse<TraktDevice> response = await client.Auth.GenerateDeviceAsync(TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
        }

        [Fact]
        public async Task TestGenerateDeviceWithClientId()
        {
            string deviceJson = TestUtility.SerializeObject(TestConstants.MockDevice);
            deviceJson.ShouldNotBeNullOrEmpty();

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetDeviceUri, deviceJson, null, null, null, null, true);
            TraktResponse<TraktDevice> response = await client.Auth.GenerateDeviceAsync(TestConstants.ClientID, TestContext.Current.CancellationToken);

            ValidateResponse(response, client);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiAuthenticationDeviceException))] // En v4, 404 suele ser NotFoundException
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
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
        public async Task TestGenerateDeviceThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetDeviceUri, statusCode, true);

            Func<Task<TraktResponse<TraktDevice>>> act = () => client.Auth.GenerateDeviceAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        private static void ValidateResponse(TraktResponse<TraktDevice> response, TraktClient client)
        {
            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktDevice responseDevice = response.Content;
            responseDevice.DeviceCode.ShouldBe(TestConstants.MockDevice.DeviceCode);
            responseDevice.UserCode.ShouldBe(TestConstants.MockDevice.UserCode);
            responseDevice.VerificationUrl.ShouldBe(TestConstants.MockDevice.VerificationUrl);
            responseDevice.ExpiresInSeconds.ShouldBe(TestConstants.MockDevice.ExpiresInSeconds);
            responseDevice.IntervalInSeconds.ShouldBe(TestConstants.MockDevice.IntervalInSeconds);

            responseDevice.CreatedAt.ShouldBe(DateTime.UtcNow, TimeSpan.FromSeconds(10));

            responseDevice.IsExpiredUnused.ShouldBeFalse();
            responseDevice.IsValid.ShouldBeTrue();

            client.Device.ShouldNotBeNull();
            client.Device.DeviceCode.ShouldBe(responseDevice.DeviceCode);
            client.Device.UserCode.ShouldBe(responseDevice.UserCode);
            client.Device.CreatedAt.ShouldBe(DateTime.UtcNow, TimeSpan.FromSeconds(10));
        }
    }
}
