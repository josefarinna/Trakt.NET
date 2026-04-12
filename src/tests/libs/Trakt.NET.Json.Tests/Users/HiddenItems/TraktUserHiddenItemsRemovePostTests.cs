namespace TraktNET.Json.Users
{
    public sealed class TraktUserHiddenItemsRemovePostTests
    {
        [Fact]
        public void TestTraktHiddenItemsRemovePostValidate()
        {
            var userHiddenItemsRemovePost = new TraktUserHiddenItemsRemovePost();

            // movies = null, shows = null, seasons = null, users = null
            Action act = () => userHiddenItemsRemovePost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, users = null
            userHiddenItemsRemovePost.Movies = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, users = null
            userHiddenItemsRemovePost.Shows = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, users = null
            userHiddenItemsRemovePost.Seasons = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, users = empty
            userHiddenItemsRemovePost.Users = [];
            act.ShouldThrow<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, users = empty
            userHiddenItemsRemovePost.Movies.Add(new TraktUserHiddenItemsPostMovie());
            act.ShouldNotThrow();

            // movies = empty, shows with at least one item, seasons = empty, users = empty
            userHiddenItemsRemovePost.Movies.Clear();
            userHiddenItemsRemovePost.Shows.Add(new TraktUserHiddenItemsPostShow());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons with at least one item, users = empty
            userHiddenItemsRemovePost.Shows.Clear();
            userHiddenItemsRemovePost.Seasons.Add(new TraktUserHiddenItemsPostSeason());
            act.ShouldNotThrow();

            // movies = empty, shows = empty, seasons = empty, users with at least one item
            userHiddenItemsRemovePost.Seasons.Clear();
            userHiddenItemsRemovePost.Users.Add(new TraktUser());
            act.ShouldNotThrow();
        }
    }
}
