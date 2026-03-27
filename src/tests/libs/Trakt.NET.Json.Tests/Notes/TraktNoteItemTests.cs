namespace TraktNET.Json.Notes
{
    public sealed partial class TraktNoteItemTests
    {
        [Fact]
        public void TestNoteItemDefaultConstructor()
        {
            var noteItem = new TraktNoteItem();

            noteItem.AttachedTo.ShouldBeNull();
            noteItem.Type.ShouldBeNull();
            noteItem.Movie.ShouldBeNull();
            noteItem.Show.ShouldBeNull();
            noteItem.Season.ShouldBeNull();
            noteItem.Episode.ShouldBeNull();
            noteItem.Person.ShouldBeNull();
            noteItem.Note.ShouldBeNull();
        }

        [Fact]
        public async Task TestNoteItemFromJsonMovie()
        {
            TraktNoteItem? noteItem = await TestUtility.DeserializeJsonAsync<TraktNoteItem>("Notes\\noteitem.json");

            noteItem.ShouldNotBeNull();

            noteItem.AttachedTo.ShouldNotBeNull();
            noteItem.AttachedTo.Type.ShouldBe(TraktNotesObjectType.Movie);
            noteItem.AttachedTo.ID.ShouldBeNull();

            noteItem.Type.ShouldBe(TraktListItemType.Movie);

            noteItem.Movie.ShouldNotBeNull();
            noteItem.Movie!.Title.ShouldBe("Batman Begins");
            noteItem.Movie.Year.ShouldBe(2005U);
            noteItem.Movie.IDs.ShouldNotBeNull();
            noteItem.Movie.IDs.Trakt.ShouldBe(1U);
            noteItem.Movie.IDs.Slug.ShouldBe("batman-begins-2005");
            noteItem.Movie.IDs.IMDB.ShouldBe("tt0372784");
            noteItem.Movie.IDs.TMDB.ShouldBe(272U);

            noteItem.Show.ShouldBeNull();
            noteItem.Season.ShouldBeNull();
            noteItem.Episode.ShouldBeNull();
            noteItem.Person.ShouldBeNull();

            noteItem.Note.ShouldNotBeNull();
            noteItem.Note.ID.ShouldBe(49U);
            noteItem.Note.Notes.ShouldBe("Only watch the extended edition.");
            noteItem.Note.Privacy.ShouldBe(TraktListPrivacy.Private);
            noteItem.Note.Spoiler.ShouldBe(false);
            noteItem.Note.CreatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-09-07T20:10:18.000Z"));
            noteItem.Note.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-09-07T20:10:56.000Z"));

            noteItem.Note.User.ShouldNotBeNull();
            noteItem.Note.User.Username.ShouldBe("justin");
            noteItem.Note.User.IDs.ShouldNotBeNull();
            noteItem.Note.User.IDs.Slug.ShouldBe("justin");
        }

        [Fact]
        public async Task TestNoteItemFromJsonMovieHistory()
        {
            TraktNoteItem? noteItem = await TestUtility.DeserializeJsonAsync<TraktNoteItem>("Notes\\noteitemhistory.json");

            noteItem.ShouldNotBeNull();

            noteItem.AttachedTo.ShouldNotBeNull();
            noteItem.AttachedTo!.Type.ShouldBe(TraktNotesObjectType.History);
            noteItem.AttachedTo.ID.ShouldBe(3253454U);

            noteItem.Type.ShouldBe(TraktListItemType.Movie);

            noteItem.Movie.ShouldNotBeNull();
            noteItem.Movie.Title.ShouldBe("Batman Begins");
            noteItem.Movie.IDs.ShouldNotBeNull();
            noteItem.Movie.IDs.Trakt.ShouldBe(1U);

            noteItem.Note.ShouldNotBeNull();
            noteItem.Note.ID.ShouldBe(49U);
        }

        private const string JSON_MOVIE =
            @"{
                ""attached_to"": {
                  ""type"": ""movie""
                },
                ""type"": ""movie"",
                ""movie"": {
                  ""title"": ""Batman Begins"",
                  ""year"": 2005,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""batman-begins-2005"",
                    ""imdb"": ""tt0372784"",
                    ""tmdb"": 272
                  }
                },
                ""note"": {
                  ""id"": 49,
                  ""notes"": ""Only watch the extended edition."",
                  ""privacy"": ""private"",
                  ""spoiler"": false,
                  ""created_at"": ""2023-09-07T20:10:18.000Z"",
                  ""updated_at"": ""2023-09-07T20:10:56.000Z"",
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                }
              }";
    }
}
