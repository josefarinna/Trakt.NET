namespace TraktNET.Json.Users
{
    public sealed class TraktUserPersonalListItemsRemovePostTests
    {
        [Fact]
        public void TestTraktUserPersonalListItemsRemovePostValidate()
        {
            var userPersonalListItemsRemovePost = new TraktUserPersonalListItemsRemovePost();

            // movies = null, shows = null, seasons = null, episodes = null, people = null
            Action act = () => userPersonalListItemsRemovePost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null, people = null
            userPersonalListItemsRemovePost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null, people = null
            userPersonalListItemsRemovePost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null, people = null
            userPersonalListItemsRemovePost.Seasons = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, people = null
            userPersonalListItemsRemovePost.Episodes = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, people = empty
            userPersonalListItemsRemovePost.People = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty, people = empty
            userPersonalListItemsRemovePost.Movies.Add(new TraktUserPersonalListItemsPostMovie());
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty, people = empty
            userPersonalListItemsRemovePost.Movies.Clear();
            userPersonalListItemsRemovePost.Shows.Add(new TraktUserPersonalListItemsPostShow());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty, people = empty
            userPersonalListItemsRemovePost.Shows.Clear();
            userPersonalListItemsRemovePost.Seasons.Add(new TraktUserPersonalListItemsPostSeason());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item, people = empty
            userPersonalListItemsRemovePost.Seasons.Clear();
            userPersonalListItemsRemovePost.Episodes.Add(new TraktUserPersonalListItemsPostEpisode());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, people with at least one item
            userPersonalListItemsRemovePost.Episodes.Clear();
            userPersonalListItemsRemovePost.People.Add(new TraktUserPersonalListItemsPostPerson());
            act.ShouldNotThrow();
        }
    }
}
