namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncListsLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncListsLastActivitiesDefaultConstructor()
        {
            var listsLastActivities = new TraktSyncListsLastActivities();

            listsLastActivities.LikedAt.ShouldBeNull();
            listsLastActivities.ReactedAt.ShouldBeNull();
            listsLastActivities.UpdatedAt.ShouldBeNull();
            listsLastActivities.CommentedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncListsLastActivitiesFromJson()
        {
            TraktSyncListsLastActivities? listsLastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncListsLastActivities>("Syncs\\Activities\\synclistslastactivities.json");

            listsLastActivities.ShouldNotBeNull();
            listsLastActivities.LikedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-06-28T21:32:53.000Z"));
            listsLastActivities.ReactedAt.ShouldBe(TestUtility.ParseUTCDateTime("2012-10-09T13:13:26.000Z"));
            listsLastActivities.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-10-14T21:47:15.000Z"));
            listsLastActivities.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
        }
    }
}
