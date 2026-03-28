namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncShowsLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncShowsLastActivitiesDefaultConstructor()
        {
            var showsLastActivities = new TraktSyncShowsLastActivities();

            showsLastActivities.RatedAt.ShouldBeNull();
            showsLastActivities.WatchlistedAt.ShouldBeNull();
            showsLastActivities.FavoritedAt.ShouldBeNull();
            showsLastActivities.RecommendationsAt.ShouldBeNull();
            showsLastActivities.CommentedAt.ShouldBeNull();
            showsLastActivities.HiddenAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncShowsLastActivitiesFromJson()
        {
            TraktSyncShowsLastActivities? showsLastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncShowsLastActivities>("Syncs\\Activities\\syncshowslastactivities.json");

            showsLastActivities.ShouldNotBeNull();
            showsLastActivities.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-06-25T23:46:52.000Z"));
            showsLastActivities.WatchlistedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-22T16:39:23.000Z"));
            showsLastActivities.FavoritedAt.ShouldBe(TestUtility.ParseUTCDateTime("2021-06-28T00:13:46.000Z"));
            showsLastActivities.RecommendationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2021-06-28T00:13:46.000Z"));
            showsLastActivities.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            showsLastActivities.HiddenAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-12-20T19:34:50.000Z"));
        }
    }
}
