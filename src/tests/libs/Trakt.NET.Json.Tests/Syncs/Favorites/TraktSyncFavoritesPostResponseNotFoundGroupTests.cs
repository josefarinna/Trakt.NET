namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncFavoritesPostResponseNotFoundGroupTests
    {
        [Fact]
        public void TestTraktSyncFavoritesPostResponseNotFoundGroupDefaultConstructor()
        {
            var syncFavoritesPostResponseNotFoundGroup = new TraktSyncFavoritesPostResponseNotFoundGroup();

            syncFavoritesPostResponseNotFoundGroup.Movies.ShouldBeNull();
            syncFavoritesPostResponseNotFoundGroup.Shows.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncFavoritesPostResponseNotFoundGroupFromJson()
        {
            TraktSyncFavoritesPostResponseNotFoundGroup? syncFavoritesPostResponseNotFoundGroup = await TestUtility.DeserializeJsonAsync<TraktSyncFavoritesPostResponseNotFoundGroup>("Syncs\\Favorites\\syncfavoritespostresponsenotfoundgroup.json");

            syncFavoritesPostResponseNotFoundGroup.ShouldNotBeNull();

            syncFavoritesPostResponseNotFoundGroup.Movies.ShouldNotBeNull();
            syncFavoritesPostResponseNotFoundGroup.Movies.Count.ShouldBe(1);

            TraktSyncFavoritesPostMovie[] notFoundMovies = syncFavoritesPostResponseNotFoundGroup.Movies.ToArray();

            notFoundMovies[0].ShouldNotBeNull();
            notFoundMovies[0].IDs.ShouldNotBeNull();
            notFoundMovies[0].IDs!.Trakt.ShouldBeNull();
            notFoundMovies[0].IDs!.Slug.ShouldBeNull();
            notFoundMovies[0].IDs!.IMDB.ShouldBe("tt0000111");
            notFoundMovies[0].IDs!.TMDB.ShouldBeNull();

            syncFavoritesPostResponseNotFoundGroup.Shows.ShouldNotBeNull();
            syncFavoritesPostResponseNotFoundGroup.Shows.Count.ShouldBe(1);

            TraktSyncFavoritesPostShow[] notFoundShows = syncFavoritesPostResponseNotFoundGroup.Shows.ToArray();

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
