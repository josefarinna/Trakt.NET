namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCommentsLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncCommentsLastActivitiesDefaultConstructor()
        {
            var commentsLastActivities = new TraktSyncCommentsLastActivities();

            commentsLastActivities.LikedAt.ShouldBeNull();
            commentsLastActivities.BlockedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncCommentsLastActivitiesFromJson()
        {
            TraktSyncCommentsLastActivities? commentsLastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncCommentsLastActivities>("Syncs\\Activities\\synccomentslastactivities.json");

            commentsLastActivities.ShouldNotBeNull();
            commentsLastActivities.LikedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            commentsLastActivities.BlockedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
        }
    }
}
