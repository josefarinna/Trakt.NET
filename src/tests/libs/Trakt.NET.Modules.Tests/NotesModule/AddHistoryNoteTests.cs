using System.Net;

namespace TraktNET.NotesModule
{
    public sealed class AddHistoryNoteTests
    {
        private const string AddNoteUri = "notes";
        private const ulong HistoryId = 43453489ul;

        [Fact]
        public async Task TestAddHistoryNote()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Notes\\notepost.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, responseContent, null, null, null, null);

            string notes = "Saw this in Dolby Cinema!";

            TraktResponse<TraktNote> response = await client.Notes.AddHistoryNoteAsync(HistoryId, notes, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktNote note = response.Content;
            note.ID.ShouldBe(190U);
            note.Privacy.ShouldBe(TraktListPrivacy.Private);
            note.Spoiler.ShouldBe(false);
            note.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-09-12T20:10:18.000Z"));
            note.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-09-12T20:10:56.000Z"));

            note.User.ShouldNotBeNull();
            note.User.Username.ShouldBe("justin");
            note.User.Private.ShouldBe(false);
            note.User.Name.ShouldBe("Justin Nemeth");
            note.User.VIP.ShouldBe(true);
            note.User.VIPEP.ShouldBe(false);

            note.User.IDs.ShouldNotBeNull();
            note.User.IDs.Slug.ShouldBe("justin");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestAddHistoryNoteThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, statusCode);

            Func<Task<TraktResponse<TraktNote>>> act = () => client.Notes.AddHistoryNoteAsync(HistoryId, "Notes", cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestAddHistoryNoteThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, HttpStatusCode.Created);

            Func<Task<TraktResponse<TraktNote>>> act = () => client.Notes.AddHistoryNoteAsync(HistoryId, null!);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Notes.AddHistoryNoteAsync(HistoryId, string.Empty);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
