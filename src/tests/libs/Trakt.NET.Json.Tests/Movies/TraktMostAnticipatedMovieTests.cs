namespace TraktNET.Json.Movies
{
    public sealed class TraktMostAnticipatedMovieTests
    {
        [Fact]
        public void TestTraktMostAnticipatedMovieConstructor()
        {
            var mostAnticipatedMovie = new TraktMostAnticipatedMovie();

            mostAnticipatedMovie.ListCount.Should().BeNull();
            mostAnticipatedMovie.Title.Should().BeNull();
            mostAnticipatedMovie.Year.Should().BeNull();
            mostAnticipatedMovie.Ids.Should().BeNull();
            mostAnticipatedMovie.Tagline.Should().BeNull();
            mostAnticipatedMovie.Overview.Should().BeNull();
            mostAnticipatedMovie.Released.Should().BeNull();
            mostAnticipatedMovie.Runtime.Should().BeNull();
            mostAnticipatedMovie.Country.Should().BeNull();
            mostAnticipatedMovie.Trailer.Should().BeNull();
            mostAnticipatedMovie.Homepage.Should().BeNull();
            mostAnticipatedMovie.Status.Should().BeNull();
            mostAnticipatedMovie.Rating.Should().BeNull();
            mostAnticipatedMovie.Votes.Should().BeNull();
            mostAnticipatedMovie.CommentCount.Should().BeNull();
            mostAnticipatedMovie.UpdatedAt.Should().BeNull();
            mostAnticipatedMovie.Language.Should().BeNull();
            mostAnticipatedMovie.Languages.Should().BeNull();
            mostAnticipatedMovie.AvailableTranslations.Should().BeNull();
            mostAnticipatedMovie.Genres.Should().BeNull();
            mostAnticipatedMovie.Certification.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktMostAnticipatedMovieFromJsonMinimal()
        {
            TraktMostAnticipatedMovie? mostAnticipatedMovie = await TestUtility.DeserializeJsonAsync<TraktMostAnticipatedMovie>("Movies\\mostanticipatedmovie_minimal.json");

            mostAnticipatedMovie.Should().NotBeNull();

            mostAnticipatedMovie!.ListCount.Should().Be(33464U);

            mostAnticipatedMovie!.Title.Should().Be("Avatar: Fire and Ash");
            mostAnticipatedMovie!.Year.Should().Be(2025U);

            mostAnticipatedMovie!.Ids!.Trakt.Should().Be(62544U);
            mostAnticipatedMovie!.Ids!.Slug.Should().Be("avatar-fire-and-ash-2025");
            mostAnticipatedMovie!.Ids!.IMDB.Should().Be("tt1757678");
            mostAnticipatedMovie!.Ids!.TMDB.Should().Be(83533U);
            mostAnticipatedMovie!.Ids!.HasAnyID.Should().BeTrue();
            mostAnticipatedMovie!.Ids!.BestID.Should().Be("avatar-fire-and-ash-2025");
        }

        [Fact]
        public async Task TestTraktMostAnticipatedMovieFromJson()
        {
            TraktMostAnticipatedMovie? mostAnticipatedMovie = await TestUtility.DeserializeJsonAsync<TraktMostAnticipatedMovie>("Movies\\mostanticipatedmovie.json");

            mostAnticipatedMovie.Should().NotBeNull();

            mostAnticipatedMovie!.ListCount.Should().Be(33464U);

            mostAnticipatedMovie!.Title.Should().Be("Avatar: Fire and Ash");
            mostAnticipatedMovie!.Year.Should().Be(2025U);

            mostAnticipatedMovie!.Ids!.Trakt.Should().Be(62544U);
            mostAnticipatedMovie!.Ids!.Slug.Should().Be("avatar-fire-and-ash-2025");
            mostAnticipatedMovie!.Ids!.IMDB.Should().Be("tt1757678");
            mostAnticipatedMovie!.Ids!.TMDB.Should().Be(83533U);
            mostAnticipatedMovie!.Ids!.HasAnyID.Should().BeTrue();
            mostAnticipatedMovie!.Ids!.BestID.Should().Be("avatar-fire-and-ash-2025");

            mostAnticipatedMovie!.Tagline.Should().BeEmpty();

            mostAnticipatedMovie!.Overview.Should().Be("In the wake of the devastating war against the RDA and the loss of their eldest son, Jake Sully and Neytiri "
                + "face a new threat on Pandora.");

#if NET7_0_OR_GREATER
            mostAnticipatedMovie!.Released.Should().Be(TestUtility.ParseDate("2025-12-19"));
#else
            mostAnticipatedMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("2025-12-19T00:00:00.000Z"));
#endif
            mostAnticipatedMovie!.Runtime.Should().Be(1U);
            mostAnticipatedMovie!.Country.Should().Be("us");
            mostAnticipatedMovie!.Trailer.Should().BeNull();
            mostAnticipatedMovie!.Homepage.Should().Be("http://www.avatar.com/movies");
            mostAnticipatedMovie!.Status.Should().Be(TraktMovieStatus.PostProduction);
            mostAnticipatedMovie!.Rating.Should().Be(7.05102f);
            mostAnticipatedMovie!.Votes.Should().Be(98U);
            mostAnticipatedMovie!.CommentCount.Should().Be(2U);
            mostAnticipatedMovie!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-15T08:05:18.000Z"));
            mostAnticipatedMovie!.Language.Should().Be("en");
            mostAnticipatedMovie!.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            mostAnticipatedMovie!.AvailableTranslations.Should().NotBeNull().And.HaveCount(13).And.BeEquivalentTo([
                "bg", "en", "es", "fr", "he", "ka", "ko", "pl", "pt", "ru", "uk", "vi", "zh"
            ]);

            mostAnticipatedMovie!.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "adventure", "science-fiction", "fantasy"
            ]);

            mostAnticipatedMovie!.Certification.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktMostAnticipatedMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktMostAnticipatedMovie>? mostAnticipatedMovies = await TestUtility.DeserializeJsonListAsync<TraktMostAnticipatedMovie>("Movies\\mostanticipatedmovies_minimal.json");

            mostAnticipatedMovies.Should().NotBeNull().And.HaveCount(2);

            TraktMostAnticipatedMovie mostAnticipatedMovie = mostAnticipatedMovies![0];

            mostAnticipatedMovie.Should().NotBeNull();

            mostAnticipatedMovie.ListCount.Should().Be(33464U);

            mostAnticipatedMovie.Title.Should().Be("Avatar: Fire and Ash");
            mostAnticipatedMovie.Year.Should().Be(2025U);

            mostAnticipatedMovie.Ids!.Trakt.Should().Be(62544U);
            mostAnticipatedMovie.Ids!.Slug.Should().Be("avatar-fire-and-ash-2025");
            mostAnticipatedMovie.Ids!.IMDB.Should().Be("tt1757678");
            mostAnticipatedMovie.Ids!.TMDB.Should().Be(83533U);
            mostAnticipatedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostAnticipatedMovie.Ids!.BestID.Should().Be("avatar-fire-and-ash-2025");

            // --------------------------------------------------------------------------------------------

            mostAnticipatedMovie = mostAnticipatedMovies![1];

            mostAnticipatedMovie.Should().NotBeNull();

            mostAnticipatedMovie.ListCount.Should().Be(23502U);

            mostAnticipatedMovie.Title.Should().Be("Blade");
            mostAnticipatedMovie.Year.Should().Be(2025U);

            mostAnticipatedMovie.Ids!.Trakt.Should().Be(460195U);
            mostAnticipatedMovie.Ids!.Slug.Should().Be("blade-2025");
            mostAnticipatedMovie.Ids!.IMDB.Should().Be("tt10671440");
            mostAnticipatedMovie.Ids!.TMDB.Should().Be(617127U);
            mostAnticipatedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostAnticipatedMovie.Ids!.BestID.Should().Be("blade-2025");
        }

        [Fact]
        public async Task TestTraktMostAnticipatedMoviesFromJson()
        {
            IReadOnlyList<TraktMostAnticipatedMovie>? mostAnticipatedMovies = await TestUtility.DeserializeJsonListAsync<TraktMostAnticipatedMovie>("Movies\\mostanticipatedmovies.json");

            mostAnticipatedMovies.Should().NotBeNull().And.HaveCount(2);

            TraktMostAnticipatedMovie mostAnticipatedMovie = mostAnticipatedMovies![0];

            mostAnticipatedMovie.Should().NotBeNull();

            mostAnticipatedMovie.ListCount.Should().Be(33464U);

            mostAnticipatedMovie.Title.Should().Be("Avatar: Fire and Ash");
            mostAnticipatedMovie.Year.Should().Be(2025U);

            mostAnticipatedMovie.Ids!.Trakt.Should().Be(62544U);
            mostAnticipatedMovie.Ids!.Slug.Should().Be("avatar-fire-and-ash-2025");
            mostAnticipatedMovie.Ids!.IMDB.Should().Be("tt1757678");
            mostAnticipatedMovie.Ids!.TMDB.Should().Be(83533U);
            mostAnticipatedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostAnticipatedMovie.Ids!.BestID.Should().Be("avatar-fire-and-ash-2025");

            mostAnticipatedMovie.Tagline.Should().BeEmpty();

            mostAnticipatedMovie.Overview.Should().Be("In the wake of the devastating war against the RDA and the loss of their eldest son, Jake Sully and Neytiri "
                + "face a new threat on Pandora.");

#if NET7_0_OR_GREATER
            mostAnticipatedMovie.Released.Should().Be(TestUtility.ParseDate("2025-12-19"));
#else
            mostAnticipatedMovie.Released.Should().Be(TestUtility.ParseUTCDateTime("2025-12-19T00:00:00.000Z"));
#endif
            mostAnticipatedMovie.Runtime.Should().Be(1U);
            mostAnticipatedMovie.Country.Should().Be("us");
            mostAnticipatedMovie.Trailer.Should().BeNull();
            mostAnticipatedMovie.Homepage.Should().Be("http://www.avatar.com/movies");
            mostAnticipatedMovie.Status.Should().Be(TraktMovieStatus.PostProduction);
            mostAnticipatedMovie.Rating.Should().Be(7.05102f);
            mostAnticipatedMovie.Votes.Should().Be(98U);
            mostAnticipatedMovie.CommentCount.Should().Be(2U);
            mostAnticipatedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-15T08:05:18.000Z"));
            mostAnticipatedMovie.Language.Should().Be("en");
            mostAnticipatedMovie.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            mostAnticipatedMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(13).And.BeEquivalentTo([
                "bg", "en", "es", "fr", "he", "ka", "ko", "pl", "pt", "ru", "uk", "vi", "zh"
            ]);

            mostAnticipatedMovie.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "adventure", "science-fiction", "fantasy"
            ]);

            mostAnticipatedMovie.Certification.Should().BeNull();

            // --------------------------------------------------------------------------------------------

            mostAnticipatedMovie = mostAnticipatedMovies![1];

            mostAnticipatedMovie.Should().NotBeNull();

            mostAnticipatedMovie.ListCount.Should().Be(23502U);

            mostAnticipatedMovie.Title.Should().Be("Blade");
            mostAnticipatedMovie.Year.Should().Be(2025U);

            mostAnticipatedMovie.Ids!.Trakt.Should().Be(460195U);
            mostAnticipatedMovie.Ids!.Slug.Should().Be("blade-2025");
            mostAnticipatedMovie.Ids!.IMDB.Should().Be("tt10671440");
            mostAnticipatedMovie.Ids!.TMDB.Should().Be(617127U);
            mostAnticipatedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostAnticipatedMovie.Ids!.BestID.Should().Be("blade-2025");

            mostAnticipatedMovie.Tagline.Should().BeEmpty();

            mostAnticipatedMovie.Overview.Should().Be("A film set in the Marvel Cinematic Universe (MCU) based on the Marvel Comics character of the same name.");

