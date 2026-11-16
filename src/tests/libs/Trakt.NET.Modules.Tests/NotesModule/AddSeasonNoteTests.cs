using System.Net;

namespace TraktNET.NotesModule
{
    public sealed partial class AddSeasonNoteTests
    {
        private const string AddNoteUri = "notes";

        [Fact]
        public async Task TestAddSeasonNote()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Notes\\notepost.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, responseContent, null, null, null, null);

            var season = new TraktSeason
            {
                IDs = new TraktSeasonIDs
                {
                    Trakt = 16U,
                }
            };
            string notes = "Every movie they direct is a masterpiece.";

            TraktResponse<TraktNote> response = await client.Notes.AddSeasonNoteAsync(season, notes, cancellationToken: TestContext.Current.CancellationToken);

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
        public async Task TestAddSeasonNoteThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, statusCode);

            var season = new TraktSeason { IDs = new TraktSeasonIDs { Trakt = 1U } };

            Func<Task<TraktResponse<TraktNote>>> act = () => client.Notes.AddSeasonNoteAsync(season, "Notes", cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestAddSeasonNoteThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(AddNoteUri, HttpStatusCode.Created);
            var season = new TraktSeason { IDs = new TraktSeasonIDs { Trakt = 1U } };

            Func<Task<TraktResponse<TraktNote>>> act = () => client.Notes.AddSeasonNoteAsync(null!, "Notes");
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Notes.AddSeasonNoteAsync(season, null!);
            await act.ShouldThrowAsync<TraktPostValidationException>();

            act = () => client.Notes.AddSeasonNoteAsync(season, string.Empty);
            await act.ShouldThrowAsync<TraktPostValidationException>();
        }
    }
}
