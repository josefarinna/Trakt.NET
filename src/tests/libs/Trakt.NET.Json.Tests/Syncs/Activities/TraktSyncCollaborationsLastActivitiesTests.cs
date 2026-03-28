namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCollaborationsLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncCollaborationsLastActivitiesDefaultConstructor()
        {
            var collaborationsLastActivities = new TraktSyncCollaborationsLastActivities();
            collaborationsLastActivities.UpdatedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncCollaborationsLastActivitiesFromJson()
        {
            TraktSyncCollaborationsLastActivities? collaborationsLastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncCollaborationsLastActivities>("Syncs\\Activities\\synccollaborationslastactivities.json");

            collaborationsLastActivities.ShouldNotBeNull();
            collaborationsLastActivities.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
        }
    }
}
