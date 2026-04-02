namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncFavoritesPostMovieTests
    {
        [Fact]
        public void TestTraktSyncFavoritesPostMovieDefaultConstructor()
        {
            var syncFavoritesPostMovie = new TraktSyncFavoritesPostMovie();

            syncFavoritesPostMovie.Title.ShouldBeNull();
            syncFavoritesPostMovie.Year.ShouldBeNull();
            syncFavoritesPostMovie.IDs.ShouldBeNull();
            syncFavoritesPostMovie.Notes.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncFavoritesPostMovieFromJson()
        {
            TraktSyncFavoritesPostMovie? syncFavoritesPostMovie = await TestUtility.DeserializeJsonAsync<TraktSyncFavoritesPostMovie>("Syncs\\Favorites\\syncfavoritespostmovie.json");

            syncFavoritesPostMovie.ShouldNotBeNull();

            syncFavoritesPostMovie.Title.ShouldBe("Batman Begins");
            syncFavoritesPostMovie.Year.ShouldBe(2005U);
            syncFavoritesPostMovie.IDs.ShouldNotBeNull();
            syncFavoritesPostMovie.IDs.Trakt.ShouldBe(1U);
            syncFavoritesPostMovie.IDs.Slug.ShouldBe("batman-begins-2005");
            syncFavoritesPostMovie.IDs.IMDB.ShouldBe("tt0372784");
            syncFavoritesPostMovie.IDs.TMDB.ShouldBe(272U);
            syncFavoritesPostMovie.Notes.ShouldBe("One of Chritian Bale's most iconic roles.");
        }
    }
}
