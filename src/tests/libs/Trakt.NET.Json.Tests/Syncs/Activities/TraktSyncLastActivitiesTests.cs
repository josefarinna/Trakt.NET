namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncLastActivitiesDefaultConstructor()
        {
            var lastActivities = new TraktSyncLastActivities();

            lastActivities.All.ShouldBeNull();
            lastActivities.Movies.ShouldBeNull();
            lastActivities.Episodes.ShouldBeNull();
            lastActivities.Shows.ShouldBeNull();
            lastActivities.Seasons.ShouldBeNull();
            lastActivities.Comments.ShouldBeNull();
            lastActivities.Lists.ShouldBeNull();
            lastActivities.Watchlist.ShouldBeNull();
            lastActivities.Favorites.ShouldBeNull();
            lastActivities.Recommendations.ShouldBeNull();
            lastActivities.Collaborations.ShouldBeNull();
            lastActivities.Account.ShouldBeNull();
            lastActivities.SavedFilters.ShouldBeNull();
            lastActivities.Notes.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncLastActivitiesFromJson()
        {
            TraktSyncLastActivities? lastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncLastActivities>("Syncs\\Activities\\synclastactivities.json");

            lastActivities.ShouldNotBeNull();
            lastActivities.All.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-30T13:38:37.000Z"));

            lastActivities.Movies.ShouldNotBeNull();
            lastActivities.Movies.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-11T20:00:28.000Z"));
            lastActivities.Movies.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            lastActivities.Movies.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-11-07T03:11:00.000Z"));
            lastActivities.Movies.WatchlistedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-04T13:48:29.000Z"));
            lastActivities.Movies.FavoritedAt.ShouldBe(TestUtility.ParseUTCDateTime("2021-04-07T22:07:11.000Z"));
            lastActivities.Movies.RecommendationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2021-04-07T22:07:11.000Z"));
            lastActivities.Movies.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            lastActivities.Movies.PausedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            lastActivities.Movies.HiddenAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            lastActivities.Episodes.ShouldNotBeNull();
            lastActivities.Episodes.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-30T13:38:37.000Z"));
            lastActivities.Episodes.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-11-09T23:16:22.000Z"));
            lastActivities.Episodes.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            lastActivities.Episodes.WatchlistedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            lastActivities.Episodes.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            lastActivities.Episodes.PausedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            lastActivities.Shows.ShouldNotBeNull();
            lastActivities.Shows.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-06-25T23:46:52.000Z"));
            lastActivities.Shows.WatchlistedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-22T16:39:23.000Z"));
            lastActivities.Shows.FavoritedAt.ShouldBe(TestUtility.ParseUTCDateTime("2021-06-28T00:13:46.000Z"));
            lastActivities.Shows.RecommendationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2021-06-28T00:13:46.000Z"));
            lastActivities.Shows.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            lastActivities.Shows.HiddenAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-12-20T19:34:50.000Z"));
            lastActivities.Shows.DroppedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-03-31T14:56:06.000Z"));

            lastActivities.Seasons.ShouldNotBeNull();
            lastActivities.Seasons.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-06-25T23:46:39.000Z"));
            lastActivities.Seasons.WatchlistedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-10-06T17:42:50.000Z"));
            lastActivities.Seasons.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            lastActivities.Seasons.HiddenAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            lastActivities.Comments.ShouldNotBeNull();
            lastActivities.Comments.LikedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            lastActivities.Comments.ReactedAt.ShouldBe(TestUtility.ParseUTCDateTime("2012-10-09T13:13:26.000Z"));
            lastActivities.Comments.BlockedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            lastActivities.Lists.ShouldNotBeNull();
            lastActivities.Lists.LikedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-06-28T21:32:53.000Z"));
            lastActivities.Lists.ReactedAt.ShouldBe(TestUtility.ParseUTCDateTime("2012-10-09T13:13:26.000Z"));
            lastActivities.Lists.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-10-14T21:47:15.000Z"));
            lastActivities.Lists.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            lastActivities.Watchlist.ShouldNotBeNull();
            lastActivities.Watchlist.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-22T16:39:23.000Z"));

            lastActivities.Favorites.ShouldNotBeNull();
            lastActivities.Favorites.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-05-14T19:04:12.000Z"));

            lastActivities.Recommendations.ShouldNotBeNull();
            lastActivities.Recommendations.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-05-14T19:04:12.000Z"));

            lastActivities.Collaborations.ShouldNotBeNull();
            lastActivities.Collaborations.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            lastActivities.Account.ShouldNotBeNull();
            lastActivities.Account.SettingsAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-26T18:08:03.000Z"));
            lastActivities.Account.FollowedAt.ShouldBe(TestUtility.ParseUTCDateTime("2020-12-14T14:12:28.000Z"));
            lastActivities.Account.FollowingAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            lastActivities.Account.PendingAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            lastActivities.Account.RequestedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            lastActivities.SavedFilters.ShouldNotBeNull();
            lastActivities.SavedFilters.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            lastActivities.Notes.ShouldNotBeNull();
            lastActivities.Notes.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
        }
    }
}