#if NET7_0_OR_GREATER
            mostAnticipatedMovie!.Released.Should().Be(TestUtility.ParseDate("2025-11-07"));
#else
            mostAnticipatedMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("2025-11-07T00:00:00.000Z"));
#endif
            mostAnticipatedMovie.Runtime.Should().Be(90U);
            mostAnticipatedMovie.Country.Should().Be("us");
            mostAnticipatedMovie.Trailer.Should().BeNull();
            mostAnticipatedMovie.Homepage.Should().Be("http://www.marvel.com/movies/blade");
            mostAnticipatedMovie.Status.Should().Be(TraktMovieStatus.Planned);
            mostAnticipatedMovie.Rating.Should().Be(7.05556f);
            mostAnticipatedMovie.Votes.Should().Be(36U);
            mostAnticipatedMovie.CommentCount.Should().Be(10U);
            mostAnticipatedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-16T08:06:34.000Z"));
            mostAnticipatedMovie.Language.Should().Be("en");
            mostAnticipatedMovie.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            mostAnticipatedMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(13).And.BeEquivalentTo([
                "bg", "en", "es", "fa", "he", "hu", "ka", "ko", "pt", "ru", "th", "uk", "zh"
            ]);

            mostAnticipatedMovie.Genres.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo([
                "superhero", "fantasy"
            ]);

            mostAnticipatedMovie.Certification.Should().BeNull();
        }
    }
}
