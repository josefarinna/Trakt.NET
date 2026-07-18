using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetPlexSettingsTests
    {
        private const string GetPlexSettingsUri = "users/settings/plex";

        [Fact]
        public async Task TestGetPlexSettings()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\plexsettings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPlexSettingsUri, responseContent);
            TraktResponse<TraktPlexSettings> response = await client.Users.GetPlexSettingsAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktPlexSettings settings = response.Content;
            settings.Connection.ShouldNotBeNull();
            settings.Connection.Connected.ShouldBeTrue();
            settings.Connection.Username.ShouldBe("plex_user");

            settings.Webhook.ShouldNotBeNull();
            settings.Webhook.Url.ShouldBe("https://webhook.url");
            settings.Webhook.EventCount.ShouldBe(42);
            settings.Webhook.HomeUsers.ShouldBe("home_user1,home_user2");

            settings.Sync.ShouldNotBeNull();
            settings.Sync.Configured.ShouldBeTrue();
            settings.Sync.Error.ShouldBeFalse();
            settings.Sync.Selection.ShouldNotBeNull();
            settings.Sync.Selection.ServerIds.ShouldNotBeNull();
            settings.Sync.Selection.ServerIds[0].ShouldBe("server1");
            settings.Sync.Selection.LibraryIds.ShouldNotBeNull();
            settings.Sync.Selection.LibraryIds[0].ServerId.ShouldBe("server1");
            settings.Sync.Selection.LibraryIds[0].Uuid.ShouldBe("uuid1");

            settings.Sync.Toggles.ShouldNotBeNull();
            settings.Sync.Toggles.Movie.ShouldNotBeNull();
            settings.Sync.Toggles.Movie.Watching.ShouldBeTrue();

            settings.Scrobbler.ShouldNotBeNull();
            settings.Scrobbler.Toggles.ShouldNotBeNull();
            settings.Scrobbler.Toggles.Movie.ShouldNotBeNull();
            settings.Scrobbler.Toggles.Movie.Watching.ShouldBeTrue();
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
        public async Task TestGetPlexSettingsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPlexSettingsUri, statusCode);

            Func<Task<TraktResponse<TraktPlexSettings>>> act = () => client.Users.GetPlexSettingsAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
