namespace TraktNET.Json.Comments
{
    public sealed class TraktMovieCommentPostTests
    {
        [Fact]
        public void TestTraktMovieCommentPostValidate()
        {
#pragma warning disable CS8625
            var MovieCommentPost = new TraktMovieCommentPost
            {
                Comment = null
            };
#pragma warning restore CS8625

            // Comment = null
            Action act = () => MovieCommentPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // Comment = less than five words
            MovieCommentPost.Comment = "one two three four";
            act.ShouldThrow<TraktPostValidationException>();

            // Movie = null
            MovieCommentPost.Comment = "one two three four five";
            act.ShouldThrow<TraktPostValidationException>();

            // Movie Ids = null
            MovieCommentPost.Movie = new TraktMovie();
            act.ShouldThrow<TraktPostValidationException>();

            // Movie IDs have no valid id
            MovieCommentPost.Movie = new TraktMovie
            {
                IDs = new TraktMovieIDs()
            };
            act.ShouldThrow<TraktPostValidationException>();

            // valid
            MovieCommentPost.Movie = new TraktMovie
            {
                IDs = new TraktMovieIDs { Trakt = 1U }
            };
            act.ShouldNotThrow();
        }
    }
}
