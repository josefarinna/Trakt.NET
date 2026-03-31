namespace TraktNET.Json.Watched
{
    public sealed class TraktWatchedMovieTests
    {
        [Fact]
        public void TestTraktWatchedMovieDefaultConstructor()
        {
            var watchedMovie = new TraktWatchedMovie();

            watchedMovie.Plays.ShouldBeNull();
            watchedMovie.LastWatchedAt.ShouldBeNull();
            watchedMovie.LastUpdatedAt.ShouldBeNull();
            watchedMovie.Movie.ShouldBeNull();
            watchedMovie.Title.ShouldBeNullOrEmpty();
            watchedMovie.Year.ShouldBeNull();
            watchedMovie.IDs.ShouldBeNull();
            watchedMovie.Tagline.ShouldBeNullOrEmpty();
            watchedMovie.Overview.ShouldBeNullOrEmpty();
            watchedMovie.Released.ShouldBeNull();
            watchedMovie.Runtime.ShouldBeNull();
            watchedMovie.UpdatedAt.ShouldBeNull();
            watchedMovie.Trailer.ShouldBeNullOrEmpty();
            watchedMovie.Homepage.ShouldBeNullOrEmpty();
            watchedMovie.Rating.ShouldBeNull();
            watchedMovie.Votes.ShouldBeNull();
            watchedMovie.Language.ShouldBeNullOrEmpty();
            watchedMovie.AvailableTranslations.ShouldBeNull();
            watchedMovie.Genres.ShouldBeNull();
            watchedMovie.Certification.ShouldBeNullOrEmpty();
            watchedMovie.Country.ShouldBeNullOrEmpty();
        }

        [Fact]
        public async Task TestTraktWatchedMovieFromMinimalJson()
        {
            TraktWatchedMovie? watchedMovie = await TestUtility.DeserializeJsonAsync<TraktWatchedMovie>("Watched\\watchedmovie_minimal.json");

            watchedMovie.ShouldNotBeNull();
            watchedMovie.Plays.ShouldBe(10U);
            watchedMovie.LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            watchedMovie.LastUpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            watchedMovie.Movie.ShouldNotBeNull();
            watchedMovie.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            watchedMovie.Movie.Year.ShouldBe(2015U);
            watchedMovie.Movie.IDs.ShouldNotBeNull();
            watchedMovie.Movie.IDs.Trakt.ShouldBe(94024U);
            watchedMovie.Movie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            watchedMovie.Movie.IDs.IMDB.ShouldBe("tt2488496");
            watchedMovie.Movie.IDs.TMDB.ShouldBe(140607U);
            watchedMovie.Movie.Tagline.ShouldBeNullOrEmpty();
            watchedMovie.Movie.Overview.ShouldBeNullOrEmpty();
            watchedMovie.Movie.Released.ShouldBeNull();
            watchedMovie.Movie.Runtime.ShouldBeNull();
            watchedMovie.Movie.UpdatedAt.ShouldBeNull();
            watchedMovie.Movie.Trailer.ShouldBeNullOrEmpty();
            watchedMovie.Movie.Homepage.ShouldBeNullOrEmpty();
            watchedMovie.Movie.Rating.ShouldBeNull();
            watchedMovie.Movie.Votes.ShouldBeNull();
            watchedMovie.Movie.Language.ShouldBeNullOrEmpty();
            watchedMovie.Movie.AvailableTranslations.ShouldBeNull();
            watchedMovie.Movie.Genres.ShouldBeNull();
            watchedMovie.Movie.Certification.ShouldBeNullOrEmpty();
            watchedMovie.Movie.Country.ShouldBeNullOrEmpty();

            watchedMovie.Title.ShouldBe("Star Wars: The Force Awakens");
            watchedMovie.Year.ShouldBe(2015U);
            watchedMovie.IDs.ShouldNotBeNull();
            watchedMovie.IDs.Trakt.ShouldBe(94024U);
            watchedMovie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            watchedMovie.IDs.IMDB.ShouldBe("tt2488496");
            watchedMovie.IDs.TMDB.ShouldBe(140607U);
            watchedMovie.Tagline.ShouldBeNullOrEmpty();
            watchedMovie.Overview.ShouldBeNullOrEmpty();
            watchedMovie.Released.ShouldBeNull();
            watchedMovie.Runtime.ShouldBeNull();
            watchedMovie.UpdatedAt.ShouldBeNull();
            watchedMovie.Trailer.ShouldBeNullOrEmpty();
            watchedMovie.Homepage.ShouldBeNullOrEmpty();
            watchedMovie.Rating.ShouldBeNull();
            watchedMovie.Votes.ShouldBeNull();
            watchedMovie.Language.ShouldBeNullOrEmpty();
            watchedMovie.AvailableTranslations.ShouldBeNull();
            watchedMovie.Genres.ShouldBeNull();
            watchedMovie.Certification.ShouldBeNullOrEmpty();
            watchedMovie.Country.ShouldBeNullOrEmpty();
        }

        [Fact]
        public async Task TestTraktWatchedMovieFromFullJson()
        {
            TraktWatchedMovie? watchedMovie = await TestUtility.DeserializeJsonAsync<TraktWatchedMovie>("Watched\\watchedmovie.json");

            watchedMovie.ShouldNotBeNull();
            watchedMovie.Plays.ShouldBe(10U);
            watchedMovie.LastWatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            watchedMovie.LastUpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));

            watchedMovie.Movie.ShouldNotBeNull();
            watchedMovie.Movie.Title.ShouldBe("Star Wars: The Force Awakens");
            watchedMovie.Movie.Year.ShouldBe(2015U);
            watchedMovie.Movie.IDs.ShouldNotBeNull();
            watchedMovie.Movie.IDs.Trakt.ShouldBe(94024U);
            watchedMovie.Movie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            watchedMovie.Movie.IDs.IMDB.ShouldBe("tt2488496");
            watchedMovie.Movie.IDs.TMDB.ShouldBe(140607U);
            watchedMovie.Movie.Tagline.ShouldBe("Every generation has a story.");
            watchedMovie.Movie.Overview.ShouldBe("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
#if NET7_0_OR_GREATER
            watchedMovie.Movie.Released.ShouldBe(TestUtility.ParseDate("2015-12-18"));
#else
            watchedMovie.Movie.Released.ShouldBe(TestUtility.ParseUTCDateTime("2015-12-18T00:00:00.000Z"));
#endif
            watchedMovie.Movie.Runtime.ShouldBe(136U);
            watchedMovie.Movie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-03-31T09:01:59Z"));
            watchedMovie.Movie.Trailer.ShouldBe("http://youtube.com/watch?v=uwa7N0ShN2U");
            watchedMovie.Movie.Homepage.ShouldBe("http://www.starwars.com/films/star-wars-episode-vii");
            watchedMovie.Movie.Rating.ShouldBe(8.31988f);
            watchedMovie.Movie.Votes.ShouldBe(9338U);
            watchedMovie.Movie.Language.ShouldBe("en");
            watchedMovie.Movie.AvailableTranslations.ShouldNotBeNull();
            watchedMovie.Movie.AvailableTranslations.Count.ShouldBe(4);
            watchedMovie.Movie.AvailableTranslations.ShouldBe(["en", "de", "en", "it"]);
            watchedMovie.Movie.Genres.ShouldNotBeNull();
            watchedMovie.Movie.Genres.Count.ShouldBe(4);
            watchedMovie.Movie.Genres.ShouldBe(["action", "adventure", "fantasy", "science-fiction"]);
            watchedMovie.Movie.Certification.ShouldBe("PG-13");
            watchedMovie.Movie.Country.ShouldBe("us");

            watchedMovie.Title.ShouldBe("Star Wars: The Force Awakens");
            watchedMovie.Year.ShouldBe(2015U);
            watchedMovie.IDs.ShouldNotBeNull();
            watchedMovie.IDs.Trakt.ShouldBe(94024U);
            watchedMovie.IDs.Slug.ShouldBe("star-wars-the-force-awakens-2015");
            watchedMovie.IDs.IMDB.ShouldBe("tt2488496");
            watchedMovie.IDs.TMDB.ShouldBe(140607U);
            watchedMovie.Tagline.ShouldBe("Every generation has a story.");
            watchedMovie.Overview.ShouldBe("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
#if NET7_0_OR_GREATER
            watchedMovie.Released.ShouldBe(TestUtility.ParseDate("2015-12-18"));
#else
            watchedMovie.Released.ShouldBe(TestUtility.ParseUTCDateTime("2015-12-18T00:00:00.000Z"));
#endif
            watchedMovie.Runtime.ShouldBe(136U);
            watchedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-03-31T09:01:59Z"));
            watchedMovie.Trailer.ShouldBe("http://youtube.com/watch?v=uwa7N0ShN2U");
            watchedMovie.Homepage.ShouldBe("http://www.starwars.com/films/star-wars-episode-vii");
            watchedMovie.Rating.ShouldBe(8.31988f);
            watchedMovie.Votes.ShouldBe(9338U);
            watchedMovie.Language.ShouldBe("en");
            watchedMovie.AvailableTranslations.ShouldNotBeNull();
            watchedMovie.AvailableTranslations.Count.ShouldBe(4);
            watchedMovie.AvailableTranslations.ShouldBe(["en", "de", "en", "it"]);
            watchedMovie.Genres.ShouldNotBeNull();
            watchedMovie.Genres.Count.ShouldBe(4);
            watchedMovie.Genres.ShouldBe(["action", "adventure", "fantasy", "science-fiction"]);
            watchedMovie.Certification.ShouldBe("PG-13");
            watchedMovie.Country.ShouldBe("us");
        }
    }
}
