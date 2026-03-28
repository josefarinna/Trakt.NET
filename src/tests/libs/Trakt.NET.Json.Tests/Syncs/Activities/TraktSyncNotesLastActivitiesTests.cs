namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncNotesLastActivitiesTests
    {
        [Fact]
        public void TestTraktSyncNotesLastActivitiesDefaultConstructor()
        {
            var notesLastActivities = new TraktSyncNotesLastActivities();
            notesLastActivities.UpdatedAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncNotesLastActivitiesFromJson()
        {
            TraktSyncNotesLastActivities? notesLastActivities = await TestUtility.DeserializeJsonAsync<TraktSyncNotesLastActivities>("Syncs\\Activities\\syncnoteslastactivities.json");

            notesLastActivities.ShouldNotBeNull();
            notesLastActivities.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
        }
    }
}
