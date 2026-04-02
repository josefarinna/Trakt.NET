namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncFavoritesPostResponseGroupTests
    {
        [Fact]
        public void TestTraktSyncFavoritesPostResponseGroupDefaultConstructor()
        {
            var syncFavoritesPostResponseGroup = new TraktSyncFavoritesPostResponseGroup();

            syncFavoritesPostResponseGroup.Movies.ShouldBeNull();
            syncFavoritesPostResponseGroup.Shows.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktSyncFavoritesPostResponseGroupFromJson()
        {
            TraktSyncFavoritesPostResponseGroup? syncFavoritesPostResponseGroup = await TestUtility.DeserializeJsonAsync<TraktSyncFavoritesPostResponseGroup>("Syncs\\Favorites\\syncfavoritespostresponsegroup.json");

            syncFavoritesPostResponseGroup.ShouldNotBeNull();

            syncFavoritesPostResponseGroup.Movies.ShouldBe(1U);
            syncFavoritesPostResponseGroup.Shows.ShouldBe(2U);
        }
    }
}
