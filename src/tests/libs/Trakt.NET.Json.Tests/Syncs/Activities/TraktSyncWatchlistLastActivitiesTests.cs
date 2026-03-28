namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncWatchlistLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncWatchlistLastActivitiesDefaultConstructor()
        {
            var watchlistLastActivities = new TraktSyncWatchlistLastActivities();
            watchlistLastActivities.UpdatedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncWatchlistLastActivitiesFromJson()
        {
            TraktSyncWatchlistLastActivities? watchlistLastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncWatchlistLastActivities>("Syncs\\Activities\\syncwatchlistslastactivities.json");

            watchlistLastActivities.ShouldNotBeNull();
            watchlistLastActivities.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-22T16:39:23.000Z"));
        }
    }
}
