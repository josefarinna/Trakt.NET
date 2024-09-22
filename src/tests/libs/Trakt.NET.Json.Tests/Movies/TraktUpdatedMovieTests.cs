namespace TraktNET.Json.Movies
{
    public sealed class TraktUpdatedMovieTests
    {
        [Fact]
        public void TestTraktUpdatedMovieConstructor()
        {
            var updatedMovie = new TraktUpdatedMovie();

            updatedMovie.Title.Should().BeNull();
            updatedMovie.Year.Should().BeNull();
            updatedMovie.Ids.Should().BeNull();
            updatedMovie.Tagline.Should().BeNull();
            updatedMovie.Overview.Should().BeNull();
            updatedMovie.Released.Should().BeNull();
            updatedMovie.Runtime.Should().BeNull();
            updatedMovie.Country.Should().BeNull();
            updatedMovie.Trailer.Should().BeNull();
            updatedMovie.Homepage.Should().BeNull();
            updatedMovie.Status.Should().BeNull();
            updatedMovie.Rating.Should().BeNull();
            updatedMovie.Votes.Should().BeNull();
            updatedMovie.CommentCount.Should().BeNull();
            updatedMovie.UpdatedAt.Should().BeNull();
            updatedMovie.Language.Should().BeNull();
            updatedMovie.Languages.Should().BeNull();
            updatedMovie.AvailableTranslations.Should().BeNull();
            updatedMovie.Genres.Should().BeNull();
            updatedMovie.Certification.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktUpdatedMovieFromJsonMinimal()
        {
            TraktUpdatedMovie? updatedMovie = await TestUtility.DeserializeJsonAsync<TraktUpdatedMovie>("Movies\\updatedmovie_minimal.json");

            updatedMovie.Should().NotBeNull();

            updatedMovie!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-23T01:16:57.000Z"));

            updatedMovie!.Title.Should().Be("Second Life");
            updatedMovie!.Year.Should().Be(2024U);

            updatedMovie!.Ids!.Trakt.Should().Be(1110139U);
            updatedMovie!.Ids!.Slug.Should().Be("second-life-2024-1110139");
            updatedMovie!.Ids!.IMDB.Should().Be("tt33111253");
            updatedMovie!.Ids!.TMDB.Should().Be(1329643U);
            updatedMovie!.Ids!.HasAnyID.Should().BeTrue();
            updatedMovie!.Ids!.BestID.Should().Be("second-life-2024-1110139");
        }

        [Fact]
        public async Task TestTraktUpdatedMovieFromJson()
        {
            TraktUpdatedMovie? updatedMovie = await TestUtility.DeserializeJsonAsync<TraktUpdatedMovie>("Movies\\updatedmovie.json");

            updatedMovie.Should().NotBeNull();

            updatedMovie!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-23T01:16:57.000Z"));

            updatedMovie!.Title.Should().Be("Second Life");
            updatedMovie!.Year.Should().Be(2024U);

            updatedMovie!.Ids!.Trakt.Should().Be(1110139U);
            updatedMovie!.Ids!.Slug.Should().Be("second-life-2024-1110139");
            updatedMovie!.Ids!.IMDB.Should().Be("tt33111253");
            updatedMovie!.Ids!.TMDB.Should().Be(1329643U);
            updatedMovie!.Ids!.HasAnyID.Should().BeTrue();
            updatedMovie!.Ids!.BestID.Should().Be("second-life-2024-1110139");

            updatedMovie!.Tagline.Should().BeEmpty();
            updatedMovie!.Overview.Should().Be("28 years ago, Liang gives birth to a boy named \"Little Bean Jelly\" in prison.");
            updatedMovie!.Released.Should().BeNull();
            updatedMovie!.Runtime.Should().Be(90U);
            updatedMovie!.Country.Should().Be("cn");
            updatedMovie!.Trailer.Should().Be("https://youtube.com/watch?v=m3SX4GyJn_M");
            updatedMovie!.Homepage.Should().Be("http://www.iq.com/album/second-life-2024-xxlxrt2rs0");
            updatedMovie!.Status.Should().Be(TraktMovieStatus.Released);
            updatedMovie!.Rating.Should().Be(0.0f);
            updatedMovie!.Votes.Should().Be(0U);
            updatedMovie!.CommentCount.Should().Be(0U);
            updatedMovie!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-23T01:16:57.000Z"));
            updatedMovie!.Language.Should().Be("zh");
            updatedMovie!.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["zh"]);

            updatedMovie!.AvailableTranslations.Should().BeEmpty();

            updatedMovie!.Genres.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo([
                "action", "comedy"
            ]);

            updatedMovie!.Certification.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktUpdatedMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktUpdatedMovie>? updatedMovies = await TestUtility.DeserializeJsonListAsync<TraktUpdatedMovie>("Movies\\updatedmovies_minimal.json");

            updatedMovies.Should().NotBeNull().And.HaveCount(2);

            TraktUpdatedMovie updatedMovie = updatedMovies![0];

            updatedMovie.Should().NotBeNull();

            updatedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-23T01:16:57.000Z"));

            updatedMovie.Title.Should().Be("Second Life");
            updatedMovie.Year.Should().Be(2024U);

            updatedMovie.Ids!.Trakt.Should().Be(1110139U);
            updatedMovie.Ids!.Slug.Should().Be("second-life-2024-1110139");
            updatedMovie.Ids!.IMDB.Should().Be("tt33111253");
            updatedMovie.Ids!.TMDB.Should().Be(1329643U);
            updatedMovie.Ids!.HasAnyID.Should().BeTrue();
            updatedMovie.Ids!.BestID.Should().Be("second-life-2024-1110139");

            // --------------------------------------------------------------------------------------------

            updatedMovie = updatedMovies![1];

            updatedMovie.Should().NotBeNull();

            updatedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-23T01:58:06.000Z"));

            updatedMovie.Title.Should().Be("Milk & Serial");
            updatedMovie.Year.Should().Be(2024U);

            updatedMovie.Ids!.Trakt.Should().Be(957899U);
            updatedMovie.Ids!.Slug.Should().Be("milk-serial-2024");
            updatedMovie.Ids!.IMDB.Should().Be("tt22075376");
            updatedMovie.Ids!.TMDB.Should().Be(1187782U);
            updatedMovie.Ids!.HasAnyID.Should().BeTrue();
            updatedMovie.Ids!.BestID.Should().Be("milk-serial-2024");
        }

        [Fact]
        public async Task TestTraktUpdatedMoviesFromJson()
        {
            IReadOnlyList<TraktUpdatedMovie>? updatedMovies = await TestUtility.DeserializeJsonListAsync<TraktUpdatedMovie>("Movies\\updatedmovies.json");

            updatedMovies.Should().NotBeNull().And.HaveCount(2);

            TraktUpdatedMovie updatedMovie = updatedMovies![0];

            updatedMovie.Should().NotBeNull();

            updatedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-23T01:16:57.000Z"));

            updatedMovie.Title.Should().Be("Second Life");
            updatedMovie.Year.Should().Be(2024U);

            updatedMovie.Ids!.Trakt.Should().Be(1110139U);
            updatedMovie.Ids!.Slug.Should().Be("second-life-2024-1110139");
            updatedMovie.Ids!.IMDB.Should().Be("tt33111253");
            updatedMovie.Ids!.TMDB.Should().Be(1329643U);
            updatedMovie.Ids!.HasAnyID.Should().BeTrue();
            updatedMovie.Ids!.BestID.Should().Be("second-life-2024-1110139");

            updatedMovie.Tagline.Should().BeEmpty();
            updatedMovie.Overview.Should().Be("28 years ago, Liang gives birth to a boy named \"Little Bean Jelly\" in prison.");
            updatedMovie.Released.Should().BeNull();
            updatedMovie.Runtime.Should().Be(90U);
            updatedMovie.Country.Should().Be("cn");
            updatedMovie.Trailer.Should().Be("https://youtube.com/watch?v=m3SX4GyJn_M");
            updatedMovie.Homepage.Should().Be("http://www.iq.com/album/second-life-2024-xxlxrt2rs0");
            updatedMovie.Status.Should().Be(TraktMovieStatus.Released);
            updatedMovie.Rating.Should().Be(0.0f);
            updatedMovie.Votes.Should().Be(0U);
            updatedMovie.CommentCount.Should().Be(0U);
            updatedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-23T01:16:57.000Z"));
            updatedMovie.Language.Should().Be("zh");
            updatedMovie.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["zh"]);

            updatedMovie.AvailableTranslations.Should().BeEmpty();

            updatedMovie.Genres.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo([
                "action", "comedy"
            ]);

            updatedMovie.Certification.Should().BeNull();

            // --------------------------------------------------------------------------------------------

            updatedMovie = updatedMovies![1];

            updatedMovie.Should().NotBeNull();

            updatedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-23T01:58:06.000Z"));

            updatedMovie.Title.Should().Be("Milk & Serial");
            updatedMovie.Year.Should().Be(2024U);

            updatedMovie.Ids!.Trakt.Should().Be(957899U);
            updatedMovie.Ids!.Slug.Should().Be("milk-serial-2024");
            updatedMovie.Ids!.IMDB.Should().Be("tt22075376");
            updatedMovie.Ids!.TMDB.Should().Be(1187782U);
            updatedMovie.Ids!.HasAnyID.Should().BeTrue();
            updatedMovie.Ids!.BestID.Should().Be("milk-serial-2024");

            updatedMovie.Tagline.Should().BeEmpty();

            updatedMovie.Overview.Should().Be("A surprise birthday prank takes a turn for the worse when a popular social media "
                + "duo must face the reality of the terrifying aftermath.");

#if NET7_0_OR_GREATER
            updatedMovie!.Released.Should().Be(TestUtility.ParseDate("2024-08-08"));
#else
            updatedMovie!.Released.Should().Be(TestUtility.ParseUTCDateTime("2024-08-08T00:00:00.000Z"));
#endif
            updatedMovie.Runtime.Should().Be(62U);
            updatedMovie.Country.Should().Be("us");
            updatedMovie.Trailer.Should().BeNull();
            updatedMovie.Homepage.Should().BeNull();
            updatedMovie.Status.Should().Be(TraktMovieStatus.Released);
            updatedMovie.Rating.Should().Be(6.5641f);
            updatedMovie.Votes.Should().Be(39U);
            updatedMovie.CommentCount.Should().Be(3U);
            updatedMovie.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-09-23T01:58:06.000Z"));
            updatedMovie.Language.Should().Be("en");
            updatedMovie.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            updatedMovie.AvailableTranslations.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            updatedMovie.Genres.Should().NotBeNull().And.HaveCount(2).And.BeEquivalentTo([
                "horror", "thriller"
            ]);

            updatedMovie.Certification.Should().BeNull();
        }
    }
}
