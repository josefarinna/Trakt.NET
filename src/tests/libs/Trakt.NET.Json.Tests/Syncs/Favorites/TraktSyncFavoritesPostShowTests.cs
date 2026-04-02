namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncFavoritesPostShowTests
    {
        [Fact]
        public void TestTraktSyncFavoritesPostShowDefaultConstructor()
        {
            var syncFavoritesPostShow = new TraktSyncFavoritesPostShow();

            syncFavoritesPostShow.Title.ShouldBeNull();
            syncFavoritesPostShow.Year.ShouldBeNull();
            syncFavoritesPostShow.IDs.ShouldBeNull();
            syncFavoritesPostShow.Notes.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncFavoritesPostShowFromJson()
        {
            TraktSyncFavoritesPostShow? syncFavoritesPostShow = await TestUtility.DeserializeJsonAsync<TraktSyncFavoritesPostShow>("Syncs\\Favorites\\syncfavoritespostshow.json");

            syncFavoritesPostShow.ShouldNotBeNull();

            syncFavoritesPostShow.Title.ShouldBe("Breaking Bad");
            syncFavoritesPostShow.Year.ShouldBe(2008U);
            syncFavoritesPostShow.IDs.ShouldNotBeNull();
            syncFavoritesPostShow.IDs.Trakt.ShouldBe(1U);
            syncFavoritesPostShow.IDs.Slug.ShouldBe("breaking-bad");
            syncFavoritesPostShow.IDs.TVDB.ShouldBe(81189U);
            syncFavoritesPostShow.IDs.IMDB.ShouldBe("tt0903747");
            syncFavoritesPostShow.IDs.TMDB.ShouldBe(1396U);
            syncFavoritesPostShow.Notes.ShouldBe("I AM THE DANGER!");
        }
    }
}
