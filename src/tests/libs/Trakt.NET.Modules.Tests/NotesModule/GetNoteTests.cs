using System.Net;

namespace TraktNET.NotesModule
{
    public sealed class GetNoteTests
    {
        private const ulong NoteID = 190UL;
        private readonly string GetNoteUri = $"notes/{NoteID}";

        [Fact]
        public async Task TestGetNote()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Notes\\notepost.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetNoteUri, responseContent, null, null, null, null);

            TraktResponse<TraktNote> response = await client.Notes.GetNoteAsync(NoteID, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktNote note = response.Content!;
            note.ID.ShouldBe(NoteID);
            note.Notes.ShouldBe("Watch this in IMAX!");
            note.Privacy.ShouldBe(TraktListPrivacy.Private);
            note.Spoiler.ShouldBe(false);
            note.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-09-12T20:10:18.000Z"));
            note.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-09-12T20:10:56.000Z"));

            note.User.ShouldNotBeNull();
            note.User.Username.ShouldBe("justin");
            note.User.IDs.ShouldNotBeNull();
            note.User.IDs.Slug.ShouldBe("justin");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetNoteThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetNoteUri, statusCode);

            Func<Task<TraktResponse<TraktNote>>> act = () => client.Notes.GetNoteAsync(NoteID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
