namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncCollectionRemovePostTests
    {
        [Fact]
        public void TestTraktSyncCollectionRemovePostValidate()
        {
            var syncCollectionRemovePost = new TraktSyncCollectionRemovePost();

            // movies = null, shows = null, seasons = null, episodes = null
            Action act = () => syncCollectionRemovePost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null
            syncCollectionRemovePost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null
            syncCollectionRemovePost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null
            syncCollectionRemovePost.Seasons = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty
            syncCollectionRemovePost.Episodes = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty
            syncCollectionRemovePost.Movies.Add(new TraktSyncRemovePostMovie());
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty
            syncCollectionRemovePost.Movies.Clear();
            syncCollectionRemovePost.Shows.Add(new TraktSyncRemovePostShow());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty
            syncCollectionRemovePost.Shows.Clear();
            syncCollectionRemovePost.Seasons.Add(new TraktSyncRemovePostSeason());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item
            syncCollectionRemovePost.Seasons.Clear();
            syncCollectionRemovePost.Episodes.Add(new TraktSyncRemovePostEpisode());
            act.ShouldNotThrow();
        }
    }
}
