using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class ConnectPlexTests
    {
        private const string ConnectPlexUri = "users/settings/plex/connect";

        [Fact]
        public async Task TestConnectPlex()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\plexconnect.json");

            var connectPost = new TraktPlexConnectPost
            {
                ReturnUrl = "https://trakt.tv/plex"
            };

            TraktClient client = ModuleTestUtility.GetOAuthClient(ConnectPlexUri, responseContent);
            TraktResponse<TraktPlexConnectResponse> response = await client.Users.ConnectPlexAsync(connectPost, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Url.ShouldBe("https://plex.tv/auth");
        }

        [Fact]
        public async Task TestConnectPlexThrowsArgumentNullException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(ConnectPlexUri, HttpStatusCode.OK);

            Func<Task<TraktResponse<TraktPlexConnectResponse>>> act = () => client.Users.ConnectPlexAsync(null!, TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();
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
        public async Task TestConnectPlexThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            var connectPost = new TraktPlexConnectPost { ReturnUrl = "https://trakt.tv/plex" };
            TraktClient client = ModuleTestUtility.GetOAuthClient(ConnectPlexUri, statusCode);

            Func<Task<TraktResponse<TraktPlexConnectResponse>>> act = () => client.Users.ConnectPlexAsync(connectPost, TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
