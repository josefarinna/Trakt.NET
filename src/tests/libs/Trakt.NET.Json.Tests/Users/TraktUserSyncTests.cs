namespace TraktNET.Json.Users
{
    public sealed class TraktUserSyncTests
    {
        [Fact]
        public void TestTraktUserSyncDefaultConstructor()
        {
            var sync = new TraktUserSync();

            sync.Id.ShouldBe(0UL);
            sync.CreatedAt.ShouldBeNull();
            sync.Kind.ShouldBeNull();
            sync.Source.ShouldBeNull();
            sync.Application.ShouldBeNull();
            sync.Undone.ShouldBeNull();
            sync.UndoneAt.ShouldBeNull();
            sync.Items.ShouldBeNull();
            sync.PausedCount.ShouldBeNull();
            sync.SkippedCount.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserSyncFromJson()
        {
            TraktUserSync? sync = await TestUtility.DeserializeJsonAsync<TraktUserSync>("Users\\sync_details.json");

            sync.ShouldNotBeNull();
            sync.Id.ShouldBe(12345UL);
            sync.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-11-20T12:00:00.000Z"));
            sync.Kind.ShouldBe(TraktUserSyncType.Plex);
            sync.Source.ShouldBe("plex");
            sync.Application.ShouldBe("Plex Media Server");
            sync.Undone.ShouldBe(false);
            sync.UndoneAt.ShouldBeNull();
            sync.PausedCount.ShouldBe(2U);
            sync.SkippedCount.ShouldBe(1U);

            sync.Items.ShouldNotBeNull();
            sync.Items.History.ShouldNotBeNull();
            sync.Items.History.Movies.ShouldBe(5U);
            sync.Items.History.Episodes.ShouldBe(12U);
            sync.Items.History.Shows.ShouldBe(2U);
            sync.Items.History.Seasons.ShouldBe(3U);
        }
    }
}
