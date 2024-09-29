namespace TraktNET.Json.Movies
{
    public sealed class TraktMostPlayedMovieTests
    {
        [Fact]
        public void TestTraktMostPlayedMovieConstructor()
        {
            var mostPlayedMovie = new TraktMostPlayedMovie();

            mostPlayedMovie.WatcherCount.Should().BeNull();
            mostPlayedMovie.PlayCount.Should().BeNull();
            mostPlayedMovie.CollectedCount.Should().BeNull();
            mostPlayedMovie.Title.Should().BeNull();
            mostPlayedMovie.Year.Should().BeNull();
            mostPlayedMovie.Ids.Should().BeNull();
            mostPlayedMovie.Tagline.Should().BeNull();
            mostPlayedMovie.Overview.Should().BeNull();
            mostPlayedMovie.Released.Should().BeNull();
            mostPlayedMovie.Runtime.Should().BeNull();
            mostPlayedMovie.Country.Should().BeNull();
            mostPlayedMovie.Trailer.Should().BeNull();
            mostPlayedMovie.Homepage.Should().BeNull();
            mostPlayedMovie.Status.Should().BeNull();
            mostPlayedMovie.Rating.Should().BeNull();
            mostPlayedMovie.Votes.Should().BeNull();
            mostPlayedMovie.CommentCount.Should().BeNull();
            mostPlayedMovie.UpdatedAt.Should().BeNull();
            mostPlayedMovie.Language.Should().BeNull();
            mostPlayedMovie.Languages.Should().BeNull();
            mostPlayedMovie.AvailableTranslations.Should().BeNull();
            mostPlayedMovie.Genres.Should().BeNull();
            mostPlayedMovie.Certification.Should().BeNull();

            mostPlayedMovie.ToString().Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktMostPlayedMovieFromJsonMinimal()
        {
            TraktMostPlayedMovie? mostPlayedMovie = await TestUtility.DeserializeJsonAsync<TraktMostPlayedMovie>("Movies\\mostpwcmovie_minimal.json");

            mostPlayedMovie.Should().NotBeNull();

            mostPlayedMovie!.WatcherCount.Should().Be(10606U);
            mostPlayedMovie!.PlayCount.Should().Be(14142U);
            mostPlayedMovie!.CollectedCount.Should().Be(107U);

            mostPlayedMovie!.Title.Should().Be("The Hunt for Red October");
            mostPlayedMovie!.Year.Should().Be(1990U);

            mostPlayedMovie!.Ids!.Trakt.Should().Be(1111U);
            mostPlayedMovie!.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostPlayedMovie!.Ids!.IMDB.Should().Be("tt0099810");
            mostPlayedMovie!.Ids!.TMDB.Should().Be(1669U);
            mostPlayedMovie!.Ids!.HasAnyID.Should().BeTrue();
            mostPlayedMovie!.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostPlayedMovie!.ToString().Should().Be("The Hunt for Red October (1990)");
        }

        [Fact]
        public async Task TestTraktMostPlayedMovieFromJson()
        {
            TraktMostPlayedMovie? mostPlayedMovie = await TestUtility.DeserializeJsonAsync<TraktMostPlayedMovie>("Movies\\mostpwcmovie.json");

            mostPlayedMovie.Should().NotBeNull();

            mostPlayedMovie!.WatcherCount.Should().Be(10606U);
            mostPlayedMovie!.PlayCount.Should().Be(14142U);
            mostPlayedMovie!.CollectedCount.Should().Be(107U);

            mostPlayedMovie!.Title.Should().Be("The Hunt for Red October");
            mostPlayedMovie!.Year.Should().Be(1990U);

            mostPlayedMovie!.Ids!.Trakt.Should().Be(1111U);
            mostPlayedMovie!.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostPlayedMovie!.Ids!.IMDB.Should().Be("tt0099810");
            mostPlayedMovie!.Ids!.TMDB.Should().Be(1669U);
            mostPlayedMovie!.Ids!.HasAnyID.Should().BeTrue();
            mostPlayedMovie!.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostPlayedMovie!.ToString().Should().Be("The Hunt for Red October (1990)");

            mostPlayedMovie!.Tagline.Should().Be("Invisible. Silent. Stolen.");

            mostPlayedMovie!.Overview.Should().Be("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostPlayedMovie!.Released.Should().Be(TestUtility.ParseDate("1990-03-02"));
#else
            mostPlayedMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostPlayedMovie!.Runtime.Should().Be(135U);
            mostPlayedMovie!.Country.Should().Be("us");
            mostPlayedMovie!.Trailer.Should().Be("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostPlayedMovie!.Homepage.Should().Be("http://www.paramount.com/movies/hunt-red-october");
            mostPlayedMovie!.Status.Should().Be(TraktMovieStatus.Released);
            mostPlayedMovie!.Rating.Should().Be(7.9446390086206895f);
            mostPlayedMovie!.Votes.Should().Be(7424U);
            mostPlayedMovie!.CommentCount.Should().Be(22U);
            mostPlayedMovie!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostPlayedMovie!.Language.Should().Be("en");
            mostPlayedMovie!.Languages.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo(["en", "ru"]);

            mostPlayedMovie!.AvailableTranslations.Should().NotBeNull().And.HaveCount(39).And.BeEquivalentTo([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            mostPlayedMovie!.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "action", "adventure", "thriller"
            ]);

            mostPlayedMovie!.Certification.Should().Be("PG-13");
        }

        [Fact]
        public async Task TestTraktMostPlayedMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktMostPlayedMovie>? mostPlayedMovies = await TestUtility.DeserializeJsonListAsync<TraktMostPlayedMovie>("Movies\\mostpwcmovies_minimal.json");

            mostPlayedMovies.Should().NotBeNull().And.HaveCount(2);

            TraktMostPlayedMovie mostPlayedMovie = mostPlayedMovies![0];

            mostPlayedMovie.Should().NotBeNull();

            mostPlayedMovie.WatcherCount.Should().Be(10606U);
            mostPlayedMovie.PlayCount.Should().Be(14142U);
            mostPlayedMovie.CollectedCount.Should().Be(107U);

            mostPlayedMovie.Title.Should().Be("The Hunt for Red October");
            mostPlayedMovie.Year.Should().Be(1990U);

            mostPlayedMovie.Ids!.Trakt.Should().Be(1111U);
            mostPlayedMovie.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostPlayedMovie.Ids!.IMDB.Should().Be("tt0099810");
            mostPlayedMovie.Ids!.TMDB.Should().Be(1669U);
            mostPlayedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostPlayedMovie.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostPlayedMovie.ToString().Should().Be("The Hunt for Red October (1990)");

            // --------------------------------------------------------------------------------------------

            mostPlayedMovie = mostPlayedMovies![1];

            mostPlayedMovie.Should().NotBeNull();

            mostPlayedMovie.WatcherCount.Should().Be(9076U);
            mostPlayedMovie.PlayCount.Should().Be(12102U);
            mostPlayedMovie.CollectedCount.Should().Be(3533U);

            mostPlayedMovie.Title.Should().Be("Rebel Ridge");
            mostPlayedMovie.Year.Should().Be(2024U);

            mostPlayedMovie.Ids!.Trakt.Should().Be(483193U);
            mostPlayedMovie.Ids!.Slug.Should().Be("rebel-ridge-2024");
            mostPlayedMovie.Ids!.IMDB.Should().Be("tt11301886");
            mostPlayedMovie.Ids!.TMDB.Should().Be(646097U);
            mostPlayedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostPlayedMovie.Ids!.BestID.Should().Be("rebel-ridge-2024");

            mostPlayedMovie.ToString().Should().Be("Rebel Ridge (2024)");
        }

        [Fact]
        public async Task TestTraktMostPlayedMoviesFromJson()
        {
            IReadOnlyList<TraktMostPlayedMovie>? mostPlayedMovies = await TestUtility.DeserializeJsonListAsync<TraktMostPlayedMovie>("Movies\\mostpwcmovies.json");

            mostPlayedMovies.Should().NotBeNull().And.HaveCount(2);

            TraktMostPlayedMovie mostPlayedMovie = mostPlayedMovies![0];

            mostPlayedMovie.Should().NotBeNull();

            mostPlayedMovie.WatcherCount.Should().Be(10606U);
            mostPlayedMovie.PlayCount.Should().Be(14142U);
            mostPlayedMovie.CollectedCount.Should().Be(107U);

            mostPlayedMovie.Title.Should().Be("The Hunt for Red October");
            mostPlayedMovie.Year.Should().Be(1990U);

            mostPlayedMovie.Ids!.Trakt.Should().Be(1111U);
            mostPlayedMovie.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostPlayedMovie.Ids!.IMDB.Should().Be("tt0099810");
            mostPlayedMovie.Ids!.TMDB.Should().Be(1669U);
            mostPlayedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostPlayedMovie.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostPlayedMovie.ToString().Should().Be("The Hunt for Red October (1990)");

            mostPlayedMovie.Tagline.Should().Be("Invisible. Silent. Stolen.");

            mostPlayedMovie.Overview.Should().Be("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostPlayedMovie.Released.Should().Be(TestUtility.ParseDate("1990-03-02"));
#else
            mostPlayedMovie.Released.Should().Be(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostPlayedMovie.Runtime.Should().Be(135U);
            mostPlayedMovie.Country.Should().Be("us");
            mostPlayedMovie.Trailer.Should().Be("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostPlayedMovie.Homepage.Should().Be("http://www.paramount.com/movies/hunt-red-october");
            mostPlayedMovie.Status.Should().Be(TraktMovieStatus.Released);
            mostPlayedMovie.Rating.Should().Be(7.9446390086206895f);
            mostPlayedMovie.Votes.Should().Be(7424U);
            mostPlayedMovie.CommentCount.Should().Be(22U);
            mostPlayedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostPlayedMovie.Language.Should().Be("en");
            mostPlayedMovie.Languages.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo(["en", "ru"]);

            mostPlayedMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(39).And.BeEquivalentTo([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            mostPlayedMovie.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "action", "adventure", "thriller"
            ]);

            mostPlayedMovie.Certification.Should().Be("PG-13");

            // --------------------------------------------------------------------------------------------

            mostPlayedMovie = mostPlayedMovies![1];

            mostPlayedMovie.Should().NotBeNull();

            mostPlayedMovie.WatcherCount.Should().Be(9076U);
            mostPlayedMovie.PlayCount.Should().Be(12102U);
            mostPlayedMovie.CollectedCount.Should().Be(3533U);

            mostPlayedMovie.Title.Should().Be("Rebel Ridge");
            mostPlayedMovie.Year.Should().Be(2024U);

            mostPlayedMovie.Ids!.Trakt.Should().Be(483193U);
            mostPlayedMovie.Ids!.Slug.Should().Be("rebel-ridge-2024");
            mostPlayedMovie.Ids!.IMDB.Should().Be("tt11301886");
            mostPlayedMovie.Ids!.TMDB.Should().Be(646097U);
            mostPlayedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostPlayedMovie.Ids!.BestID.Should().Be("rebel-ridge-2024");

            mostPlayedMovie.ToString().Should().Be("Rebel Ridge (2024)");

            mostPlayedMovie.Tagline.Should().Be("Their laws. His rules.");

            mostPlayedMovie.Overview.Should().Be("A former Marine confronts corruption in a small town when local law enforcement unjustly "
                + "seizes the bag of cash he needs to post his cousin's bail.");

#if NET7_0_OR_GREATER
            mostPlayedMovie!.Released.Should().Be(TestUtility.ParseDate("2024-09-06"));
#else
            mostPlayedMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("2024-09-06T00:00:00.000Z"));
#endif
            mostPlayedMovie.Runtime.Should().Be(132U);
            mostPlayedMovie.Country.Should().Be("us");
            mostPlayedMovie.Trailer.Should().Be("https://youtube.com/watch?v=gF3gZicntIw");
            mostPlayedMovie.Homepage.Should().Be("http://www.netflix.com/title/81157729");
            mostPlayedMovie.Status.Should().Be(TraktMovieStatus.Released);
            mostPlayedMovie.Rating.Should().Be(7.067648663393344f);
            mostPlayedMovie.Votes.Should().Be(1833U);
            mostPlayedMovie.CommentCount.Should().Be(27U);
            mostPlayedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-15T08:05:18.000Z"));
            mostPlayedMovie.Language.Should().Be("en");
            mostPlayedMovie.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            mostPlayedMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(34).And.BeEquivalentTo([
                "ar", "bg", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hi", "hr", "hu", "id",
                "it", "ja", "ka", "ko", "nl", "no", "pl", "pt", "ro", "ru", "sl", "sv", "th", "tl", "tr", "uk",
                "vi", "zh"
            ]);

            mostPlayedMovie.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "thriller", "crime", "action"
            ]);

            mostPlayedMovie.Certification.Should().Be("R");
        }
    }
}
