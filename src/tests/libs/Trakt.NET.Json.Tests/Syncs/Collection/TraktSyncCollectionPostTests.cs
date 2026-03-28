namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCollectionPostTests
    {
        [Fact]
        public void TestTraktSyncCollectionPostValidate()
        {
            var syncCollectionPost = new TraktSyncCollectionPost();

            // movies = null, shows = null, seasons = null, episodes = null
            Action act = () => syncCollectionPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null
            syncCollectionPost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null
            syncCollectionPost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null
            syncCollectionPost.Seasons = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty
            syncCollectionPost.Episodes = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty
            syncCollectionPost.Movies.Add(new TraktSyncCollectionPostMovie());
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty
            syncCollectionPost.Movies.Clear();
            syncCollectionPost.Shows.Add(new TraktSyncCollectionPostShow());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty
            syncCollectionPost.Shows.Clear();
            syncCollectionPost.Seasons.Add(new TraktSyncCollectionPostSeason());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item
            syncCollectionPost.Seasons.Clear();
            syncCollectionPost.Episodes.Add(new TraktSyncCollectionPostEpisode());
            act.ShouldNotThrow();
        }
    }
}
