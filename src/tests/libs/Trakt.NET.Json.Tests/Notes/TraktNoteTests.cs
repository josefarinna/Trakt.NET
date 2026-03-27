namespace TraktNET.Json.Notes
{
    public sealed partial class TraktNoteTests
    {
        [Fact]
        public void TestNoteDefaultConstructor()
        {
            var note = new TraktNote();

            note.ID.ShouldBeNull();
            note.Notes.ShouldBeNull();
            note.Privacy.ShouldBeNull();
            note.Spoiler.ShouldBeNull();
            note.CreatedAt.ShouldBeNull();
            note.UpdatedAt.ShouldBeNull();
            note.User.ShouldBeNull();
        }

        [Fact]
        public async Task TestNoteFromJson()
        {
            TraktNote? note = await TestUtility.DeserializeJsonAsync<TraktNote>("Notes\\note.json");

            note.ShouldNotBeNull();
            note.ID.ShouldBe(49U);
            note.Notes.ShouldBe("Only watch the extended edition.");
            note.Privacy.ShouldBe(TraktListPrivacy.Private);
            note.Spoiler.ShouldBe(false);
            note.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-09-07T20:10:18.000Z"));
            note.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-09-07T20:10:56.000Z"));

            note.User.ShouldNotBeNull();
            note.User.Username.ShouldBe("justin");
            note.User.Private.ShouldBe(false);
            note.User.Name.ShouldBe("Justin Nemeth");
            note.User.VIP.ShouldBe(true);
            note.User.VIPEP.ShouldBe(true);

            note.User!.IDs.ShouldNotBeNull();
            note.User!.IDs!.Slug.ShouldBe("justin");
        }
    }
}
