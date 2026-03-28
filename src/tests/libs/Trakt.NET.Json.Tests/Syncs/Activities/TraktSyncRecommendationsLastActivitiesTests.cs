namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncRecommendationsLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncRecommendationsLastActivitiesDefaultConstructor()
        {
            var recommendationsLastActivities = new TraktSyncRecommendationsLastActivities();
            recommendationsLastActivities.UpdatedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncRecommendationsLastActivitiesFromJson()
        {
            TraktSyncRecommendationsLastActivities? recommendationsLastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncRecommendationsLastActivities>("Syncs\\Activities\\syncrecomendationslastactivities.json");

            recommendationsLastActivities.ShouldNotBeNull();
            recommendationsLastActivities.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-05-14T19:04:12.000Z"));
        }
    }
}
