namespace TraktNET.Json.Movies
{
    public sealed class TraktMostWatchedMovieTests
    {
        [Fact]
        public void TestTraktMostWatchedMovieConstructor()
        {
            var mostWatchedMovie = new TraktMostWatchedMovie();

            mostWatchedMovie.WatcherCount.Should().BeNull();
            mostWatchedMovie.PlayCount.Should().BeNull();
            mostWatchedMovie.CollectedCount.Should().BeNull();
            mostWatchedMovie.Title.Should().BeNull();
            mostWatchedMovie.Year.Should().BeNull();
            mostWatchedMovie.Ids.Should().BeNull();
            mostWatchedMovie.Tagline.Should().BeNull();
            mostWatchedMovie.Overview.Should().BeNull();
            mostWatchedMovie.Released.Should().BeNull();
            mostWatchedMovie.Runtime.Should().BeNull();
            mostWatchedMovie.Country.Should().BeNull();
            mostWatchedMovie.Trailer.Should().BeNull();
            mostWatchedMovie.Homepage.Should().BeNull();
            mostWatchedMovie.Status.Should().BeNull();
            mostWatchedMovie.Rating.Should().BeNull();
            mostWatchedMovie.Votes.Should().BeNull();
            mostWatchedMovie.CommentCount.Should().BeNull();
            mostWatchedMovie.UpdatedAt.Should().BeNull();
            mostWatchedMovie.Language.Should().BeNull();
            mostWatchedMovie.Languages.Should().BeNull();
            mostWatchedMovie.AvailableTranslations.Should().BeNull();
            mostWatchedMovie.Genres.Should().BeNull();
            mostWatchedMovie.Certification.Should().BeNull();

            mostWatchedMovie.ToString().Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktMostWatchedMovieFromJsonMinimal()
        {
            TraktMostWatchedMovie? mostWatchedMovie = await TestUtility.DeserializeJsonAsync<TraktMostWatchedMovie>("Movies\\mostpwcmovie_minimal.json");

            mostWatchedMovie.Should().NotBeNull();

            mostWatchedMovie!.WatcherCount.Should().Be(10606U);
            mostWatchedMovie!.PlayCount.Should().Be(14142U);
            mostWatchedMovie!.CollectedCount.Should().Be(107U);

            mostWatchedMovie!.Title.Should().Be("The Hunt for Red October");
            mostWatchedMovie!.Year.Should().Be(1990U);

            mostWatchedMovie!.Ids!.Trakt.Should().Be(1111U);
            mostWatchedMovie!.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostWatchedMovie!.Ids!.IMDB.Should().Be("tt0099810");
            mostWatchedMovie!.Ids!.TMDB.Should().Be(1669U);
            mostWatchedMovie!.Ids!.HasAnyID.Should().BeTrue();
            mostWatchedMovie!.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostWatchedMovie!.ToString().Should().Be("The Hunt for Red October (1990)");
        }

        [Fact]
        public async Task TestTraktMostWatchedMovieFromJson()
        {
            TraktMostWatchedMovie? mostWatchedMovie = await TestUtility.DeserializeJsonAsync<TraktMostWatchedMovie>("Movies\\mostpwcmovie.json");

            mostWatchedMovie.Should().NotBeNull();

            mostWatchedMovie!.WatcherCount.Should().Be(10606U);
            mostWatchedMovie!.PlayCount.Should().Be(14142U);
            mostWatchedMovie!.CollectedCount.Should().Be(107U);

            mostWatchedMovie!.Title.Should().Be("The Hunt for Red October");
            mostWatchedMovie!.Year.Should().Be(1990U);

            mostWatchedMovie!.Ids!.Trakt.Should().Be(1111U);
            mostWatchedMovie!.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostWatchedMovie!.Ids!.IMDB.Should().Be("tt0099810");
            mostWatchedMovie!.Ids!.TMDB.Should().Be(1669U);
            mostWatchedMovie!.Ids!.HasAnyID.Should().BeTrue();
            mostWatchedMovie!.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostWatchedMovie!.ToString().Should().Be("The Hunt for Red October (1990)");

            mostWatchedMovie!.Tagline.Should().Be("Invisible. Silent. Stolen.");

            mostWatchedMovie!.Overview.Should().Be("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostWatchedMovie!.Released.Should().Be(TestUtility.ParseDate("1990-03-02"));
#else
            mostWatchedMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostWatchedMovie!.Runtime.Should().Be(135U);
            mostWatchedMovie!.Country.Should().Be("us");
            mostWatchedMovie!.Trailer.Should().Be("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostWatchedMovie!.Homepage.Should().Be("http://www.paramount.com/movies/hunt-red-october");
            mostWatchedMovie!.Status.Should().Be(TraktMovieStatus.Released);
            mostWatchedMovie!.Rating.Should().Be(7.9446390086206895f);
            mostWatchedMovie!.Votes.Should().Be(7424U);
            mostWatchedMovie!.CommentCount.Should().Be(22U);
            mostWatchedMovie!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostWatchedMovie!.Language.Should().Be("en");
            mostWatchedMovie!.Languages.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo(["en", "ru"]);

            mostWatchedMovie!.AvailableTranslations.Should().NotBeNull().And.HaveCount(39).And.BeEquivalentTo([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            mostWatchedMovie!.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "action", "adventure", "thriller"
            ]);

            mostWatchedMovie!.Certification.Should().Be("PG-13");
        }

        [Fact]
        public async Task TestTraktMostWatchedMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktMostWatchedMovie>? mostWatchedMovies = await TestUtility.DeserializeJsonListAsync<TraktMostWatchedMovie>("Movies\\mostpwcmovies_minimal.json");

            mostWatchedMovies.Should().NotBeNull().And.HaveCount(2);

            TraktMostWatchedMovie mostWatchedMovie = mostWatchedMovies![0];

            mostWatchedMovie.Should().NotBeNull();

            mostWatchedMovie.WatcherCount.Should().Be(10606U);
            mostWatchedMovie.PlayCount.Should().Be(14142U);
            mostWatchedMovie.CollectedCount.Should().Be(107U);

            mostWatchedMovie.Title.Should().Be("The Hunt for Red October");
            mostWatchedMovie.Year.Should().Be(1990U);

            mostWatchedMovie.Ids!.Trakt.Should().Be(1111U);
            mostWatchedMovie.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostWatchedMovie.Ids!.IMDB.Should().Be("tt0099810");
            mostWatchedMovie.Ids!.TMDB.Should().Be(1669U);
            mostWatchedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostWatchedMovie.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostWatchedMovie.ToString().Should().Be("The Hunt for Red October (1990)");

            // --------------------------------------------------------------------------------------------

            mostWatchedMovie = mostWatchedMovies![1];

            mostWatchedMovie.Should().NotBeNull();

            mostWatchedMovie.WatcherCount.Should().Be(9076U);
            mostWatchedMovie.PlayCount.Should().Be(12102U);
            mostWatchedMovie.CollectedCount.Should().Be(3533U);

            mostWatchedMovie.Title.Should().Be("Rebel Ridge");
            mostWatchedMovie.Year.Should().Be(2024U);

            mostWatchedMovie.Ids!.Trakt.Should().Be(483193U);
            mostWatchedMovie.Ids!.Slug.Should().Be("rebel-ridge-2024");
            mostWatchedMovie.Ids!.IMDB.Should().Be("tt11301886");
            mostWatchedMovie.Ids!.TMDB.Should().Be(646097U);
            mostWatchedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostWatchedMovie.Ids!.BestID.Should().Be("rebel-ridge-2024");

            mostWatchedMovie.ToString().Should().Be("Rebel Ridge (2024)");
        }

        [Fact]
        public async Task TestTraktMostWatchedMoviesFromJson()
        {
            IReadOnlyList<TraktMostWatchedMovie>? mostWatchedMovies = await TestUtility.DeserializeJsonListAsync<TraktMostWatchedMovie>("Movies\\mostpwcmovies.json");

            mostWatchedMovies.Should().NotBeNull().And.HaveCount(2);

            TraktMostWatchedMovie mostWatchedMovie = mostWatchedMovies![0];

            mostWatchedMovie.Should().NotBeNull();

            mostWatchedMovie.WatcherCount.Should().Be(10606U);
            mostWatchedMovie.PlayCount.Should().Be(14142U);
            mostWatchedMovie.CollectedCount.Should().Be(107U);

            mostWatchedMovie.Title.Should().Be("The Hunt for Red October");
            mostWatchedMovie.Year.Should().Be(1990U);

            mostWatchedMovie.Ids!.Trakt.Should().Be(1111U);
            mostWatchedMovie.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostWatchedMovie.Ids!.IMDB.Should().Be("tt0099810");
            mostWatchedMovie.Ids!.TMDB.Should().Be(1669U);
            mostWatchedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostWatchedMovie.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostWatchedMovie.ToString().Should().Be("The Hunt for Red October (1990)");

            mostWatchedMovie.Tagline.Should().Be("Invisible. Silent. Stolen.");

            mostWatchedMovie.Overview.Should().Be("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostWatchedMovie.Released.Should().Be(TestUtility.ParseDate("1990-03-02"));
#else
            mostWatchedMovie.Released.Should().Be(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostWatchedMovie.Runtime.Should().Be(135U);
            mostWatchedMovie.Country.Should().Be("us");
            mostWatchedMovie.Trailer.Should().Be("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostWatchedMovie.Homepage.Should().Be("http://www.paramount.com/movies/hunt-red-october");
            mostWatchedMovie.Status.Should().Be(TraktMovieStatus.Released);
            mostWatchedMovie.Rating.Should().Be(7.9446390086206895f);
            mostWatchedMovie.Votes.Should().Be(7424U);
            mostWatchedMovie.CommentCount.Should().Be(22U);
            mostWatchedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostWatchedMovie.Language.Should().Be("en");
            mostWatchedMovie.Languages.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo(["en", "ru"]);

            mostWatchedMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(39).And.BeEquivalentTo([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            mostWatchedMovie.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "action", "adventure", "thriller"
            ]);

            mostWatchedMovie.Certification.Should().Be("PG-13");

            // --------------------------------------------------------------------------------------------

            mostWatchedMovie = mostWatchedMovies![1];

            mostWatchedMovie.Should().NotBeNull();

            mostWatchedMovie.WatcherCount.Should().Be(9076U);
            mostWatchedMovie.PlayCount.Should().Be(12102U);
            mostWatchedMovie.CollectedCount.Should().Be(3533U);

            mostWatchedMovie.Title.Should().Be("Rebel Ridge");
            mostWatchedMovie.Year.Should().Be(2024U);

            mostWatchedMovie.Ids!.Trakt.Should().Be(483193U);
            mostWatchedMovie.Ids!.Slug.Should().Be("rebel-ridge-2024");
            mostWatchedMovie.Ids!.IMDB.Should().Be("tt11301886");
            mostWatchedMovie.Ids!.TMDB.Should().Be(646097U);
            mostWatchedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostWatchedMovie.Ids!.BestID.Should().Be("rebel-ridge-2024");

            mostWatchedMovie.ToString().Should().Be("Rebel Ridge (2024)");

            mostWatchedMovie.Tagline.Should().Be("Their laws. His rules.");

            mostWatchedMovie.Overview.Should().Be("A former Marine confronts corruption in a small town when local law enforcement unjustly "
                + "seizes the bag of cash he needs to post his cousin's bail.");

#if NET7_0_OR_GREATER
            mostWatchedMovie!.Released.Should().Be(TestUtility.ParseDate("2024-09-06"));
#else
            mostWatchedMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("2024-09-06T00:00:00.000Z"));
#endif
            mostWatchedMovie.Runtime.Should().Be(132U);
            mostWatchedMovie.Country.Should().Be("us");
            mostWatchedMovie.Trailer.Should().Be("https://youtube.com/watch?v=gF3gZicntIw");
            mostWatchedMovie.Homepage.Should().Be("http://www.netflix.com/title/81157729");
            mostWatchedMovie.Status.Should().Be(TraktMovieStatus.Released);
            mostWatchedMovie.Rating.Should().Be(7.067648663393344f);
            mostWatchedMovie.Votes.Should().Be(1833U);
            mostWatchedMovie.CommentCount.Should().Be(27U);
            mostWatchedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-15T08:05:18.000Z"));
            mostWatchedMovie.Language.Should().Be("en");
            mostWatchedMovie.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            mostWatchedMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(34).And.BeEquivalentTo([
                "ar", "bg", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hi", "hr", "hu", "id",
                "it", "ja", "ka", "ko", "nl", "no", "pl", "pt", "ro", "ru", "sl", "sv", "th", "tl", "tr", "uk",
                "vi", "zh"
            ]);

            mostWatchedMovie.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "thriller", "crime", "action"
            ]);

            mostWatchedMovie.Certification.Should().Be("R");
        }
    }
}
