using System.Net;

namespace TraktNET.NotesModule
{
    public sealed class UpdateNoteTests
    {
        private const ulong NoteID = 190UL;
        private readonly string UpdateNoteUri = $"notes/{NoteID}";
        private const string Notes = "Watch this in IMAX!";

        [Fact]
        public async Task TestUpdateNote()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Notes\\notepost.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateNoteUri, responseContent, null, null, null, null);

            TraktResponse<TraktNote> response = await client.Notes.UpdateNoteAsync(NoteID, Notes, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestUpdateNoteThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(UpdateNoteUri, statusCode);

            Func<Task<TraktResponse<TraktNote>>> act = () => client.Notes.UpdateNoteAsync(NoteID, Notes, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
