using System.Net;

namespace TraktNET.NotesModule
{
    public sealed class AddListNoteTests
    {
        private const string AddNoteUri = "notes";

        [Fact]
        public async Task TestAddListNote()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Notes\\notepost.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, responseContent, null, null, null, null);

            var list = new TraktList
            {
                Name = "Star Wars Movies",
                IDs = new TraktListIDs
                {
                    Trakt = 55U,
                    Slug = "star-wars-movies"
                }
            };
            string notes = "My favorite Star Wars list!";

            TraktResponse<TraktNote> response = await client.Notes.AddListNoteAsync(list, notes, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestAddListNoteThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, statusCode);

            var list = new TraktList { IDs = new TraktListIDs { Trakt = 55U } };

            Func<Task<TraktResponse<TraktNote>>> act = () => client.Notes.AddListNoteAsync(list, "Notes", cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestAddListNoteThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, HttpStatusCode.Created);
            var list = new TraktList { IDs = new TraktListIDs { Trakt = 55U } };

            Func<Task<TraktResponse<TraktNote>>> act = () => client.Notes.AddListNoteAsync(null!, "Notes");
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Notes.AddListNoteAsync(list, null!);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Notes.AddListNoteAsync(list, string.Empty);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
