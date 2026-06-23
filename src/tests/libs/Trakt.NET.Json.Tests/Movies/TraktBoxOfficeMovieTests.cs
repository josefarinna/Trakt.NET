namespace TraktNET.Json.Movies
{
    public sealed class TraktBoxOfficeMovieTests
    {
        [Fact]
        public void TestTraktBoxOfficeMovieConstructor()
        {
            var boxOfficeMovie = new TraktBoxOfficeMovie();

            boxOfficeMovie.Revenue.ShouldBeNull();
            boxOfficeMovie.Title.ShouldBeNull();
            boxOfficeMovie.Year.ShouldBeNull();
            boxOfficeMovie.IDs.ShouldBeNull();
            boxOfficeMovie.Tagline.ShouldBeNull();
            boxOfficeMovie.Overview.ShouldBeNull();
            boxOfficeMovie.Released.ShouldBeNull();
            boxOfficeMovie.Runtime.ShouldBeNull();
            boxOfficeMovie.Country.ShouldBeNull();
            boxOfficeMovie.Trailer.ShouldBeNull();
            boxOfficeMovie.Homepage.ShouldBeNull();
            boxOfficeMovie.Status.ShouldBeNull();
            boxOfficeMovie.Rating.ShouldBeNull();
            boxOfficeMovie.Votes.ShouldBeNull();
            boxOfficeMovie.CommentCount.ShouldBeNull();
            boxOfficeMovie.UpdatedAt.ShouldBeNull();
            boxOfficeMovie.Language.ShouldBeNull();
            boxOfficeMovie.Languages.ShouldBeNull();
            boxOfficeMovie.AvailableTranslations.ShouldBeNull();
            boxOfficeMovie.Genres.ShouldBeNull();
            boxOfficeMovie.Certification.ShouldBeNull();

            boxOfficeMovie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktBoxOfficeMovieFromJsonMinimal()
        {
            TraktBoxOfficeMovie? boxOfficeMovie = await TestUtility.DeserializeJsonAsync<TraktBoxOfficeMovie>("Movies\\boxofficemovie_minimal.json");

            boxOfficeMovie.ShouldNotBeNull();

            boxOfficeMovie.Revenue.ShouldBe(52000000U);

            boxOfficeMovie.Title.ShouldBe("Beetlejuice Beetlejuice");
            boxOfficeMovie.Year.ShouldBe(2024U);
            boxOfficeMovie.IDs.ShouldNotBeNull();
            boxOfficeMovie.IDs.Trakt.ShouldBe(734869U);
            boxOfficeMovie.IDs.Slug.ShouldBe("beetlejuice-beetlejuice-2024");
            boxOfficeMovie.IDs.IMDB.ShouldBe("tt2049403");
            boxOfficeMovie.IDs.TMDB.ShouldBe(917496U);
            boxOfficeMovie.IDs.HasAnyID.ShouldBe(true);
            boxOfficeMovie.IDs.BestID.ShouldBe("beetlejuice-beetlejuice-2024");

            boxOfficeMovie.ToString().ShouldBe("Beetlejuice Beetlejuice (2024)");
        }

        [Fact]
        public async Task TestTraktBoxOfficeMovieFromJson()
        {
            TraktBoxOfficeMovie? boxOfficeMovie = await TestUtility.DeserializeJsonAsync<TraktBoxOfficeMovie>("Movies\\boxofficemovie.json");

            boxOfficeMovie.ShouldNotBeNull();

            boxOfficeMovie.Revenue.ShouldBe(52000000U);

            boxOfficeMovie.Title.ShouldBe("Beetlejuice Beetlejuice");
            boxOfficeMovie.Year.ShouldBe(2024U);
            boxOfficeMovie.IDs.ShouldNotBeNull();
            boxOfficeMovie.IDs.Trakt.ShouldBe(734869U);
            boxOfficeMovie.IDs.Slug.ShouldBe("beetlejuice-beetlejuice-2024");
            boxOfficeMovie.IDs.IMDB.ShouldBe("tt2049403");
            boxOfficeMovie.IDs.TMDB.ShouldBe(917496U);
            boxOfficeMovie.IDs.HasAnyID.ShouldBe(true);
            boxOfficeMovie.IDs.BestID.ShouldBe("beetlejuice-beetlejuice-2024");

            boxOfficeMovie.ToString().ShouldBe("Beetlejuice Beetlejuice (2024)");

            boxOfficeMovie.Tagline.ShouldBe("The ghost with the most is back.");
            boxOfficeMovie.Overview.ShouldBe("After a family tragedy, three generations of the Deetz family return home to Winter River.");

#if NET7_0_OR_GREATER
            boxOfficeMovie.Released.ShouldBe(TestUtility.ParseDate("2024-09-06"));
#else
            boxOfficeMovie.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-06T00:00:00.000Z"));
#endif
            boxOfficeMovie.Runtime.ShouldBe(105U);
            boxOfficeMovie.Country.ShouldBe("us");
            boxOfficeMovie.Trailer.ShouldBe("https://youtube.com/watch?v=As-vKW4ZboU");
            boxOfficeMovie.Homepage.ShouldBe("http://www.beetlejuicemovie.com");
            boxOfficeMovie.Status.ShouldBe(TraktMovieStatus.Released);
            boxOfficeMovie.Rating.ShouldBe(7.16738f);
            boxOfficeMovie.Votes.ShouldBe(1631U);
            boxOfficeMovie.CommentCount.ShouldBe(29U);
            boxOfficeMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-21T17:39:23.000Z"));
            boxOfficeMovie.Language.ShouldBe("en");
            boxOfficeMovie.Languages.ShouldNotBeNull();
            boxOfficeMovie.Languages.Count.ShouldBe(3);
            boxOfficeMovie.Languages.ShouldBe(["en", "it", "es"], Case.Sensitive);

            boxOfficeMovie.AvailableTranslations.ShouldNotBeNull();
            boxOfficeMovie.AvailableTranslations.Count.ShouldBe(31);
            boxOfficeMovie.AvailableTranslations.ShouldBe([
                "ar", "az", "bg", "ca", "cs", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hr", "hu", "it",
                "ja", "ka", "ko", "nl", "pl", "pt", "ru", "sk", "sl", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            boxOfficeMovie.Genres.ShouldNotBeNull();
            boxOfficeMovie.Genres.Count.ShouldBe(3);
            boxOfficeMovie.Genres.ShouldBe([
                "comedy", "fantasy", "horror"
            ], Case.Sensitive);

            boxOfficeMovie.Certification.ShouldBe("PG-13");
        }
    }
}
