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
            settings.Sync.Selection.ShouldNotBeNull();
            settings.Sync.Selection.ServerIds.ShouldNotBeNull();
            settings.Sync.Selection.ServerIds.Count.ShouldBe(1);
            settings.Sync.Selection.ServerIds[0].ShouldBe("server1");
            settings.Sync.Selection.LibraryIds.ShouldNotBeNull();
            settings.Sync.Selection.LibraryIds.Count.ShouldBe(1);
            settings.Sync.Selection.LibraryIds[0].ServerId.ShouldBe("server1");
            settings.Sync.Selection.LibraryIds[0].Uuid.ShouldBe("uuid1");
            settings.Sync.Selection.UserIds.ShouldNotBeNull();
            settings.Sync.Selection.UserIds.Count.ShouldBe(1);
            settings.Sync.Selection.UserIds[0].ShouldBe("user1");

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

        [Fact]
        public async Task TestTraktPlexConnectResponseFromJson()
        {
            TraktPlexConnectResponse? response = await TestUtility.DeserializeJsonAsync<TraktPlexConnectResponse>("Users\\plexconnect.json");

            response.ShouldNotBeNull();
            response.Url.ShouldBe("https://plex.tv/auth");
        }

        [Fact]
        public async Task TestTraktPlexServersResponseFromJson()
        {
            TraktPlexServersResponse? response = await TestUtility.DeserializeJsonAsync<TraktPlexServersResponse>("Users\\plexservers.json");

            response.ShouldNotBeNull();
            response.Servers.ShouldNotBeNull();
            response.Servers.Count.ShouldBe(1);
            response.Servers[0].Id.ShouldBe("server1");
            response.Servers[0].Name.ShouldBe("My Server");
            response.Servers[0].ConnectionCount.ShouldBe(1);
            response.Servers[0].ConnectionTimeout.ShouldBe(5);
            response.Servers[0].Ports.ShouldNotBeNull();
            response.Servers[0].Ports!.Count.ShouldBe(1);
            response.Servers[0].Ports![0].ShouldBe(32400);
            response.Servers[0].Owned.ShouldBeTrue();
            response.Servers[0].Url.ShouldBe("http://127.0.0.1:32400");
        }

        [Fact]
        public async Task TestTraktPlexServerAccountsAndLibrariesFromJson()
        {
            TraktPlexServerAccountsAndLibraries? response = await TestUtility.DeserializeJsonAsync<TraktPlexServerAccountsAndLibraries>("Users\\plexserveraccounts.json");

            response.ShouldNotBeNull();
            response.Accounts.ShouldNotBeNull();
            response.Accounts.Count.ShouldBe(1);
            response.Accounts[0].Id.ShouldBe(1);
            response.Accounts[0].Name.ShouldBe("account1");

            response.Libraries.ShouldNotBeNull();
            response.Libraries.Count.ShouldBe(1);
            response.Libraries[0].Id.ShouldBe(10);
            response.Libraries[0].Uuid.ShouldBe("uuid10");
            response.Libraries[0].Type.ShouldBe("movie");
            response.Libraries[0].Title.ShouldBe("Movies");
            response.Libraries[0].Agent.ShouldBe("plex");
            response.Libraries[0].Scanner.ShouldBe("plex");
            response.Libraries[0].Selected.ShouldBeTrue();
            response.Libraries[0].Url.ShouldBe("http://url");
        }
    }
}
