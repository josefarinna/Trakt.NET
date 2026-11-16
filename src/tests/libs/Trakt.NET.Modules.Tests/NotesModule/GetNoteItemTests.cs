using System.Net;

namespace TraktNET.NotesModule
{
    public sealed class GetNoteItemTests
    {
        private const ulong NoteID = 190UL;
        private readonly string GetNoteItemUri = $"notes/{NoteID}/item";

        [Fact]
        public async Task TestGetNoteItem()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Notes\\noteitempost.json");

            TraktClient client = ModuleTestUtility.GetClient(GetNoteItemUri, responseContent, null, null, null, null);

            TraktResponse<TraktNoteItem> response = await client.Notes.GetNoteItemAsync(NoteID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktNoteItem note = response.Content;
            note.AttachedTo.ShouldNotBeNull();
            note.AttachedTo.Type.ShouldBe(TraktNotesObjectType.Movie);
            note.Type.ShouldBe(TraktListItemType.Movie);
            
            note.Movie.ShouldNotBeNull();
            note.Movie.Title.ShouldBe("Batman Begins");
            note.Movie.Year.ShouldBe(2005U);
            note.Movie.IDs.ShouldNotBeNull();
            note.Movie.IDs.Trakt.ShouldBe(1U);
            note.Movie.IDs.Slug.ShouldBe("batman-begins-2005");
            note.Movie.IDs.IMDB.ShouldBe("tt0372784");
            note.Movie.IDs.TMDB.ShouldBe(272U);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetNoteItemThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetNoteItemUri, statusCode);

            Func<Task<TraktResponse<TraktNoteItem>>> act = () => client.Notes.GetNoteItemAsync(NoteID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
