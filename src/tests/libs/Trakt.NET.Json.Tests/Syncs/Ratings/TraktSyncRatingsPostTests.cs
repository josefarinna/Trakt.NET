namespace TraktNET.Json.Syncs
{
    public sealed class TraktSyncRatingsPostTests
    {
        [Fact]
        public void TestTraktSyncRatingsPostValidate()
        {
            var syncRatingsPost = new TraktSyncRatingsPost();

            // movies = null, shows = null, seasons = null, episodes = null
            Action act = () => syncRatingsPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null
            syncRatingsPost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null
            syncRatingsPost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null
            syncRatingsPost.Seasons = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty
            syncRatingsPost.Episodes = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty
            syncRatingsPost.Movies.Add(new TraktSyncRatingsPostMovie { Rating = 1 });
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty
            syncRatingsPost.Movies.Clear();
            syncRatingsPost.Shows.Add(new TraktSyncRatingsPostShow { Rating = 1 });
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty
            syncRatingsPost.Shows.Clear();
            syncRatingsPost.Seasons.Add(new TraktSyncRatingsPostSeason { Rating = 1 });
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item
            syncRatingsPost.Seasons.Clear();
            syncRatingsPost.Episodes.Add(new TraktSyncRatingsPostEpisode{ Rating = 1 });
            act.ShouldNotThrow();
        }
    }
}
