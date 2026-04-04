namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncWatchlistRemovePostTests
    {
        [Fact]
        public void TestTraktSyncWatchlistRemovePostValidate()
        {
            var syncWatchlistRemovePost = new TraktSyncWatchlistRemovePost();

            // movies = null, shows = null, seasons = null, episodes = null
            Action act = () => syncWatchlistRemovePost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null
            syncWatchlistRemovePost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null
            syncWatchlistRemovePost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null
            syncWatchlistRemovePost.Seasons = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty
            syncWatchlistRemovePost.Episodes = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty
            syncWatchlistRemovePost.Movies.Add(new TraktSyncRemovePostMovie());
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty
            syncWatchlistRemovePost.Movies.Clear();
            syncWatchlistRemovePost.Shows.Add(new TraktSyncRemovePostShow());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty
            syncWatchlistRemovePost.Shows.Clear();
            syncWatchlistRemovePost.Seasons.Add(new TraktSyncRemovePostSeason());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item
            syncWatchlistRemovePost.Seasons.Clear();
            syncWatchlistRemovePost.Episodes.Add(new TraktSyncRemovePostEpisode());
            act.ShouldNotThrow();
        }
    }
}
