using System.Net;

namespace TraktNET.NotesModule
{
    public sealed class DeleteNoteTests
    {
        private const ulong NoteID = 190UL;
        private readonly string DeleteNoteUri = $"notes/{NoteID}";

        [Fact]
        public async Task TestDeleteNote()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DeleteNoteUri, HttpStatusCode.NoContent);

            TraktResponse response = await client.Notes.DeleteNoteAsync(NoteID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestDeleteNoteThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(DeleteNoteUri, statusCode);

            Func<Task<TraktResponse>> act = () => client.Notes.DeleteNoteAsync(NoteID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
