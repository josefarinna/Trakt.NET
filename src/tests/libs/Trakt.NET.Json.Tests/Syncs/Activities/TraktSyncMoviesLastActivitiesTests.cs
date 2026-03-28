namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncMoviesLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncMoviesLastActivitiesDefaultConstructor()
        {
            var moviesLastActivities = new TraktSyncMoviesLastActivities();

            moviesLastActivities.WatchedAt.ShouldBeNull();
            moviesLastActivities.CollectedAt.ShouldBeNull();
            moviesLastActivities.RatedAt.ShouldBeNull();
            moviesLastActivities.WatchlistedAt.ShouldBeNull();
            moviesLastActivities.FavoritedAt.ShouldBeNull();
            moviesLastActivities.RecommendationsAt.ShouldBeNull();
            moviesLastActivities.CommentedAt.ShouldBeNull();
            moviesLastActivities.PausedAt.ShouldBeNull();
            moviesLastActivities.HiddenAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncMoviesLastActivitiesFromJson()
        {
            TraktSyncMoviesLastActivities? moviesLastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncMoviesLastActivities>("Syncs\\Activities\\syncmovieslastactivities.json");

            moviesLastActivities.ShouldNotBeNull();
            moviesLastActivities.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-11T20:00:28.000Z"));
            moviesLastActivities.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            moviesLastActivities.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-11-07T03:11:00.000Z"));
            moviesLastActivities.WatchlistedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-04T13:48:29.000Z"));
            moviesLastActivities.FavoritedAt.ShouldBe(TestUtility.ParseUTCDateTime("2021-04-07T22:07:11.000Z"));
            moviesLastActivities.RecommendationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2021-04-07T22:07:11.000Z"));
            moviesLastActivities.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            moviesLastActivities.PausedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            moviesLastActivities.HiddenAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
        }
    }
}
