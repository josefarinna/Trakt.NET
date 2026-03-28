namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncEpisodesLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncEpisodesLastActivitiesDefaultConstructor()
        {
            var episodesLastActivities = new TraktSyncEpisodesLastActivities();

            episodesLastActivities.WatchedAt.ShouldBeNull();
            episodesLastActivities.CollectedAt.ShouldBeNull();
            episodesLastActivities.RatedAt.ShouldBeNull();
            episodesLastActivities.WatchlistedAt.ShouldBeNull();
            episodesLastActivities.CommentedAt.ShouldBeNull();
            episodesLastActivities.PausedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncEpisodesLastActivitiesFromJson()
        {
            TraktSyncEpisodesLastActivities? episodesLastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncEpisodesLastActivities>("Syncs\\Activities\\syncepisodeslastactivities.json");

            episodesLastActivities.ShouldNotBeNull();
            episodesLastActivities.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-30T13:38:37.000Z"));
            episodesLastActivities.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-11-09T23:16:22.000Z"));
            episodesLastActivities.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            episodesLastActivities.WatchlistedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            episodesLastActivities.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            episodesLastActivities.PausedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
        }
    }
}
