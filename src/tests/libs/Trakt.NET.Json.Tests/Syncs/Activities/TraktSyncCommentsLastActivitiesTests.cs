namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCommentsLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncCommentsLastActivitiesDefaultConstructor()
        {
            var commentsLastActivities = new TraktSyncCommentsLastActivities();

            commentsLastActivities.LikedAt.ShouldBeNull();
            commentsLastActivities.ReactedAt.ShouldBeNull();
            commentsLastActivities.BlockedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncCommentsLastActivitiesFromJson()
        {
            TraktSyncCommentsLastActivities? commentsLastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncCommentsLastActivities>("Syncs\\Activities\\synccomentslastactivities.json");

            commentsLastActivities.ShouldNotBeNull();
            commentsLastActivities.LikedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            commentsLastActivities.ReactedAt.ShouldBe(TestUtility.ParseUTCDateTime("2012-10-09T13:13:26.000Z"));
            commentsLastActivities.BlockedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
        }
    }
}
