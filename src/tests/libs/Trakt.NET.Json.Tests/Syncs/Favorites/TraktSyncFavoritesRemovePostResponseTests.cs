namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncFavoritesRemovePostResponseTests
    {
        [Fact]
        public void TestTraktSyncFavoritesRemovePostResponseDefaultConstructor()
        {
            var syncFavoritesRemovePostResponse = new TraktSyncFavoritesRemovePostResponse();

            syncFavoritesRemovePostResponse.Deleted.ShouldBeNull();
            syncFavoritesRemovePostResponse.NotFound.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncFavoritesRemovePostResponseFromJson()
        {
            TraktSyncFavoritesRemovePostResponse? syncFavoritesRemovePostResponse = await TestUtility.DeserializeJsonAsync<TraktSyncFavoritesRemovePostResponse>("Syncs\\Favorites\\syncfavoritesremovepostresponse.json");

            syncFavoritesRemovePostResponse.ShouldNotBeNull();

            syncFavoritesRemovePostResponse.Deleted.ShouldNotBeNull();
            syncFavoritesRemovePostResponse.Deleted.Movies.ShouldBe(1U);
            syncFavoritesRemovePostResponse.Deleted.Shows.ShouldBe(2U);

            syncFavoritesRemovePostResponse.NotFound.ShouldNotBeNull();

            syncFavoritesRemovePostResponse.NotFound.Movies.ShouldNotBeNull();
            syncFavoritesRemovePostResponse.NotFound.Movies.Count.ShouldBe(1);

            TraktSyncFavoritesPostMovie[] notFoundMovies = [.. syncFavoritesRemovePostResponse.NotFound.Movies];

            notFoundMovies[0].ShouldNotBeNull();
            notFoundMovies[0].IDs.ShouldNotBeNull();
            notFoundMovies[0].IDs!.Trakt.ShouldBeNull();
            notFoundMovies[0].IDs!.Slug.ShouldBeNull();
            notFoundMovies[0].IDs!.IMDB.ShouldBe("tt0000111");
            notFoundMovies[0].IDs!.TMDB.ShouldBeNull();

            syncFavoritesRemovePostResponse.NotFound.Shows.ShouldNotBeNull();
            syncFavoritesRemovePostResponse.NotFound.Shows.Count.ShouldBe(1);

            TraktSyncFavoritesPostShow[] notFoundShows = [.. syncFavoritesRemovePostResponse.NotFound.Shows];

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
