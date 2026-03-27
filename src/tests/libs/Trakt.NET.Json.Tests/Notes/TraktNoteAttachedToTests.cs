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
        }

        [Fact]
        public async Task TestNoteAttachedToFromJson()
        {
            TraktNoteAttachedTo? noteAttachedTo = await TestUtility.DeserializeJsonAsync<TraktNoteAttachedTo>("Notes\\attachedto.json");

            noteAttachedTo.ShouldNotBeNull();
            noteAttachedTo.Type.ShouldBe(TraktNotesObjectType.Movie);
            noteAttachedTo.ID.ShouldBeNull();
        }

        [Fact]
        public async Task TestNoteAttachedToFromJsonHistory()
        {
            TraktNoteAttachedTo? noteAttachedTo = await TestUtility.DeserializeJsonAsync<TraktNoteAttachedTo>("Notes\\attachedtohistory.json");

            noteAttachedTo.ShouldNotBeNull();
            noteAttachedTo.Type.ShouldBe(TraktNotesObjectType.History);
            noteAttachedTo.ID.ShouldBe(5224U);
        }
    }
}
