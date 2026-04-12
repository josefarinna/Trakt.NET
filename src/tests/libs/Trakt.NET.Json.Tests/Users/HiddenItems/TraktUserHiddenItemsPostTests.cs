namespace TraktNET.Json.Users
{
    public sealed class TraktUserHiddenItemsPostTests
    {
        [Fact]
        public void TestTraktHiddenItemsPostValidate()
        {
            var userHiddenItemsPost = new TraktUserHiddenItemsPost();

            // movies = null, shows = null, seasons = null, users = null
            Action act = () => userHiddenItemsPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, users = null
            userHiddenItemsPost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, users = null
            userHiddenItemsPost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, users = null
            userHiddenItemsPost.Seasons = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, users = empty
            userHiddenItemsPost.Users = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, users = empty
            userHiddenItemsPost.Movies.Add(new TraktUserHiddenItemsPostMovie());
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item, seasons = empty, users = empty
            userHiddenItemsPost.Movies.Clear();
            userHiddenItemsPost.Shows.Add(new TraktUserHiddenItemsPostShow());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons with at least one item, users = empty
            userHiddenItemsPost.Shows.Clear();
            userHiddenItemsPost.Seasons.Add(new TraktUserHiddenItemsPostSeason());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, users with at least one item
            userHiddenItemsPost.Seasons.Clear();
            userHiddenItemsPost.Users.Add(new TraktUser());
            act.ShouldNotThrow();
        }
    }
}
