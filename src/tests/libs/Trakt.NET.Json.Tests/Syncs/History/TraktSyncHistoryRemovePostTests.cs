namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncHistoryRemovePostTests
    {
        [Fact]
        public void TestTraktSyncHistoryRemovePostValidate()
        {
            var syncHistoryRemovePost = new TraktSyncHistoryRemovePost();

            // movies = null, shows = null, seasons = null, episodes = null, history ids = null
            Action act = () => syncHistoryRemovePost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null, history ids = null
            syncHistoryRemovePost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null, history ids = null
            syncHistoryRemovePost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null, history ids = null
            syncHistoryRemovePost.Seasons = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, history ids = null
            syncHistoryRemovePost.Episodes = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, history ids = empty
            syncHistoryRemovePost.HistoryIDs = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty, history ids = empty
            syncHistoryRemovePost.Movies.Add(new TraktSyncHistoryRemovePostMovie());
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty, history ids = empty
            syncHistoryRemovePost.Movies.Clear();
            syncHistoryRemovePost.Shows.Add(new TraktSyncHistoryRemovePostShow());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty, history ids = empty
            syncHistoryRemovePost.Shows.Clear();
            syncHistoryRemovePost.Seasons.Add(new TraktSyncHistoryRemovePostSeason());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item, history ids = empty
            syncHistoryRemovePost.Seasons.Clear();
            syncHistoryRemovePost.Episodes.Add(new TraktSyncHistoryRemovePostEpisode());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, history ids with at least one item
            syncHistoryRemovePost.Episodes.Clear();
            syncHistoryRemovePost.HistoryIDs.Add(10);
            act.ShouldNotThrow();
        }
    }
}
