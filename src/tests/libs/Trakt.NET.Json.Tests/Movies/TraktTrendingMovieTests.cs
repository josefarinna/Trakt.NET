namespace TraktNET.Json.Movies
{
    public sealed class TraktTrendingMovieTests
    {
        [Fact]
        public void TestTraktTrendingMovieConstructor()
        {
            var trendingMovie = new TraktTrendingMovie();

            trendingMovie.Watchers.Should().BeNull();
            trendingMovie.Title.Should().BeNull();
            trendingMovie.Year.Should().BeNull();
            trendingMovie.Ids.Should().BeNull();
            trendingMovie.Tagline.Should().BeNull();
            trendingMovie.Overview.Should().BeNull();
            trendingMovie.Released.Should().BeNull();
            trendingMovie.Runtime.Should().BeNull();
            trendingMovie.Country.Should().BeNull();
            trendingMovie.Trailer.Should().BeNull();
            trendingMovie.Homepage.Should().BeNull();
            trendingMovie.Status.Should().BeNull();
            trendingMovie.Rating.Should().BeNull();
            trendingMovie.Votes.Should().BeNull();
            trendingMovie.CommentCount.Should().BeNull();
            trendingMovie.UpdatedAt.Should().BeNull();
            trendingMovie.Language.Should().BeNull();
            trendingMovie.Languages.Should().BeNull();
            trendingMovie.AvailableTranslations.Should().BeNull();
            trendingMovie.Genres.Should().BeNull();
            trendingMovie.Certification.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktTrendingMovieFromJsonMinimal()
        {
            TraktTrendingMovie? trendingMovie = await TestUtility.DeserializeJsonAsync<TraktTrendingMovie>("Movies\\trendingmovie_minimal.json");

            trendingMovie.Should().NotBeNull();

            trendingMovie!.Watchers.Should().Be(58U);

            trendingMovie!.Title.Should().Be("Deadpool & Wolverine");
            trendingMovie!.Year.Should().Be(2024U);

            trendingMovie!.Ids!.Trakt.Should().Be(395672U);
            trendingMovie!.Ids!.Slug.Should().Be("deadpool-wolverine-2024");
            trendingMovie!.Ids!.IMDB.Should().Be("tt6263850");
            trendingMovie!.Ids!.TMDB.Should().Be(533535U);
            trendingMovie!.Ids!.HasAnyID.Should().BeTrue();
            trendingMovie!.Ids!.BestID.Should().Be("deadpool-wolverine-2024");
        }

        [Fact]
        public async Task TestTraktTrendingMovieFromJson()
        {
            TraktTrendingMovie? trendingMovie = await TestUtility.DeserializeJsonAsync<TraktTrendingMovie>("Movies\\trendingmovie.json");

            trendingMovie.Should().NotBeNull();

            trendingMovie!.Watchers.Should().Be(58U);

            trendingMovie!.Title.Should().Be("Deadpool & Wolverine");
            trendingMovie!.Year.Should().Be(2024U);

            trendingMovie!.Ids!.Trakt.Should().Be(395672U);
            trendingMovie!.Ids!.Slug.Should().Be("deadpool-wolverine-2024");
            trendingMovie!.Ids!.IMDB.Should().Be("tt6263850");
            trendingMovie!.Ids!.TMDB.Should().Be(533535U);
            trendingMovie!.Ids!.HasAnyID.Should().BeTrue();
            trendingMovie!.Ids!.BestID.Should().Be("deadpool-wolverine-2024");

            trendingMovie!.Tagline.Should().Be("Come together.");

            trendingMovie!.Overview.Should().Be("A listless Wade Wilson toils away in civilian life with his days as the morally "
                + "flexible mercenary, Deadpool, behind him.");

            trendingMovie!.Released.Should().Be(TestUtility.ParseDate("2024-07-26"));
            trendingMovie!.Runtime.Should().Be(128U);
            trendingMovie!.Country.Should().Be("us");
            trendingMovie!.Trailer.Should().Be("https://youtube.com/watch?v=Idh8n5XuYIA");
            trendingMovie!.Homepage.Should().Be("http://www.marvel.com/movies/deadpool-and-wolverine");
            trendingMovie!.Status.Should().Be(TraktMovieStatus.Released);
            trendingMovie!.Rating.Should().Be(8.244876693296284f);
            trendingMovie!.Votes.Should().Be(5758U);
            trendingMovie!.CommentCount.Should().Be(159U);
            trendingMovie!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-08-07T08:05:37.000Z"));
            trendingMovie!.Language.Should().Be("en");
            trendingMovie!.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            trendingMovie!.AvailableTranslations.Should().NotBeNull().And.HaveCount(31).And.BeEquivalentTo([
                "ar", "bg", "cs", "de", "el", "en", "es", "fa", "fr", "he", "hu", "id", "it", "ja", "ka", "kk",
                "ko", "lt", "nl", "pl", "pt", "ru", "sk", "sl", "sr", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            trendingMovie!.Genres.Should().NotBeNull().And.HaveCount(4).And.BeEquivalentTo([
                "comedy", "superhero", "science-fiction", "action"
            ]);

            trendingMovie!.Certification.Should().Be("R");
        }

        [Fact]
        public async Task TestTraktTrendingMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktTrendingMovie>? trendingMovies = await TestUtility.DeserializeJsonListAsync<TraktTrendingMovie>("Movies\\trendingmovies_minimal.json");

            trendingMovies.Should().NotBeNull().And.HaveCount(2);

            TraktTrendingMovie trendingMovie = trendingMovies![0];

            trendingMovie.Should().NotBeNull();

            trendingMovie.Watchers.Should().Be(58U);

            trendingMovie.Title.Should().Be("Deadpool & Wolverine");
            trendingMovie.Year.Should().Be(2024U);

            trendingMovie.Ids!.Trakt.Should().Be(395672U);
            trendingMovie.Ids!.Slug.Should().Be("deadpool-wolverine-2024");
            trendingMovie.Ids!.IMDB.Should().Be("tt6263850");
            trendingMovie.Ids!.TMDB.Should().Be(533535U);
            trendingMovie.Ids!.HasAnyID.Should().BeTrue();
            trendingMovie.Ids!.BestID.Should().Be("deadpool-wolverine-2024");

            // --------------------------------------------------------------------------------------------

            trendingMovie = trendingMovies![1];

            trendingMovie.Should().NotBeNull();

            trendingMovie.Watchers.Should().Be(43U);

            trendingMovie.Title.Should().Be("Kingdom of the Planet of the Apes");
            trendingMovie.Year.Should().Be(2024U);

            trendingMovie.Ids!.Trakt.Should().Be(488280U);
            trendingMovie.Ids!.Slug.Should().Be("kingdom-of-the-planet-of-the-apes-2024");
            trendingMovie.Ids!.IMDB.Should().Be("tt11389872");
            trendingMovie.Ids!.TMDB.Should().Be(653346U);
            trendingMovie.Ids!.HasAnyID.Should().BeTrue();
            trendingMovie.Ids!.BestID.Should().Be("kingdom-of-the-planet-of-the-apes-2024");
        }

        [Fact]
        public async Task TestTraktTrendingMoviesFromJson()
        {
            IReadOnlyList<TraktTrendingMovie>? trendingMovies = await TestUtility.DeserializeJsonListAsync<TraktTrendingMovie>("Movies\\trendingmovies.json");

            trendingMovies.Should().NotBeNull().And.HaveCount(2);

            TraktTrendingMovie trendingMovie = trendingMovies![0];

            trendingMovie.Should().NotBeNull();

            trendingMovie.Watchers.Should().Be(58U);

            trendingMovie.Title.Should().Be("Deadpool & Wolverine");
            trendingMovie.Year.Should().Be(2024U);

            trendingMovie.Ids!.Trakt.Should().Be(395672U);
            trendingMovie.Ids!.Slug.Should().Be("deadpool-wolverine-2024");
            trendingMovie.Ids!.IMDB.Should().Be("tt6263850");
            trendingMovie.Ids!.TMDB.Should().Be(533535U);
            trendingMovie.Ids!.HasAnyID.Should().BeTrue();
            trendingMovie.Ids!.BestID.Should().Be("deadpool-wolverine-2024");

            trendingMovie.Tagline.Should().Be("Come together.");

            trendingMovie.Overview.Should().Be("A listless Wade Wilson toils away in civilian life with his days as the morally "
                + "flexible mercenary, Deadpool, behind him.");

            trendingMovie.Released.Should().Be(TestUtility.ParseDate("2024-07-26"));
            trendingMovie.Runtime.Should().Be(128U);
            trendingMovie.Country.Should().Be("us");
            trendingMovie.Trailer.Should().Be("https://youtube.com/watch?v=Idh8n5XuYIA");
            trendingMovie.Homepage.Should().Be("http://www.marvel.com/movies/deadpool-and-wolverine");
            trendingMovie.Status.Should().Be(TraktMovieStatus.Released);
            trendingMovie.Rating.Should().Be(8.244876693296284f);
            trendingMovie.Votes.Should().Be(5758U);
            trendingMovie.CommentCount.Should().Be(159U);
            trendingMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-08-07T08:05:37.000Z"));
            trendingMovie.Language.Should().Be("en");
            trendingMovie.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            trendingMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(31).And.BeEquivalentTo([
                "ar", "bg", "cs", "de", "el", "en", "es", "fa", "fr", "he", "hu", "id", "it", "ja", "ka", "kk",
                "ko", "lt", "nl", "pl", "pt", "ru", "sk", "sl", "sr", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            trendingMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.BeEquivalentTo([
                "comedy", "superhero", "science-fiction", "action"
            ]);

            trendingMovie.Certification.Should().Be("R");

            // --------------------------------------------------------------------------------------------

            trendingMovie = trendingMovies![1];

            trendingMovie.Should().NotBeNull();

            trendingMovie.Watchers.Should().Be(43U);

            trendingMovie.Title.Should().Be("Kingdom of the Planet of the Apes");
            trendingMovie.Year.Should().Be(2024U);

            trendingMovie.Ids!.Trakt.Should().Be(488280U);
            trendingMovie.Ids!.Slug.Should().Be("kingdom-of-the-planet-of-the-apes-2024");
            trendingMovie.Ids!.IMDB.Should().Be("tt11389872");
            trendingMovie.Ids!.TMDB.Should().Be(653346U);
            trendingMovie.Ids!.HasAnyID.Should().BeTrue();
            trendingMovie.Ids!.BestID.Should().Be("kingdom-of-the-planet-of-the-apes-2024");

            trendingMovie.Tagline.Should().Be("No one can stop the reign.");

            trendingMovie.Overview.Should().Be("Several generations following Caesar's reign, apes – now the dominant species – "
                + "live harmoniously while humans have been reduced to living in the shadows.");

            trendingMovie.Released.Should().Be(TestUtility.ParseDate("2024-05-10"));
            trendingMovie.Runtime.Should().Be(145U);
            trendingMovie.Country.Should().Be("us");
            trendingMovie.Trailer.Should().Be("https://youtube.com/watch?v=Tg1FesR8X90");
            trendingMovie.Homepage.Should().Be("http://www.20thcenturystudios.com/movies/kingdom-of-the-planet-of-the-apes");
            trendingMovie.Status.Should().Be(TraktMovieStatus.Released);
            trendingMovie.Rating.Should().Be(7.188150289017341f);
            trendingMovie.Votes.Should().Be(6920U);
            trendingMovie.CommentCount.Should().Be(79U);
            trendingMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-08-07T08:05:40.000Z"));
            trendingMovie.Language.Should().Be("en");
            trendingMovie.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            trendingMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(36).And.BeEquivalentTo([
                "ar", "az", "bg", "ca", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hr", "hu",
                "id", "it", "ja", "ka", "ko", "lt", "nl", "pl", "pt", "ro", "ru", "sk", "sl", "sr", "sv", "th",
                "tr", "uk", "vi", "zh"
            ]);

            trendingMovie.Genres.Should().NotBeNull().And.HaveCount(3).And.BeEquivalentTo([
                "action", "science-fiction", "adventure"
            ]);

            trendingMovie.Certification.Should().Be("PG-13");
        }
    }
}
