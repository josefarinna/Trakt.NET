namespace TraktNET.Json.Movies
{
    public sealed class TraktMostPWCMovieTests
    {
        [Fact]
        public void TestTraktMostPWCMovieConstructor()
        {
            var mostPWCMovie = new TraktMostPWCMovie();

            mostPWCMovie.WatcherCount.Should().BeNull();
            mostPWCMovie.PlayCount.Should().BeNull();
            mostPWCMovie.CollectedCount.Should().BeNull();
            mostPWCMovie.Title.Should().BeNull();
            mostPWCMovie.Year.Should().BeNull();
            mostPWCMovie.Ids.Should().BeNull();
            mostPWCMovie.Tagline.Should().BeNull();
            mostPWCMovie.Overview.Should().BeNull();
            mostPWCMovie.Released.Should().BeNull();
            mostPWCMovie.Runtime.Should().BeNull();
            mostPWCMovie.Country.Should().BeNull();
            mostPWCMovie.Trailer.Should().BeNull();
            mostPWCMovie.Homepage.Should().BeNull();
            mostPWCMovie.Status.Should().BeNull();
            mostPWCMovie.Rating.Should().BeNull();
            mostPWCMovie.Votes.Should().BeNull();
            mostPWCMovie.CommentCount.Should().BeNull();
            mostPWCMovie.UpdatedAt.Should().BeNull();
            mostPWCMovie.Language.Should().BeNull();
            mostPWCMovie.Languages.Should().BeNull();
            mostPWCMovie.AvailableTranslations.Should().BeNull();
            mostPWCMovie.Genres.Should().BeNull();
            mostPWCMovie.Certification.Should().BeNull();

            mostPWCMovie.ToString().Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktMostPWCMovieFromJsonMinimal()
        {
            TraktMostPWCMovie? mostPWCMovie = await TestUtility.DeserializeJsonAsync<TraktMostPWCMovie>("Movies\\mostpwcmovie_minimal.json");

            mostPWCMovie.Should().NotBeNull();

            mostPWCMovie!.WatcherCount.Should().Be(10606U);
            mostPWCMovie!.PlayCount.Should().Be(14142U);
            mostPWCMovie!.CollectedCount.Should().Be(107U);

            mostPWCMovie!.Title.Should().Be("The Hunt for Red October");
            mostPWCMovie!.Year.Should().Be(1990U);

            mostPWCMovie!.Ids!.Trakt.Should().Be(1111U);
            mostPWCMovie!.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostPWCMovie!.Ids!.IMDB.Should().Be("tt0099810");
            mostPWCMovie!.Ids!.TMDB.Should().Be(1669U);
            mostPWCMovie!.Ids!.HasAnyID.Should().BeTrue();
            mostPWCMovie!.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostPWCMovie!.ToString().Should().Be("The Hunt for Red October (1990)");
        }

        [Fact]
        public async Task TestTraktMostPWCMovieFromJson()
        {
            TraktMostPWCMovie? mostPWCMovie = await TestUtility.DeserializeJsonAsync<TraktMostPWCMovie>("Movies\\mostpwcmovie.json");

            mostPWCMovie.Should().NotBeNull();

            mostPWCMovie!.WatcherCount.Should().Be(10606U);
            mostPWCMovie!.PlayCount.Should().Be(14142U);
            mostPWCMovie!.CollectedCount.Should().Be(107U);

            mostPWCMovie!.Title.Should().Be("The Hunt for Red October");
            mostPWCMovie!.Year.Should().Be(1990U);

            mostPWCMovie!.Ids!.Trakt.Should().Be(1111U);
            mostPWCMovie!.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostPWCMovie!.Ids!.IMDB.Should().Be("tt0099810");
            mostPWCMovie!.Ids!.TMDB.Should().Be(1669U);
            mostPWCMovie!.Ids!.HasAnyID.Should().BeTrue();
            mostPWCMovie!.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostPWCMovie!.ToString().Should().Be("The Hunt for Red October (1990)");

            mostPWCMovie!.Tagline.Should().Be("Invisible. Silent. Stolen.");

            mostPWCMovie!.Overview.Should().Be("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostPWCMovie!.Released.Should().Be(TestUtility.ParseDate("1990-03-02"));
#else
            mostPWCMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostPWCMovie!.Runtime.Should().Be(135U);
            mostPWCMovie!.Country.Should().Be("us");
            mostPWCMovie!.Trailer.Should().Be("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostPWCMovie!.Homepage.Should().Be("http://www.paramount.com/movies/hunt-red-october");
            mostPWCMovie!.Status.Should().Be(TraktMovieStatus.Released);
            mostPWCMovie!.Rating.Should().Be(7.9446390086206895f);
            mostPWCMovie!.Votes.Should().Be(7424U);
            mostPWCMovie!.CommentCount.Should().Be(22U);
            mostPWCMovie!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostPWCMovie!.Language.Should().Be("en");
            mostPWCMovie!.Languages.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo(["en", "ru"]);

            mostPWCMovie!.AvailableTranslations.Should().NotBeNull().And.HaveCount(39).And.BeEquivalentTo([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            mostPWCMovie!.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "action", "adventure", "thriller"
            ]);

            mostPWCMovie!.Certification.Should().Be("PG-13");
        }

        [Fact]
        public async Task TestTraktMostPWCMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktMostPWCMovie>? mostPWCMovies = await TestUtility.DeserializeJsonListAsync<TraktMostPWCMovie>("Movies\\mostpwcmovies_minimal.json");

            mostPWCMovies.Should().NotBeNull().And.HaveCount(2);

            TraktMostPWCMovie mostPWCMovie = mostPWCMovies![0];

            mostPWCMovie.Should().NotBeNull();

            mostPWCMovie.WatcherCount.Should().Be(10606U);
            mostPWCMovie.PlayCount.Should().Be(14142U);
            mostPWCMovie.CollectedCount.Should().Be(107U);

            mostPWCMovie.Title.Should().Be("The Hunt for Red October");
            mostPWCMovie.Year.Should().Be(1990U);

            mostPWCMovie.Ids!.Trakt.Should().Be(1111U);
            mostPWCMovie.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostPWCMovie.Ids!.IMDB.Should().Be("tt0099810");
            mostPWCMovie.Ids!.TMDB.Should().Be(1669U);
            mostPWCMovie.Ids!.HasAnyID.Should().BeTrue();
            mostPWCMovie.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostPWCMovie.ToString().Should().Be("The Hunt for Red October (1990)");

            // --------------------------------------------------------------------------------------------

            mostPWCMovie = mostPWCMovies![1];

            mostPWCMovie.Should().NotBeNull();

            mostPWCMovie.WatcherCount.Should().Be(9076U);
            mostPWCMovie.PlayCount.Should().Be(12102U);
            mostPWCMovie.CollectedCount.Should().Be(3533U);

            mostPWCMovie.Title.Should().Be("Rebel Ridge");
            mostPWCMovie.Year.Should().Be(2024U);

            mostPWCMovie.Ids!.Trakt.Should().Be(483193U);
            mostPWCMovie.Ids!.Slug.Should().Be("rebel-ridge-2024");
            mostPWCMovie.Ids!.IMDB.Should().Be("tt11301886");
            mostPWCMovie.Ids!.TMDB.Should().Be(646097U);
            mostPWCMovie.Ids!.HasAnyID.Should().BeTrue();
            mostPWCMovie.Ids!.BestID.Should().Be("rebel-ridge-2024");

            mostPWCMovie.ToString().Should().Be("Rebel Ridge (2024)");
        }

        [Fact]
        public async Task TestTraktMostPWCMoviesFromJson()
        {
            IReadOnlyList<TraktMostPWCMovie>? mostPWCMovies = await TestUtility.DeserializeJsonListAsync<TraktMostPWCMovie>("Movies\\mostpwcmovies.json");

            mostPWCMovies.Should().NotBeNull().And.HaveCount(2);

            TraktMostPWCMovie mostPWCMovie = mostPWCMovies![0];

            mostPWCMovie.Should().NotBeNull();

            mostPWCMovie.WatcherCount.Should().Be(10606U);
            mostPWCMovie.PlayCount.Should().Be(14142U);
            mostPWCMovie.CollectedCount.Should().Be(107U);

            mostPWCMovie.Title.Should().Be("The Hunt for Red October");
            mostPWCMovie.Year.Should().Be(1990U);

            mostPWCMovie.Ids!.Trakt.Should().Be(1111U);
            mostPWCMovie.Ids!.Slug.Should().Be("the-hunt-for-red-october-1990");
            mostPWCMovie.Ids!.IMDB.Should().Be("tt0099810");
            mostPWCMovie.Ids!.TMDB.Should().Be(1669U);
            mostPWCMovie.Ids!.HasAnyID.Should().BeTrue();
            mostPWCMovie.Ids!.BestID.Should().Be("the-hunt-for-red-october-1990");

            mostPWCMovie.ToString().Should().Be("The Hunt for Red October (1990)");

            mostPWCMovie.Tagline.Should().Be("Invisible. Silent. Stolen.");

            mostPWCMovie.Overview.Should().Be("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostPWCMovie.Released.Should().Be(TestUtility.ParseDate("1990-03-02"));
#else
            mostPWCMovie.Released.Should().Be(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostPWCMovie.Runtime.Should().Be(135U);
            mostPWCMovie.Country.Should().Be("us");
            mostPWCMovie.Trailer.Should().Be("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostPWCMovie.Homepage.Should().Be("http://www.paramount.com/movies/hunt-red-october");
            mostPWCMovie.Status.Should().Be(TraktMovieStatus.Released);
            mostPWCMovie.Rating.Should().Be(7.9446390086206895f);
            mostPWCMovie.Votes.Should().Be(7424U);
            mostPWCMovie.CommentCount.Should().Be(22U);
            mostPWCMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostPWCMovie.Language.Should().Be("en");
            mostPWCMovie.Languages.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo(["en", "ru"]);

            mostPWCMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(39).And.BeEquivalentTo([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            mostPWCMovie.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "action", "adventure", "thriller"
            ]);

            mostPWCMovie.Certification.Should().Be("PG-13");

            // --------------------------------------------------------------------------------------------

            mostPWCMovie = mostPWCMovies![1];

            mostPWCMovie.Should().NotBeNull();

            mostPWCMovie.WatcherCount.Should().Be(9076U);
            mostPWCMovie.PlayCount.Should().Be(12102U);
            mostPWCMovie.CollectedCount.Should().Be(3533U);

            mostPWCMovie.Title.Should().Be("Rebel Ridge");
            mostPWCMovie.Year.Should().Be(2024U);

            mostPWCMovie.Ids!.Trakt.Should().Be(483193U);
            mostPWCMovie.Ids!.Slug.Should().Be("rebel-ridge-2024");
            mostPWCMovie.Ids!.IMDB.Should().Be("tt11301886");
            mostPWCMovie.Ids!.TMDB.Should().Be(646097U);
            mostPWCMovie.Ids!.HasAnyID.Should().BeTrue();
            mostPWCMovie.Ids!.BestID.Should().Be("rebel-ridge-2024");

            mostPWCMovie.ToString().Should().Be("Rebel Ridge (2024)");

            mostPWCMovie.Tagline.Should().Be("Their laws. His rules.");

            mostPWCMovie.Overview.Should().Be("A former Marine confronts corruption in a small town when local law enforcement unjustly "
                + "seizes the bag of cash he needs to post his cousin's bail.");

#if NET7_0_OR_GREATER
            mostPWCMovie!.Released.Should().Be(TestUtility.ParseDate("2024-09-06"));
#else
            mostPWCMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("2024-09-06T00:00:00.000Z"));
#endif
            mostPWCMovie.Runtime.Should().Be(132U);
            mostPWCMovie.Country.Should().Be("us");
            mostPWCMovie.Trailer.Should().Be("https://youtube.com/watch?v=gF3gZicntIw");
            mostPWCMovie.Homepage.Should().Be("http://www.netflix.com/title/81157729");
            mostPWCMovie.Status.Should().Be(TraktMovieStatus.Released);
            mostPWCMovie.Rating.Should().Be(7.067648663393344f);
            mostPWCMovie.Votes.Should().Be(1833U);
            mostPWCMovie.CommentCount.Should().Be(27U);
            mostPWCMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-15T08:05:18.000Z"));
            mostPWCMovie.Language.Should().Be("en");
            mostPWCMovie.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            mostPWCMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(34).And.BeEquivalentTo([
                "ar", "bg", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hi", "hr", "hu", "id",
                "it", "ja", "ka", "ko", "nl", "no", "pl", "pt", "ro", "ru", "sl", "sv", "th", "tl", "tr", "uk",
                "vi", "zh"
            ]);

            mostPWCMovie.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "thriller", "crime", "action"
            ]);

            mostPWCMovie.Certification.Should().Be("R");
        }
    }
}
