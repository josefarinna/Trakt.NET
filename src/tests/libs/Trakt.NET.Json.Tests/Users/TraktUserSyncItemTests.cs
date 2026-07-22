namespace TraktNET.Json.Users
{
    public sealed class TraktUserSyncItemTests
    {
        [Fact]
        public void TestTraktUserSyncItemDefaultConstructor()
        {
            var item = new TraktUserSyncItem();

            item.Kind.ShouldBeNull();
            item.Type.ShouldBeNull();
            item.Movie.ShouldBeNull();
            item.Show.ShouldBeNull();
            item.Season.ShouldBeNull();
            item.Episode.ShouldBeNull();
            item.ServiceId.ShouldBeNull();
            item.ContentId.ShouldBeNull();
            item.ProfileId.ShouldBeNull();
            item.TmdbId.ShouldBeNull();
            item.TmdbSeriesId.ShouldBeNull();
            item.WatchedAt.ShouldBeNull();
            item.RatedAt.ShouldBeNull();
            item.Progress.ShouldBeNull();
            item.RatingType.ShouldBeNull();
            item.RatingValue.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUserSyncItemFromJson()
        {
            IReadOnlyList<TraktUserSyncItem>? items = await TestUtility.DeserializeJsonListAsync<TraktUserSyncItem>("Users\\sync_paused.json");

            items.ShouldNotBeNull();
            items.Count.ShouldBe(1);

            TraktUserSyncItem item = items[0];
            item.ShouldNotBeNull();
            item.Kind.ShouldBe(TraktUserSyncItemKind.History);
            item.Type.ShouldBe(TraktSyncItemType.Movie);
            item.ServiceId.ShouldBe("plex_1");
            item.ContentId.ShouldBe("movie_123");
            item.ProfileId.ShouldBe("profile_1");
            item.TmdbId.ShouldBe(550U);
            item.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-11-20T12:00:00.000Z"));
            item.Progress.ShouldBe(45.5f);

            item.Movie.ShouldNotBeNull();
            item.Movie.Title.ShouldBe("Fight Club");
            item.Movie.Year.ShouldBe(1999U);
            item.Movie.IDs.ShouldNotBeNull();
            item.Movie.IDs.Trakt.ShouldBe(550U);
        }
    }
}
