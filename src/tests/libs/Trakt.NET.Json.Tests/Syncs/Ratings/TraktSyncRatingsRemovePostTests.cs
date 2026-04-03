namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncRatingsRemovePostTests
    {
        [Fact]
        public void TestTraktSyncRatingsRemovePostValidate()
        {
            var syncRatingsRemovePost = new TraktSyncRatingsRemovePost();

            // movies = null, shows = null, seasons = null, episodes = null
            Action act = () => syncRatingsRemovePost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null
            syncRatingsRemovePost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null
            syncRatingsRemovePost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null
            syncRatingsRemovePost.Seasons = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty
            syncRatingsRemovePost.Episodes = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty
            syncRatingsRemovePost.Movies.Add(new TraktSyncRatingsRemovePostMovie());
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty
            syncRatingsRemovePost.Movies.Clear();
            syncRatingsRemovePost.Shows.Add(new TraktSyncRatingsRemovePostShow());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty
            syncRatingsRemovePost.Shows.Clear();
            syncRatingsRemovePost.Seasons.Add(new TraktSyncRatingsRemovePostSeason());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item
            syncRatingsRemovePost.Seasons.Clear();
            syncRatingsRemovePost.Episodes.Add(new TraktSyncRatingsRemovePostEpisode());
            act.ShouldNotThrow();
        }
    }
}
