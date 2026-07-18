using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class UpdateAvatarTests
    {
        private const string UpdateAvatarUri = "users/avatar";

        [Fact]
        public async Task TestUpdateAvatar()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateAvatarUri, HttpStatusCode.NoContent);

            TraktResponse response = await client.Users.UpdateAvatarAsync("base64imagecontent", TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestUpdateAvatarThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateAvatarUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Users.UpdateAvatarAsync("base64", TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestUpdateAvatarArgumentExceptions()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateAvatarUri, HttpStatusCode.NoContent);

            Func<Task<TraktResponse>> act = () => client.Users.UpdateAvatarAsync(default!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.UpdateAvatarAsync(string.Empty, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Users.UpdateAvatarAsync("   ", TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
