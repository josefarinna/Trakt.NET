namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncSeasonsLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncSeasonsLastActivitiesDefaultConstructor()
        {
            var seasonsLastActivities = new TraktSyncSeasonsLastActivities();

            seasonsLastActivities.RatedAt.ShouldBeNull();
            seasonsLastActivities.WatchlistedAt.ShouldBeNull();
            seasonsLastActivities.CommentedAt.ShouldBeNull();
            seasonsLastActivities.HiddenAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncSeasonsLastActivitiesFromJson()
        {
            TraktSyncSeasonsLastActivities? seasonsLastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncSeasonsLastActivities>("Syncs\\Activities\\syncseasonslastactivities.json");

            seasonsLastActivities.ShouldNotBeNull();
            seasonsLastActivities.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-06-25T23:46:39.000Z"));
            seasonsLastActivities.WatchlistedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-10-06T17:42:50.000Z"));
            seasonsLastActivities.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            seasonsLastActivities.HiddenAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
        }
    }
}
