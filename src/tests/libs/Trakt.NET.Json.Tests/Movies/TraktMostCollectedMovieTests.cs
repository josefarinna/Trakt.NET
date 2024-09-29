namespace TraktNET.Json.Movies
{
    public sealed class TraktMostCollectedMovieTests
    {
        [Fact]
        public void TestTraktMostCollectedMovieConstructor()
        {
            var mostCollectedMovie = new TraktMostCollectedMovie();

            mostCollectedMovie.WatcherCount.Should().BeNull();
            mostCollectedMovie.PlayCount.Should().BeNull();
            mostCollectedMovie.CollectedCount.Should().BeNull();
            mostCollectedMovie.Title.Should().BeNull();
            mostCollectedMovie.Year.Should().BeNull();
            mostCollectedMovie.Ids.Should().BeNull();
            mostCollectedMovie.Tagline.Should().BeNull();
            mostCollectedMovie.Overview.Should().BeNull();
            mostCollectedMovie.Released.Should().BeNull();
            mostCollectedMovie.Runtime.Should().BeNull();
            mostCollectedMovie.Country.Should().BeNull();
            mostCollectedMovie.Trailer.Should().BeNull();
            mostCollectedMovie.Homepage.Should().BeNull();
            mostCollectedMovie.Status.Should().BeNull();
            mostCollectedMovie.Rating.Should().BeNull();
            mostCollectedMovie.Votes.Should().BeNull();
            mostCollectedMovie.CommentCount.Should().BeNull();
            mostCollectedMovie.UpdatedAt.Should().BeNull();
            mostCollectedMovie.Language.Should().BeNull();
            mostCollectedMovie.Languages.Should().BeNull();
            mostCollectedMovie.AvailableTranslations.Should().BeNull();
            mostCollectedMovie.Genres.Should().BeNull();
            mostCollectedMovie.Certification.Should().BeNull();

            mostCollectedMovie.ToString().Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktMostCollectedMovieFromJsonMinimal()
        {
            TraktMostCollectedMovie? mostCollectedMovie = await TestUtility.DeserializeJsonAsync<TraktMostCollectedMovie>("Movies\\mostpwcmovie_minimal.json");

            mostCollectedMovie.Should().NotBeNull();

            mostCollectedMovie!.WatcherCount.Should().Be(10606U);
            mostCollectedMovie!.PlayCount.Should().Be(14142U);
            mostCollectedMovie!.CollectedCount.Should().Be(107U);

            mostCollectedMovie!.Title.Should().Be("The Hunt for Red October");
            mostCollectedMovie!.Year.Should().Be(1990U);

            mostCollectedMovie!.Ids!.Trakt.Should().Be(1111U);
            mostCollectedMovie!.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostCollectedMovie!.Ids!.IMDB.Should().Be("tt0099810");
            mostCollectedMovie!.Ids!.TMDB.Should().Be(1669U);
            mostCollectedMovie!.Ids!.HasAnyID.Should().BeTrue();
            mostCollectedMovie!.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostCollectedMovie!.ToString().Should().Be("The Hunt for Red October (1990)");
        }

        [Fact]
        public async Task TestTraktMostCollectedMovieFromJson()
        {
            TraktMostCollectedMovie? mostCollectedMovie = await TestUtility.DeserializeJsonAsync<TraktMostCollectedMovie>("Movies\\mostpwcmovie.json");

            mostCollectedMovie.Should().NotBeNull();

            mostCollectedMovie!.WatcherCount.Should().Be(10606U);
            mostCollectedMovie!.PlayCount.Should().Be(14142U);
            mostCollectedMovie!.CollectedCount.Should().Be(107U);

            mostCollectedMovie!.Title.Should().Be("The Hunt for Red October");
            mostCollectedMovie!.Year.Should().Be(1990U);

            mostCollectedMovie!.Ids!.Trakt.Should().Be(1111U);
            mostCollectedMovie!.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostCollectedMovie!.Ids!.IMDB.Should().Be("tt0099810");
            mostCollectedMovie!.Ids!.TMDB.Should().Be(1669U);
            mostCollectedMovie!.Ids!.HasAnyID.Should().BeTrue();
            mostCollectedMovie!.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostCollectedMovie!.ToString().Should().Be("The Hunt for Red October (1990)");

            mostCollectedMovie!.Tagline.Should().Be("Invisible. Silent. Stolen.");

            mostCollectedMovie!.Overview.Should().Be("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostCollectedMovie!.Released.Should().Be(TestUtility.ParseDate("1990-03-02"));
#else
            mostCollectedMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostCollectedMovie!.Runtime.Should().Be(135U);
            mostCollectedMovie!.Country.Should().Be("us");
            mostCollectedMovie!.Trailer.Should().Be("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostCollectedMovie!.Homepage.Should().Be("http://www.paramount.com/movies/hunt-red-october");
            mostCollectedMovie!.Status.Should().Be(TraktMovieStatus.Released);
            mostCollectedMovie!.Rating.Should().Be(7.9446390086206895f);
            mostCollectedMovie!.Votes.Should().Be(7424U);
            mostCollectedMovie!.CommentCount.Should().Be(22U);
            mostCollectedMovie!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostCollectedMovie!.Language.Should().Be("en");
            mostCollectedMovie!.Languages.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo(["en", "ru"]);

            mostCollectedMovie!.AvailableTranslations.Should().NotBeNull().And.HaveCount(39).And.BeEquivalentTo([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            mostCollectedMovie!.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "action", "adventure", "thriller"
            ]);

            mostCollectedMovie!.Certification.Should().Be("PG-13");
        }

        [Fact]
        public async Task TestTraktMostCollectedMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktMostCollectedMovie>? mostCollectedMovies = await TestUtility.DeserializeJsonListAsync<TraktMostCollectedMovie>("Movies\\mostpwcmovies_minimal.json");

            mostCollectedMovies.Should().NotBeNull().And.HaveCount(2);

            TraktMostCollectedMovie mostCollectedMovie = mostCollectedMovies![0];

            mostCollectedMovie.Should().NotBeNull();

            mostCollectedMovie.WatcherCount.Should().Be(10606U);
            mostCollectedMovie.PlayCount.Should().Be(14142U);
            mostCollectedMovie.CollectedCount.Should().Be(107U);

            mostCollectedMovie.Title.Should().Be("The Hunt for Red October");
            mostCollectedMovie.Year.Should().Be(1990U);

            mostCollectedMovie.Ids!.Trakt.Should().Be(1111U);
            mostCollectedMovie.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostCollectedMovie.Ids!.IMDB.Should().Be("tt0099810");
            mostCollectedMovie.Ids!.TMDB.Should().Be(1669U);
            mostCollectedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostCollectedMovie.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostCollectedMovie.ToString().Should().Be("The Hunt for Red October (1990)");

            // --------------------------------------------------------------------------------------------

            mostCollectedMovie = mostCollectedMovies![1];

            mostCollectedMovie.Should().NotBeNull();

            mostCollectedMovie.WatcherCount.Should().Be(9076U);
            mostCollectedMovie.PlayCount.Should().Be(12102U);
            mostCollectedMovie.CollectedCount.Should().Be(3533U);

            mostCollectedMovie.Title.Should().Be("Rebel Ridge");
            mostCollectedMovie.Year.Should().Be(2024U);

            mostCollectedMovie.Ids!.Trakt.Should().Be(483193U);
            mostCollectedMovie.Ids!.Slug.Should().Be("rebel-ridge-2024");
            mostCollectedMovie.Ids!.IMDB.Should().Be("tt11301886");
            mostCollectedMovie.Ids!.TMDB.Should().Be(646097U);
            mostCollectedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostCollectedMovie.Ids!.BestID.Should().Be("rebel-ridge-2024");

            mostCollectedMovie.ToString().Should().Be("Rebel Ridge (2024)");
        }

        [Fact]
        public async Task TestTraktMostCollectedMoviesFromJson()
        {
            IReadOnlyList<TraktMostCollectedMovie>? mostCollectedMovies = await TestUtility.DeserializeJsonListAsync<TraktMostCollectedMovie>("Movies\\mostpwcmovies.json");

            mostCollectedMovies.Should().NotBeNull().And.HaveCount(2);

            TraktMostCollectedMovie mostCollectedMovie = mostCollectedMovies![0];

            mostCollectedMovie.Should().NotBeNull();

            mostCollectedMovie.WatcherCount.Should().Be(10606U);
            mostCollectedMovie.PlayCount.Should().Be(14142U);
            mostCollectedMovie.CollectedCount.Should().Be(107U);

            mostCollectedMovie.Title.Should().Be("The Hunt for Red October");
            mostCollectedMovie.Year.Should().Be(1990U);

            mostCollectedMovie.Ids!.Trakt.Should().Be(1111U);
            mostCollectedMovie.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostCollectedMovie.Ids!.IMDB.Should().Be("tt0099810");
            mostCollectedMovie.Ids!.TMDB.Should().Be(1669U);
            mostCollectedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostCollectedMovie.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostCollectedMovie.ToString().Should().Be("The Hunt for Red October (1990)");

            mostCollectedMovie.Tagline.Should().Be("Invisible. Silent. Stolen.");

            mostCollectedMovie.Overview.Should().Be("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostCollectedMovie.Released.Should().Be(TestUtility.ParseDate("1990-03-02"));
#else
            mostCollectedMovie.Released.Should().Be(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostCollectedMovie.Runtime.Should().Be(135U);
            mostCollectedMovie.Country.Should().Be("us");
            mostCollectedMovie.Trailer.Should().Be("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostCollectedMovie.Homepage.Should().Be("http://www.paramount.com/movies/hunt-red-october");
            mostCollectedMovie.Status.Should().Be(TraktMovieStatus.Released);
            mostCollectedMovie.Rating.Should().Be(7.9446390086206895f);
            mostCollectedMovie.Votes.Should().Be(7424U);
            mostCollectedMovie.CommentCount.Should().Be(22U);
            mostCollectedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostCollectedMovie.Language.Should().Be("en");
            mostCollectedMovie.Languages.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo(["en", "ru"]);

            mostCollectedMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(39).And.BeEquivalentTo([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            mostCollectedMovie.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "action", "adventure", "thriller"
            ]);

            mostCollectedMovie.Certification.Should().Be("PG-13");

            // --------------------------------------------------------------------------------------------

            mostCollectedMovie = mostCollectedMovies![1];

            mostCollectedMovie.Should().NotBeNull();

            mostCollectedMovie.WatcherCount.Should().Be(9076U);
            mostCollectedMovie.PlayCount.Should().Be(12102U);
            mostCollectedMovie.CollectedCount.Should().Be(3533U);

            mostCollectedMovie.Title.Should().Be("Rebel Ridge");
            mostCollectedMovie.Year.Should().Be(2024U);

            mostCollectedMovie.Ids!.Trakt.Should().Be(483193U);
            mostCollectedMovie.Ids!.Slug.Should().Be("rebel-ridge-2024");
            mostCollectedMovie.Ids!.IMDB.Should().Be("tt11301886");
            mostCollectedMovie.Ids!.TMDB.Should().Be(646097U);
            mostCollectedMovie.Ids!.HasAnyID.Should().BeTrue();
            mostCollectedMovie.Ids!.BestID.Should().Be("rebel-ridge-2024");

            mostCollectedMovie.ToString().Should().Be("Rebel Ridge (2024)");

            mostCollectedMovie.Tagline.Should().Be("Their laws. His rules.");

            mostCollectedMovie.Overview.Should().Be("A former Marine confronts corruption in a small town when local law enforcement unjustly "
                + "seizes the bag of cash he needs to post his cousin's bail.");

#if NET7_0_OR_GREATER
            mostCollectedMovie!.Released.Should().Be(TestUtility.ParseDate("2024-09-06"));
#else
            mostCollectedMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("2024-09-06T00:00:00.000Z"));
#endif
            mostCollectedMovie.Runtime.Should().Be(132U);
            mostCollectedMovie.Country.Should().Be("us");
            mostCollectedMovie.Trailer.Should().Be("https://youtube.com/watch?v=gF3gZicntIw");
            mostCollectedMovie.Homepage.Should().Be("http://www.netflix.com/title/81157729");
            mostCollectedMovie.Status.Should().Be(TraktMovieStatus.Released);
            mostCollectedMovie.Rating.Should().Be(7.067648663393344f);
            mostCollectedMovie.Votes.Should().Be(1833U);
            mostCollectedMovie.CommentCount.Should().Be(27U);
            mostCollectedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-15T08:05:18.000Z"));
            mostCollectedMovie.Language.Should().Be("en");
            mostCollectedMovie.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            mostCollectedMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(34).And.BeEquivalentTo([
                "ar", "bg", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hi", "hr", "hu", "id",
                "it", "ja", "ka", "ko", "nl", "no", "pl", "pt", "ro", "ru", "sl", "sv", "th", "tl", "tr", "uk",
                "vi", "zh"
            ]);

            mostCollectedMovie.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "thriller", "crime", "action"
            ]);

            mostCollectedMovie.Certification.Should().Be("R");
        }
    }
}
