namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncFavoritesRemovePostTests
    {
        [Fact]
        public void TestTraktSyncFavoritesRemovePostValidate()
        {
            var syncFavoritesRemovePost = new TraktSyncFavoritesRemovePost();

            // movies = null, shows = null
            Action act = () => syncFavoritesRemovePost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null
            syncFavoritesRemovePost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty
            syncFavoritesRemovePost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty
            syncFavoritesRemovePost.Movies.Add(new TraktSyncFavoritesPostMovie());
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item
            syncFavoritesRemovePost.Movies.Clear();
            syncFavoritesRemovePost.Shows.Add(new TraktSyncFavoritesPostShow());
            act.ShouldNotThrow();
        }
    }
}
