namespace TraktNET.Json.Notes
{
    public sealed partial class TraktNoteAttachedToTests
    {
        [Fact]
        public void TestNoteAttachedToDefaultConstructor()
        {
            var noteAttachedTo = new TraktNoteAttachedTo();

            noteAttachedTo.Type.ShouldBeNull();
            noteAttachedTo.ID.ShouldBeNull();
            noteAttachedTo.WatchedAt.ShouldBeNull();
            noteAttachedTo.CollectedAt.ShouldBeNull();
            noteAttachedTo.RatedAt.ShouldBeNull();
            noteAttachedTo.Rating.ShouldBeNull();
        }

        [Fact]
        public async Task TestNoteAttachedToFromJson()
        {
            TraktNoteAttachedTo? noteAttachedTo = await TestUtility.DeserializeJsonAsync<TraktNoteAttachedTo>("Notes\\attachedto.json");

            noteAttachedTo.ShouldNotBeNull();
            noteAttachedTo.Type.ShouldBe(TraktNotesObjectType.Movie);
            noteAttachedTo.ID.ShouldBeNull();
            noteAttachedTo.WatchedAt.ShouldBeNull();
            noteAttachedTo.CollectedAt.ShouldBeNull();
            noteAttachedTo.RatedAt.ShouldBeNull();
            noteAttachedTo.Rating.ShouldBeNull();
        }

        [Fact]
        public async Task TestNoteAttachedToFromJsonHistory()
        {
            TraktNoteAttachedTo? noteAttachedTo = await TestUtility.DeserializeJsonAsync<TraktNoteAttachedTo>("Notes\\attachedtohistory.json");

            noteAttachedTo.ShouldNotBeNull();
            noteAttachedTo.Type.ShouldBe(TraktNotesObjectType.History);
            noteAttachedTo.ID.ShouldBe(5224U);
        }

        [Fact]
        public async Task TestNoteAttachedToFromJsonFull()
        {
            TraktNoteAttachedTo? noteAttachedTo = await TestUtility.DeserializeJsonAsync<TraktNoteAttachedTo>("Notes\\attachedtofull.json");

            noteAttachedTo.ShouldNotBeNull();
            noteAttachedTo.Type.ShouldBe(TraktNotesObjectType.History);
            noteAttachedTo.ID.ShouldBe(5224U);
            noteAttachedTo.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-06-01T12:30:00.000Z"));
            noteAttachedTo.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-05-15T08:00:00.000Z"));
            noteAttachedTo.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-06-02T14:45:00.000Z"));
            noteAttachedTo.Rating.ShouldBe(9);
        }
    }
}
