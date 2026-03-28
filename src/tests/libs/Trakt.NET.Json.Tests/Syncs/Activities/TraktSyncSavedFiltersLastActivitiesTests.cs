namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncSavedFiltersLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncSavedFiltersLastActivitiesDefaultConstructor()
        {
            var savedFiltersLastActivities = new TraktSyncSavedFiltersLastActivities();
            savedFiltersLastActivities.UpdatedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncSavedFiltersLastActivitiesFromJson()
        {
            TraktSyncSavedFiltersLastActivities? savedFiltersLastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncSavedFiltersLastActivities>("Syncs\\Activities\\syncsavedfilterslastactivities.json");

            savedFiltersLastActivities.ShouldNotBeNull();
            savedFiltersLastActivities.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
        }
    }
}
