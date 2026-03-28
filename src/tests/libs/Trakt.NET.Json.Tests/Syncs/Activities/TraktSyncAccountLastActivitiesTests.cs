namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncAccountLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncAccountLastActivitiesDefaultConstructor()
        {
            var accountLastActivities = new TraktSyncAccountLastActivities();

            accountLastActivities.SettingsAt.ShouldBeNull();
            accountLastActivities.FollowedAt.ShouldBeNull();
            accountLastActivities.FollowingAt.ShouldBeNull();
            accountLastActivities.PendingAt.ShouldBeNull();
            accountLastActivities.RequestedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncAccountLastActivitiesFromJson()
        {
            TraktSyncAccountLastActivities? accountLastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncAccountLastActivities>("Syncs\\Activities\\syncaccountlastactivities.json");

            accountLastActivities.ShouldNotBeNull();
            accountLastActivities.SettingsAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-26T18:08:03.000Z"));
            accountLastActivities.FollowedAt.ShouldBe(TestUtility.ParseUTCDateTime("2020-12-14T14:12:28.000Z"));
            accountLastActivities.FollowingAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            accountLastActivities.PendingAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            accountLastActivities.RequestedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
        }
    }
}
