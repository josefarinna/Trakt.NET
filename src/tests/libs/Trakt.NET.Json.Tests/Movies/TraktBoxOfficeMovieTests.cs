namespace TraktNET.Json.Movies
{
    public sealed class TraktBoxOfficeMovieTests
    {
        [Fact]
        public void TestTraktBoxOfficeMovieConstructor()
        {
            var boxOfficeMovie = new TraktBoxOfficeMovie();

            boxOfficeMovie.Revenue.Should().BeNull();
            boxOfficeMovie.Title.Should().BeNull();
            boxOfficeMovie.Year.Should().BeNull();
            boxOfficeMovie.Ids.Should().BeNull();
            boxOfficeMovie.Tagline.Should().BeNull();
            boxOfficeMovie.Overview.Should().BeNull();
            boxOfficeMovie.Released.Should().BeNull();
            boxOfficeMovie.Runtime.Should().BeNull();
            boxOfficeMovie.Country.Should().BeNull();
            boxOfficeMovie.Trailer.Should().BeNull();
            boxOfficeMovie.Homepage.Should().BeNull();
            boxOfficeMovie.Status.Should().BeNull();
            boxOfficeMovie.Rating.Should().BeNull();
            boxOfficeMovie.Votes.Should().BeNull();
            boxOfficeMovie.CommentCount.Should().BeNull();
            boxOfficeMovie.UpdatedAt.Should().BeNull();
            boxOfficeMovie.Language.Should().BeNull();
            boxOfficeMovie.Languages.Should().BeNull();
            boxOfficeMovie.AvailableTranslations.Should().BeNull();
            boxOfficeMovie.Genres.Should().BeNull();
            boxOfficeMovie.Certification.Should().BeNull();

            boxOfficeMovie.ToString().Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktBoxOfficeMovieFromJsonMinimal()
        {
            TraktBoxOfficeMovie? boxOfficeMovie = await TestUtility.DeserializeJsonAsync<TraktBoxOfficeMovie>("Movies\\boxofficemovie_minimal.json");

            boxOfficeMovie.Should().NotBeNull();

            boxOfficeMovie!.Revenue.Should().Be(52000000U);

            boxOfficeMovie!.Title.Should().Be("Beetlejuice Beetlejuice");
            boxOfficeMovie!.Year.Should().Be(2024U);

            boxOfficeMovie!.Ids!.Trakt.Should().Be(734869U);
            boxOfficeMovie!.Ids!.Slug.Should().Be("beetlejuice-beetlejuice-2024");
            boxOfficeMovie!.Ids!.IMDB.Should().Be("tt2049403");
            boxOfficeMovie!.Ids!.TMDB.Should().Be(917496U);
            boxOfficeMovie!.Ids!.HasAnyID.Should().BeTrue();
            boxOfficeMovie!.Ids!.BestID.Should().Be("beetlejuice-beetlejuice-2024");

            boxOfficeMovie!.ToString().Should().Be("Beetlejuice Beetlejuice (2024)");
        }

        [Fact]
        public async Task TestTraktBoxOfficeMovieFromJson()
        {
            TraktBoxOfficeMovie? boxOfficeMovie = await TestUtility.DeserializeJsonAsync<TraktBoxOfficeMovie>("Movies\\boxofficemovie.json");

            boxOfficeMovie.Should().NotBeNull();

            boxOfficeMovie!.Revenue.Should().Be(52000000U);

            boxOfficeMovie!.Title.Should().Be("Beetlejuice Beetlejuice");
            boxOfficeMovie!.Year.Should().Be(2024U);

            boxOfficeMovie!.Ids!.Trakt.Should().Be(734869U);
            boxOfficeMovie!.Ids!.Slug.Should().Be("beetlejuice-beetlejuice-2024");
            boxOfficeMovie!.Ids!.IMDB.Should().Be("tt2049403");
            boxOfficeMovie!.Ids!.TMDB.Should().Be(917496U);
            boxOfficeMovie!.Ids!.HasAnyID.Should().BeTrue();
            boxOfficeMovie!.Ids!.BestID.Should().Be("beetlejuice-beetlejuice-2024");

            boxOfficeMovie!.ToString().Should().Be("Beetlejuice Beetlejuice (2024)");

            boxOfficeMovie!.Tagline.Should().Be("The ghost with the most is back.");
            boxOfficeMovie!.Overview.Should().Be("After a family tragedy, three generations of the Deetz family return home to Winter River.");

#if NET7_0_OR_GREATER
            boxOfficeMovie!.Released.Should().Be(TestUtility.ParseDate("2024-09-06"));
#else
            boxOfficeMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("2024-09-06T00:00:00.000Z"));
#endif
            boxOfficeMovie!.Runtime.Should().Be(105U);
            boxOfficeMovie!.Country.Should().Be("us");
            boxOfficeMovie!.Trailer.Should().Be("https://youtube.com/watch?v=As-vKW4ZboU");
            boxOfficeMovie!.Homepage.Should().Be("http://www.beetlejuicemovie.com");
            boxOfficeMovie!.Status.Should().Be(TraktMovieStatus.Released);
            boxOfficeMovie!.Rating.Should().Be(7.16738f);
            boxOfficeMovie!.Votes.Should().Be(1631U);
            boxOfficeMovie!.CommentCount.Should().Be(29U);
            boxOfficeMovie!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-21T17:39:23.000Z"));
            boxOfficeMovie!.Language.Should().Be("en");
            boxOfficeMovie!.Languages.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo(["en", "it", "es"]);

            boxOfficeMovie!.AvailableTranslations.Should().NotBeNull().And.HaveCount(31).And.BeEquivalentTo([
                "ar", "az", "bg", "ca", "cs", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hr", "hu", "it",
                "ja", "ka", "ko", "nl", "pl", "pt", "ru", "sk", "sl", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            boxOfficeMovie!.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "comedy", "fantasy", "horror"
            ]);

            boxOfficeMovie!.Certification.Should().Be("PG-13");
        }

        [Fact]
        public async Task TestTraktBoxOfficeMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktBoxOfficeMovie>? boxOfficeMovies = await TestUtility.DeserializeJsonListAsync<TraktBoxOfficeMovie>("Movies\\boxofficemovies_minimal.json");

            boxOfficeMovies.Should().NotBeNull().And.HaveCount(2);

            TraktBoxOfficeMovie boxOfficeMovie = boxOfficeMovies![0];

            boxOfficeMovie.Should().NotBeNull();

            boxOfficeMovie.Revenue.Should().Be(52000000U);

            boxOfficeMovie.Title.Should().Be("Beetlejuice Beetlejuice");
            boxOfficeMovie.Year.Should().Be(2024U);

            boxOfficeMovie.Ids!.Trakt.Should().Be(734869U);
            boxOfficeMovie.Ids!.Slug.Should().Be("beetlejuice-beetlejuice-2024");
            boxOfficeMovie.Ids!.IMDB.Should().Be("tt2049403");
            boxOfficeMovie.Ids!.TMDB.Should().Be(917496U);
            boxOfficeMovie.Ids!.HasAnyID.Should().BeTrue();
            boxOfficeMovie.Ids!.BestID.Should().Be("beetlejuice-beetlejuice-2024");

            boxOfficeMovie.ToString().Should().Be("Beetlejuice Beetlejuice (2024)");

            // --------------------------------------------------------------------------------------------

            boxOfficeMovie = boxOfficeMovies![1];

            boxOfficeMovie.Should().NotBeNull();

            boxOfficeMovie.Revenue.Should().Be(12000000U);

            boxOfficeMovie.Title.Should().Be("Speak No Evil");
            boxOfficeMovie.Year.Should().Be(2024U);

            boxOfficeMovie.Ids!.Trakt.Should().Be(896755U);
            boxOfficeMovie.Ids!.Slug.Should().Be("speak-no-evil-2024");
            boxOfficeMovie.Ids!.IMDB.Should().Be("tt27534307");
            boxOfficeMovie.Ids!.TMDB.Should().Be(1114513U);
            boxOfficeMovie.Ids!.HasAnyID.Should().BeTrue();
            boxOfficeMovie.Ids!.BestID.Should().Be("speak-no-evil-2024");

            boxOfficeMovie.ToString().Should().Be("Speak No Evil (2024)");
        }

        [Fact]
        public async Task TestTraktBoxOfficeMoviesFromJson()
        {
            IReadOnlyList<TraktBoxOfficeMovie>? boxOfficeMovies = await TestUtility.DeserializeJsonListAsync<TraktBoxOfficeMovie>("Movies\\boxofficemovies.json");

            boxOfficeMovies.Should().NotBeNull().And.HaveCount(2);

            TraktBoxOfficeMovie boxOfficeMovie = boxOfficeMovies![0];

            boxOfficeMovie.Should().NotBeNull();

            boxOfficeMovie.Revenue.Should().Be(52000000U);

            boxOfficeMovie.Title.Should().Be("Beetlejuice Beetlejuice");
            boxOfficeMovie.Year.Should().Be(2024U);

            boxOfficeMovie.Ids!.Trakt.Should().Be(734869U);
            boxOfficeMovie.Ids!.Slug.Should().Be("beetlejuice-beetlejuice-2024");
            boxOfficeMovie.Ids!.IMDB.Should().Be("tt2049403");
            boxOfficeMovie.Ids!.TMDB.Should().Be(917496U);
            boxOfficeMovie.Ids!.HasAnyID.Should().BeTrue();
            boxOfficeMovie.Ids!.BestID.Should().Be("beetlejuice-beetlejuice-2024");

            boxOfficeMovie.ToString().Should().Be("Beetlejuice Beetlejuice (2024)");

            boxOfficeMovie.Tagline.Should().Be("The ghost with the most is back.");
            boxOfficeMovie.Overview.Should().Be("After a family tragedy, three generations of the Deetz family return home to Winter River.");

#if NET7_0_OR_GREATER
            boxOfficeMovie.Released.Should().Be(TestUtility.ParseDate("2024-09-06"));
#else
            boxOfficeMovie.Released.Should().Be(TestUtility.ParseUTCDateTime("2024-09-06T00:00:00.000Z"));
#endif
            boxOfficeMovie.Runtime.Should().Be(105U);
            boxOfficeMovie.Country.Should().Be("us");
            boxOfficeMovie.Trailer.Should().Be("https://youtube.com/watch?v=As-vKW4ZboU");
            boxOfficeMovie.Homepage.Should().Be("http://www.beetlejuicemovie.com");
            boxOfficeMovie.Status.Should().Be(TraktMovieStatus.Released);
            boxOfficeMovie.Rating.Should().Be(7.16738f);
            boxOfficeMovie.Votes.Should().Be(1631U);
            boxOfficeMovie.CommentCount.Should().Be(29U);
            boxOfficeMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-21T17:39:23.000Z"));
            boxOfficeMovie.Language.Should().Be("en");
            boxOfficeMovie.Languages.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo(["en", "it", "es"]);

            boxOfficeMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(31).And.BeEquivalentTo([
                "ar", "az", "bg", "ca", "cs", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hr", "hu", "it",
                "ja", "ka", "ko", "nl", "pl", "pt", "ru", "sk", "sl", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            boxOfficeMovie.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "comedy", "fantasy", "horror"
            ]);

            boxOfficeMovie.Certification.Should().Be("PG-13");

            // --------------------------------------------------------------------------------------------

            boxOfficeMovie = boxOfficeMovies![1];

            boxOfficeMovie.Should().NotBeNull();

            boxOfficeMovie.Revenue.Should().Be(12000000U);

            boxOfficeMovie.Title.Should().Be("Speak No Evil");
            boxOfficeMovie.Year.Should().Be(2024U);

            boxOfficeMovie.Ids!.Trakt.Should().Be(896755U);
            boxOfficeMovie.Ids!.Slug.Should().Be("speak-no-evil-2024");
            boxOfficeMovie.Ids!.IMDB.Should().Be("tt27534307");
            boxOfficeMovie.Ids!.TMDB.Should().Be(1114513U);
            boxOfficeMovie.Ids!.HasAnyID.Should().BeTrue();
            boxOfficeMovie.Ids!.BestID.Should().Be("speak-no-evil-2024");

            boxOfficeMovie.ToString().Should().Be("Speak No Evil (2024)");

            boxOfficeMovie.Tagline.Should().BeEmpty();

            boxOfficeMovie.Overview.Should().Be("When an American family is invited to spend the weekend at the idyllic country estate of a charming British family...");

#if NET7_0_OR_GREATER
            boxOfficeMovie!.Released.Should().Be(TestUtility.ParseDate("2024-09-13"));
#else
            boxOfficeMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("2024-09-13T00:00:00.000Z"));
#endif
            boxOfficeMovie.Runtime.Should().Be(110U);
            boxOfficeMovie.Country.Should().Be("us");
            boxOfficeMovie.Trailer.Should().Be("https://youtube.com/watch?v=iSIuxrjTMk0");
            boxOfficeMovie.Homepage.Should().Be("http://www.speaknoevilmovie.com");
            boxOfficeMovie.Status.Should().Be(TraktMovieStatus.Released);
            boxOfficeMovie.Rating.Should().Be(7.12963f);
            boxOfficeMovie.Votes.Should().Be(378U);
            boxOfficeMovie.CommentCount.Should().Be(12U);
            boxOfficeMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-21T08:05:55.000Z"));
            boxOfficeMovie.Language.Should().Be("en");
            boxOfficeMovie.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            boxOfficeMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(29).And.BeEquivalentTo([
                "ar", "az", "bg", "cs", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hu", "it", "ja", "ka",
                "ko", "lt", "nl", "pl", "pt", "ru", "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            boxOfficeMovie.Genres.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo([
                "thriller", "horror"
            ]);

            boxOfficeMovie.Certification.Should().Be("R");
        }
    }
}
