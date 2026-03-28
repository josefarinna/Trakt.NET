namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncHistoryPostTests
    {
        [Fact]
        public void TestTraktSyncHistoryPostValidate()
        {
            var syncHistoryPost = new TraktSyncHistoryPost();

            // movies = null, shows = null, seasons = null, episodes = null
            Action act = () => syncHistoryPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null
            syncHistoryPost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null
            syncHistoryPost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null
            syncHistoryPost.Seasons = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty
            syncHistoryPost.Episodes = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty
            syncHistoryPost.Movies.Add(new TraktSyncHistoryPostMovie());
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty
            syncHistoryPost.Movies.Clear();
            syncHistoryPost.Shows.Add(new TraktSyncHistoryPostShow());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty
            syncHistoryPost.Shows.Clear();
            syncHistoryPost.Seasons.Add(new TraktSyncHistoryPostSeason());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item
            syncHistoryPost.Seasons.Clear();
            syncHistoryPost.Episodes.Add(new TraktSyncHistoryPostEpisode());
            act.ShouldNotThrow();
        }
    }
}
