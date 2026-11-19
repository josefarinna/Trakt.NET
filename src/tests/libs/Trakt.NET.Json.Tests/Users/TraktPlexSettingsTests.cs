using System.Collections.Generic;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace TraktNET.Json.Users
{
    public sealed class TraktPlexSettingsTests
    {
        [Fact]
        public async Task TestTraktPlexSettingsFromJson()
        {
            TraktPlexSettings? settings = await TestUtility.DeserializeJsonAsync<TraktPlexSettings>("Users\\plexsettings.json");

            settings.ShouldNotBeNull();
            settings.Connection.ShouldNotBeNull();
            settings.Connection.Connected.ShouldBeTrue();
            settings.Connection.Username.ShouldBe("plex_user");

            settings.Webhook.ShouldNotBeNull();
            settings.Webhook.Url.ShouldBe("https://webhook.url");
            settings.Webhook.LastEventAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-07-16T00:00:00.000Z"));
            settings.Webhook.EventCount.ShouldBe(42);
            settings.Webhook.HomeUsers.ShouldBe("home_user1,home_user2");

            settings.Sync.ShouldNotBeNull();
            settings.Sync.Configured.ShouldBeTrue();
            settings.Sync.Error.ShouldBeFalse();
            settings.Sync.ServerLimit.ShouldBe(1U);
            settings.Sync.Selection.ShouldNotBeNull();
            settings.Sync.Selection.ServerIDs.ShouldNotBeNull();
            settings.Sync.Selection.ServerIDs.Count.ShouldBe(1);
            settings.Sync.Selection.ServerIDs[0].ShouldBe("server1");
            settings.Sync.Selection.LibraryIDs.ShouldNotBeNull();
            settings.Sync.Selection.LibraryIDs.Count.ShouldBe(1);
            settings.Sync.Selection.LibraryIDs[0].ServerID.ShouldBe("server1");
            settings.Sync.Selection.LibraryIDs[0].Uuid.ShouldBe("uuid1");
            settings.Sync.Selection.UserIDs.ShouldNotBeNull();
            settings.Sync.Selection.UserIDs.Count.ShouldBe(1);
            settings.Sync.Selection.UserIDs[0].ShouldBe("user1");

            settings.Sync.Toggles.ShouldNotBeNull();
            settings.Sync.Toggles.Movie.ShouldNotBeNull();
            settings.Sync.Toggles.Movie.Watching.ShouldBeTrue();
            settings.Sync.Toggles.Movie.Watched.ShouldBeTrue();
            settings.Sync.Toggles.Movie.Rated.ShouldBeTrue();
            settings.Sync.Toggles.Movie.Collected.ShouldBeTrue();
            settings.Sync.Toggles.Movie.Watchlist.ShouldBeTrue();
            settings.Sync.Toggles.Show.ShouldNotBeNull();
            settings.Sync.Toggles.Show.Rated.ShouldBeTrue();
            settings.Sync.Toggles.Show.Watchlist.ShouldBeTrue();
            settings.Sync.Toggles.Season.ShouldNotBeNull();
            settings.Sync.Toggles.Season.Rated.ShouldBeTrue();
            settings.Sync.Toggles.Episode.ShouldNotBeNull();
            settings.Sync.Toggles.Episode.Watching.ShouldBeTrue();
            settings.Sync.Toggles.Episode.Watched.ShouldBeTrue();
            settings.Sync.Toggles.Episode.Rated.ShouldBeTrue();
            settings.Sync.Toggles.Episode.Collected.ShouldBeTrue();

            settings.Scrobbler.ShouldNotBeNull();
            settings.Scrobbler.Toggles.ShouldNotBeNull();
            settings.Scrobbler.Toggles.Movie.ShouldNotBeNull();
            settings.Scrobbler.Toggles.Movie.Watching.ShouldBeTrue();
            settings.Scrobbler.Toggles.Movie.Watched.ShouldBeTrue();
            settings.Scrobbler.Toggles.Movie.Rated.ShouldBeTrue();
            settings.Scrobbler.Toggles.Movie.Collected.ShouldBeTrue();
            settings.Scrobbler.Toggles.Show.ShouldNotBeNull();
            settings.Scrobbler.Toggles.Show.Rated.ShouldBeTrue();
            settings.Scrobbler.Toggles.Season.ShouldNotBeNull();
            settings.Scrobbler.Toggles.Season.Rated.ShouldBeTrue();
            settings.Scrobbler.Toggles.Episode.ShouldNotBeNull();
            settings.Scrobbler.Toggles.Episode.Watching.ShouldBeTrue();
            settings.Scrobbler.Toggles.Episode.Watched.ShouldBeTrue();
            settings.Scrobbler.Toggles.Episode.Rated.ShouldBeTrue();
            settings.Scrobbler.Toggles.Episode.Collected.ShouldBeTrue();
        }
    }
}
