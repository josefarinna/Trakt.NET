namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncFavoritesPostResponseTests
    {
        [Fact]
        public void TestTraktSyncFavoritesPostResponseDefaultConstructor()
        {
            var syncFavoritesPostResponse = new TraktSyncFavoritesPostResponse();

            syncFavoritesPostResponse.Added.ShouldBeNull();
            syncFavoritesPostResponse.Existing.ShouldBeNull();
            syncFavoritesPostResponse.NotFound.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncFavoritesPostResponseFromJson()
        {
            TraktSyncFavoritesPostResponse? syncFavoritesPostResponse = await TestUtility.DeserializeJsonAsync<TraktSyncFavoritesPostResponse>("Syncs\\Favorites\\syncfavoritespostresponse.json");

            syncFavoritesPostResponse.ShouldNotBeNull();

            syncFavoritesPostResponse.Added.ShouldNotBeNull();
            syncFavoritesPostResponse.Added.Movies.ShouldBe(1);
            syncFavoritesPostResponse.Added.Shows.ShouldBe(2);

            syncFavoritesPostResponse.Existing.ShouldNotBeNull();
            syncFavoritesPostResponse.Existing.Movies.ShouldBe(3);
            syncFavoritesPostResponse.Existing.Shows.ShouldBe(4);

            syncFavoritesPostResponse.NotFound.ShouldNotBeNull();

            syncFavoritesPostResponse.NotFound.Movies.ShouldNotBeNull();
            syncFavoritesPostResponse.NotFound.Movies.Count.ShouldBe(1);

            TraktSyncFavoritesPostMovie[] notFoundMovies = syncFavoritesPostResponse.NotFound.Movies.ToArray();

            notFoundMovies[0].ShouldNotBeNull();
            notFoundMovies[0].IDs.ShouldNotBeNull();
            notFoundMovies[0].IDs!.Trakt.ShouldBeNull();
            notFoundMovies[0].IDs!.Slug.ShouldBeNull();
            notFoundMovies[0].IDs!.IMDB.ShouldBe("tt0000111");
            notFoundMovies[0].IDs!.TMDB.ShouldBeNull();

            syncFavoritesPostResponse.NotFound.Shows.ShouldNotBeNull();
            syncFavoritesPostResponse.NotFound.Shows.Count.ShouldBe(1);

            TraktSyncFavoritesPostShow[] notFoundShows = syncFavoritesPostResponse.NotFound.Shows.ToArray();

            notFoundShows[0].ShouldNotBeNull();
            notFoundShows[0].IDs.ShouldNotBeNull();
            notFoundShows[0].IDs!.Trakt.ShouldBeNull();
            notFoundShows[0].IDs!.Slug.ShouldBeNull();
            notFoundShows[0].IDs!.IMDB.ShouldBe("tt0000222");
            notFoundShows[0].IDs!.TVDB.ShouldBeNull();
            notFoundShows[0].IDs!.TMDB.ShouldBeNull();
        }
    }
}
