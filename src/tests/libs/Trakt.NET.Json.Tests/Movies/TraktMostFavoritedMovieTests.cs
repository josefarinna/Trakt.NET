namespace TraktNET.Json.Movies
{
    public sealed class TraktMostFavoritedMovieTests
    {
        [Fact]
        public void TestTraktMostFavoritedMovieConstructor()
        {
            var mostFavoritedMovie = new TraktMostFavoritedMovie();

            mostFavoritedMovie.UserCount.Should().BeNull();
            mostFavoritedMovie.Title.Should().BeNull();
            mostFavoritedMovie.Year.Should().BeNull();
            mostFavoritedMovie.Ids.Should().BeNull();
            mostFavoritedMovie.Tagline.Should().BeNull();
            mostFavoritedMovie.Overview.Should().BeNull();
            mostFavoritedMovie.Released.Should().BeNull();
            mostFavoritedMovie.Runtime.Should().BeNull();
            mostFavoritedMovie.Country.Should().BeNull();
            mostFavoritedMovie.Trailer.Should().BeNull();
            mostFavoritedMovie.Homepage.Should().BeNull();
            mostFavoritedMovie.Status.Should().BeNull();
            mostFavoritedMovie.Rating.Should().BeNull();
            mostFavoritedMovie.Votes.Should().BeNull();
            mostFavoritedMovie.CommentCount.Should().BeNull();
            mostFavoritedMovie.UpdatedAt.Should().BeNull();
            mostFavoritedMovie.Language.Should().BeNull();
            mostFavoritedMovie.Languages.Should().BeNull();
            mostFavoritedMovie.AvailableTranslations.Should().BeNull();
            mostFavoritedMovie.Genres.Should().BeNull();
            mostFavoritedMovie.Certification.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktMostFavoritedMovieFromJsonMinimal()
        {
            TraktMostFavoritedMovie? mostFavoritedMovie = await TestUtility.DeserializeJsonAsync<TraktMostFavoritedMovie>("Movies\\mostFavoritedmovie_minimal.json");

            mostFavoritedMovie.Should().NotBeNull();

            mostFavoritedMovie!.UserCount.Should().Be(83U);

            mostFavoritedMovie!.Title.Should().Be("Deadpool & Wolverine");
            mostFavoritedMovie!.Year.Should().Be(2024U);

            mostFavoritedMovie!.Ids!.Trakt.Should().Be(395672U);
            mostFavoritedMovie!.Ids!.Slug.Should().Be("deadpool-wolverine-2024");
            mostFavoritedMovie!.Ids!.IMDB.Should().Be("tt6263850");
            mostFavoritedMovie!.Ids!.TMDB.Should().Be(533535U);
            mostFavoritedMovie!.Ids!.HasAnyID.Should().BeTrue();
            mostFavoritedMovie!.Ids!.BestID.Should().Be("deadpool-wolverine-2024");
        }

        [Fact]
        public async Task TestTraktMostFavoritedMovieFromJson()
        {
            TraktMostFavoritedMovie? mostFavoritedMovie = await TestUtility.DeserializeJsonAsync<TraktMostFavoritedMovie>("Movies\\mostFavoritedmovie.json");

            mostFavoritedMovie.Should().NotBeNull();

            mostFavoritedMovie!.UserCount.Should().Be(83U);

            mostFavoritedMovie!.Title.Should().Be("Deadpool & Wolverine");
            mostFavoritedMovie!.Year.Should().Be(2024U);

            mostFavoritedMovie!.Ids!.Trakt.Should().Be(395672U);
            mostFavoritedMovie!.Ids!.Slug.Should().Be("deadpool-wolverine-2024");
            mostFavoritedMovie!.Ids!.IMDB.Should().Be("tt6263850");
            mostFavoritedMovie!.Ids!.TMDB.Should().Be(533535U);
            mostFavoritedMovie!.Ids!.HasAnyID.Should().BeTrue();
            mostFavoritedMovie!.Ids!.BestID.Should().Be("deadpool-wolverine-2024");

            mostFavoritedMovie!.Tagline.Should().Be("Come together.");

            mostFavoritedMovie!.Overview.Should().Be("A listless Wade Wilson toils away in civilian life with his days as the morally flexible mercenary, "
                + "Deadpool, behind him.");

#if NET7_0_OR_GREATER
            mostFavoritedMovie!.Released.Should().Be(TestUtility.ParseDate("2024-07-26"));
#else
            mostFavoritedMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("2024-07-26T00:00:00.000Z"));
#endif
            mostFavoritedMovie!.Runtime.Should().Be(128U);
            mostFavoritedMovie!.Country.Should().Be("us");
            mostFavoritedMovie!.Trailer.Should().Be("https://youtube.com/watch?v=Idh8n5XuYIA");
            mostFavoritedMovie!.Homepage.Should().Be("http://www.marvel.com/movies/deadpool-and-wolverine");
            mostFavoritedMovie!.Status.Should().Be(TraktMovieStatus.Released);
            mostFavoritedMovie!.Rating.Should().Be(8.204093653364747f);
            mostFavoritedMovie!.Votes.Should().Be(6791U);
            mostFavoritedMovie!.CommentCount.Should().Be(173U);
            mostFavoritedMovie!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-08-12T08:05:41.000Z"));
            mostFavoritedMovie!.Language.Should().Be("en");
            mostFavoritedMovie!.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            mostFavoritedMovie!.AvailableTranslations.Should().NotBeNull().And.HaveCount(32).And.BeEquivalentTo([
                "ar", "bg", "cs", "da", "de", "el", "en", "es", "fa", "fr", "he", "hu", "id", "it", "ja", "ka",
                "kk", "ko", "lt", "nl", "pl", "pt", "ru", "sk", "sl", "sr", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            mostFavoritedMovie!.Genres.Should().NotBeNull().And.HaveCount(4).And.BeEquivalentTo([
                "comedy", "superhero", "science-fiction", "action"
            ]);

            mostFavoritedMovie!.Certification.Should().Be("R");
        }

        [Fact]
        public async Task TestTraktMostFavoritedMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktMostFavoritedMovie>? mostFavoritedMovies = await TestUtility.DeserializeJsonListAsync<TraktMostFavoritedMovie>("Movies\\mostFavoritedmovies_minimal.json");

            mostFavoritedMovies.Should().NotBeNull().And.HaveCount(2);

            TraktMostFavoritedMovie mostFavoritedMovie = mostFavoritedMovies![0];

            mostFavoritedMovie.Should().NotBeNull();

            mostFavoritedMovie.UserCount.Should().Be(83U);

            mostFavoritedMovie.Title.Should().Be("Deadpool & Wolverine");
            mostFavoritedMovie.Year.Should().Be(2024U);

            mostFavoritedMovie.Ids!.Trakt.Should().Be(395672U);
            mostFavoritedMovie.Ids!.Slug.Should().Be("deadpool-wolverine-2024");
            mostFavoritedMovie.Ids!.IMDB.Should().Be("tt6263850");
            mostFavoritedMovie.Ids!.TMDB.Should().Be(533535U);
            mostFavoritedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostFavoritedMovie.Ids!.BestID.Should().Be("deadpool-wolverine-2024");

            // --------------------------------------------------------------------------------------------

            mostFavoritedMovie = mostFavoritedMovies![1];

            mostFavoritedMovie.Should().NotBeNull();

            mostFavoritedMovie.UserCount.Should().Be(48U);

            mostFavoritedMovie.Title.Should().Be("A Quiet Place: Day One");
            mostFavoritedMovie.Year.Should().Be(2024U);

            mostFavoritedMovie.Ids!.Trakt.Should().Be(600962U);
            mostFavoritedMovie.Ids!.Slug.Should().Be("a-quiet-place-day-one-2024");
            mostFavoritedMovie.Ids!.IMDB.Should().Be("tt13433802");
            mostFavoritedMovie.Ids!.TMDB.Should().Be(762441U);
            mostFavoritedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostFavoritedMovie.Ids!.BestID.Should().Be("a-quiet-place-day-one-2024");
        }

        [Fact]
        public async Task TestTraktMostFavoritedMoviesFromJson()
        {
            IReadOnlyList<TraktMostFavoritedMovie>? mostFavoritedMovies = await TestUtility.DeserializeJsonListAsync<TraktMostFavoritedMovie>("Movies\\mostFavoritedmovies.json");

            mostFavoritedMovies.Should().NotBeNull().And.HaveCount(2);

            TraktMostFavoritedMovie mostFavoritedMovie = mostFavoritedMovies![0];

            mostFavoritedMovie.Should().NotBeNull();

            mostFavoritedMovie.UserCount.Should().Be(83U);

            mostFavoritedMovie.Title.Should().Be("Deadpool & Wolverine");
            mostFavoritedMovie.Year.Should().Be(2024U);

            mostFavoritedMovie.Ids!.Trakt.Should().Be(395672U);
            mostFavoritedMovie.Ids!.Slug.Should().Be("deadpool-wolverine-2024");
            mostFavoritedMovie.Ids!.IMDB.Should().Be("tt6263850");
            mostFavoritedMovie.Ids!.TMDB.Should().Be(533535U);
            mostFavoritedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostFavoritedMovie.Ids!.BestID.Should().Be("deadpool-wolverine-2024");

            mostFavoritedMovie.Tagline.Should().Be("Come together.");

            mostFavoritedMovie.Overview.Should().Be("A listless Wade Wilson toils away in civilian life with his days as the morally flexible mercenary, "
                + "Deadpool, behind him.");

#if NET7_0_OR_GREATER
            mostFavoritedMovie.Released.Should().Be(TestUtility.ParseDate("2024-07-26"));
#else
            mostFavoritedMovie.Released.Should().Be(TestUtility.ParseUTCDateTime("2024-07-26T00:00:00.000Z"));
#endif
            mostFavoritedMovie.Runtime.Should().Be(128U);
            mostFavoritedMovie.Country.Should().Be("us");
            mostFavoritedMovie.Trailer.Should().Be("https://youtube.com/watch?v=Idh8n5XuYIA");
            mostFavoritedMovie.Homepage.Should().Be("http://www.marvel.com/movies/deadpool-and-wolverine");
            mostFavoritedMovie.Status.Should().Be(TraktMovieStatus.Released);
            mostFavoritedMovie.Rating.Should().Be(8.204093653364747f);
            mostFavoritedMovie.Votes.Should().Be(6791U);
            mostFavoritedMovie.CommentCount.Should().Be(173U);
            mostFavoritedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-08-12T08:05:41.000Z"));
            mostFavoritedMovie.Language.Should().Be("en");
            mostFavoritedMovie.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            mostFavoritedMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(32).And.BeEquivalentTo([
                "ar", "bg", "cs", "da", "de", "el", "en", "es", "fa", "fr", "he", "hu", "id", "it", "ja", "ka",
                "kk", "ko", "lt", "nl", "pl", "pt", "ru", "sk", "sl", "sr", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            mostFavoritedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.BeEquivalentTo([
                "comedy", "superhero", "science-fiction", "action"
            ]);

            mostFavoritedMovie.Certification.Should().Be("R");

            // --------------------------------------------------------------------------------------------

            mostFavoritedMovie = mostFavoritedMovies![1];

            mostFavoritedMovie.Should().NotBeNull();

            mostFavoritedMovie.UserCount.Should().Be(48U);

            mostFavoritedMovie.Title.Should().Be("A Quiet Place: Day One");
            mostFavoritedMovie.Year.Should().Be(2024U);

            mostFavoritedMovie.Ids!.Trakt.Should().Be(600962U);
            mostFavoritedMovie.Ids!.Slug.Should().Be("a-quiet-place-day-one-2024");
            mostFavoritedMovie.Ids!.IMDB.Should().Be("tt13433802");
            mostFavoritedMovie.Ids!.TMDB.Should().Be(762441U);
            mostFavoritedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostFavoritedMovie.Ids!.BestID.Should().Be("a-quiet-place-day-one-2024");

            mostFavoritedMovie.Tagline.Should().Be("Hear how it all began.");

            mostFavoritedMovie.Overview.Should().Be("As New York City is invaded by alien creatures who hunt by sound, a woman named Sam fights "
                + "to survive with her cat.");

#if NET7_0_OR_GREATER
            mostFavoritedMovie!.Released.Should().Be(TestUtility.ParseDate("2024-06-28"));
#else
            mostFavoritedMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("2024-06-28T00:00:00.000Z"));
#endif
            mostFavoritedMovie.Runtime.Should().Be(99U);
            mostFavoritedMovie.Country.Should().Be("us");
            mostFavoritedMovie.Trailer.Should().Be("https://youtube.com/watch?v=E-WIb4ATfT8");
            mostFavoritedMovie.Homepage.Should().Be("http://www.aquietplacemovie.com");
            mostFavoritedMovie.Status.Should().Be(TraktMovieStatus.Released);
            mostFavoritedMovie.Rating.Should().Be(6.583368509919797f);
            mostFavoritedMovie.Votes.Should().Be(4738U);
            mostFavoritedMovie.CommentCount.Should().Be(96U);
            mostFavoritedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-08-12T16:55:51.000Z"));
            mostFavoritedMovie.Language.Should().Be("en");
            mostFavoritedMovie.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            mostFavoritedMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(34).And.BeEquivalentTo([
                "ar", "bg", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hr", "hu", "id", "it",
                "ja", "ka", "ko", "lt", "nl", "pl", "pt", "ro", "ru", "sk", "sl", "sr", "sv", "th", "tr", "uk",
                "vi", "zh"
            ]);

            mostFavoritedMovie.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "horror", "science-fiction", "thriller"
            ]);

            mostFavoritedMovie.Certification.Should().Be("PG-13");
        }
    }
}
