using System.Net;

namespace TraktNET.NotesModule
{
    public sealed class AddCollectionMovieNoteTests
    {
        private const string AddNoteUri = "notes";

        [Fact]
        public async Task TestAddCollectionMovieNote()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Notes\\notepost.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, responseContent, null, null, null, null);

            var movie = new TraktMovie
            {
                Title = "TRON: Legacy",
                Year = 2010,
                IDs = new TraktMovieIDs
                {
                    Trakt = 1U,
                    Slug = "tron-legacy-2010"
                }
            };
            string notes = "Watch this in IMAX!";

            TraktResponse<TraktNote> response = await client.Notes.AddCollectionMovieNoteAsync(movie, notes, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestAddCollectionMovieNoteThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, statusCode);

            var movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 1U } };

            Func<Task<TraktResponse<TraktNote>>> act = () => client.Notes.AddCollectionMovieNoteAsync(movie, "Notes", cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestAddCollectionMovieNoteThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, HttpStatusCode.Created);
            var movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 1U } };

            Func<Task<TraktResponse<TraktNote>>> act = () => client.Notes.AddCollectionMovieNoteAsync(null!, "Notes");
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Notes.AddCollectionMovieNoteAsync(movie, null!);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Notes.AddCollectionMovieNoteAsync(movie, string.Empty);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
