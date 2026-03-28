namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncFavoritesLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncFavoritesLastActivitiesDefaultConstructor()
        {
            var favoritesLastActivities = new TraktSyncFavoritesLastActivities();
            favoritesLastActivities.UpdatedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncFavoritesLastActivitiesFromJson()
        {
            TraktSyncFavoritesLastActivities? favoritesLastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncFavoritesLastActivities>("Syncs\\Activities\\syncfavoriteslastactivities.json");

            favoritesLastActivities.ShouldNotBeNull();
            favoritesLastActivities.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-05-14T19:04:12.000Z"));
        }
    }
}
