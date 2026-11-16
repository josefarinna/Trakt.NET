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
            settings.Sync.ServerLimit.ShouldBe(1U);
            settings.Sync.Selection.ShouldNotBeNull();
            settings.Sync.Selection.ServerIDs.ShouldNotBeNull();
            settings.Sync.Selection.ServerIDs[0].ShouldBe("server1");
            settings.Sync.Selection.LibraryIDs.ShouldNotBeNull();
            settings.Sync.Selection.LibraryIDs[0].ServerID.ShouldBe("server1");
            settings.Sync.Selection.LibraryIDs[0].Uuid.ShouldBe("uuid1");

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
        public async Task TestGetPlexSettingsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPlexSettingsUri, statusCode);

            Func<Task<TraktResponse<TraktPlexSettings>>> act = () => client.Users.GetPlexSettingsAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
