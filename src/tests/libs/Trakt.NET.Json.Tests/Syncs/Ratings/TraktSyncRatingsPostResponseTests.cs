namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncRatingsPostResponseTests
    {
        [Fact]
        public void TestTraktSyncRatingsPostResponseDefaultConstructor()
        {
            var syncRatingsPostResponse = new TraktSyncRatingsPostResponse();

            syncRatingsPostResponse.Added.ShouldBeNull();
            syncRatingsPostResponse.NotFound.ShouldBeNull();
        }

        [Fact]
        public void TestTraktSyncRatingsPostResponseNotFoundMovieDefaultConstructor()
        {
            var notFoundMovie = new TraktSyncRatingsPostResponseNotFoundMovie();

            notFoundMovie.Rating.ShouldBeNull();
            notFoundMovie.RatedAt.ShouldBeNull();
            notFoundMovie.IDs.ShouldBeNull();
        }

        [Fact]
        public void TestTraktSyncRatingsPostResponseNotFoundShowDefaultConstructor()
        {
            var notFoundShow = new TraktSyncRatingsPostResponseNotFoundShow();

            notFoundShow.Rating.ShouldBeNull();
            notFoundShow.RatedAt.ShouldBeNull();
            notFoundShow.IDs.ShouldBeNull();
            notFoundShow.Seasons.ShouldBeNull();
        }

        [Fact]
        public void TestTraktSyncRatingsPostResponseNotFoundSeasonDefaultConstructor()
        {
            var notFoundSeason = new TraktSyncRatingsPostResponseNotFoundSeason();

            notFoundSeason.Rating.ShouldBeNull();
            notFoundSeason.RatedAt.ShouldBeNull();
            notFoundSeason.IDs.ShouldBeNull();
        }

        [Fact]
        public void TestTraktSyncRatingsPostResponseNotFoundEpisodeDefaultConstructor()
        {
            var notFoundEpisode = new TraktSyncRatingsPostResponseNotFoundEpisode();

            notFoundEpisode.Rating.ShouldBeNull();
            notFoundEpisode.RatedAt.ShouldBeNull();
            notFoundEpisode.IDs.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncRatingsPostResponseFromJson()
        {
            TraktSyncRatingsPostResponse? syncRatingsPostResponse = await TestUtility.DeserializeJsonAsync<TraktSyncRatingsPostResponse>("Syncs\\Ratings\\syncratingspostresponse.json");

            syncRatingsPostResponse.ShouldNotBeNull();

            syncRatingsPostResponse.Added.ShouldNotBeNull();
            syncRatingsPostResponse.Added.Movies.ShouldBe(1U);
            syncRatingsPostResponse.Added.Shows.ShouldBe(2U);
            syncRatingsPostResponse.Added.Seasons.ShouldBe(3U);
            syncRatingsPostResponse.Added.Episodes.ShouldBe(4U);

            syncRatingsPostResponse.NotFound.ShouldNotBeNull();

            syncRatingsPostResponse.NotFound.Movies.ShouldNotBeNull();
            syncRatingsPostResponse.NotFound.Movies.Count.ShouldBe(1);

            TraktSyncRatingsPostResponseNotFoundMovie[] notFoundMovies = [.. syncRatingsPostResponse.NotFound.Movies];

            notFoundMovies[0].ShouldNotBeNull();
            notFoundMovies[0].Rating.ShouldBe(10);
            notFoundMovies[0].RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            notFoundMovies[0].IDs.ShouldNotBeNull();
            notFoundMovies[0].IDs!.Trakt.ShouldBeNull();
            notFoundMovies[0].IDs!.Slug.ShouldBeNull();
            notFoundMovies[0].IDs!.IMDB.ShouldBe("tt0000111");
            notFoundMovies[0].IDs!.TMDB.ShouldBeNull();

            syncRatingsPostResponse.NotFound.Shows.ShouldNotBeNull();
            syncRatingsPostResponse.NotFound.Shows.Count.ShouldBe(1);

            TraktSyncRatingsPostResponseNotFoundShow[] notFoundShows = [.. syncRatingsPostResponse.NotFound.Shows];

            notFoundShows[0].ShouldNotBeNull();
            notFoundShows[0].Rating.ShouldBe(9);
            notFoundShows[0].RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            notFoundShows[0].IDs.ShouldNotBeNull();
            notFoundShows[0].IDs!.Trakt.ShouldBe(1U);
            notFoundShows[0].Seasons.ShouldNotBeNull();
            notFoundShows[0].Seasons!.Count.ShouldBe(1);

            notFoundShows[0].Seasons![0].Number.ShouldBe(1U);
            notFoundShows[0].Seasons![0].Rating.ShouldBe(8);
            notFoundShows[0].Seasons![0].RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));
            notFoundShows[0].Seasons![0].Episodes.ShouldNotBeNull();
            notFoundShows[0].Seasons![0].Episodes!.Count.ShouldBe(1);
            notFoundShows[0].Seasons![0].Episodes![0].Number.ShouldBe(1U);
            notFoundShows[0].Seasons![0].Episodes![0].Rating.ShouldBe(7);
            notFoundShows[0].Seasons![0].Episodes![0].RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-10-11T17:00:54.000Z"));

            syncRatingsPostResponse.NotFound.Seasons.ShouldNotBeNull();
            syncRatingsPostResponse.NotFound.Seasons.Count.ShouldBe(0);

            syncRatingsPostResponse.NotFound.Episodes.ShouldNotBeNull();
            syncRatingsPostResponse.NotFound.Episodes.Count.ShouldBe(0);
        }
    }
}
