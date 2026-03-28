namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncWatchlistPostTests
    {
        [Fact]
        public void TestTraktSyncWatchlistPostValidate()
        {
            var syncWatchlistPost = new TraktSyncWatchlistPost();

            // movies = null, shows = null, seasons = null, episodes = null
            Action act = () => syncWatchlistPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null
            syncWatchlistPost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null
            syncWatchlistPost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null
            syncWatchlistPost.Seasons = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty
            syncWatchlistPost.Episodes = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty
            syncWatchlistPost.Movies.Add(new TraktSyncWatchlistPostMovie());
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty
            syncWatchlistPost.Movies.Clear();
            syncWatchlistPost.Shows.Add(new TraktSyncWatchlistPostShow());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty
            syncWatchlistPost.Shows.Clear();
            syncWatchlistPost.Seasons.Add(new TraktSyncWatchlistPostSeason());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item
            syncWatchlistPost.Seasons.Clear();
            syncWatchlistPost.Episodes.Add(new TraktSyncWatchlistPostEpisode());
            act.ShouldNotThrow();
        }
    }
}
