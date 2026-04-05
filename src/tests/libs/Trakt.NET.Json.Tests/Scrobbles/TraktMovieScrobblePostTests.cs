namespace TraktNET.Scrobbles
{
    public sealed class TraktMovieScrobblePostTests
    {
        [Fact]
        public void TestTraktMovieScrobblePostValidate()
        {
            var movieScrobblePost = new TraktMovieScrobblePost { Progress = 0 };

            // Movie = null, Progress = 0
            Action act = () => movieScrobblePost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // Movie Ids = null, Progress = 0
            movieScrobblePost.Movie = new TraktMovie();
            act.ShouldThrow<TraktPostValidationException>();

            // Movie IDs have no valid id, Progress = 0
            movieScrobblePost.Movie = new TraktMovie { IDs = new TraktMovieIDs() };
            act.ShouldThrow<TraktPostValidationException>();

            // Movie valid, Progress not valid
            movieScrobblePost.Movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 1 } };
            movieScrobblePost.Progress = -0.1f;
            act.ShouldThrow<TraktPostValidationException>();

            // Movie valid, Progress not valid
            movieScrobblePost.Movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 1 } };
            movieScrobblePost.Progress = 100.1f;
            act.ShouldThrow<TraktPostValidationException>();

            // valid
            movieScrobblePost.Movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 1 } };
            movieScrobblePost.Progress = 0;
            act.ShouldNotThrow();

            // valid
            movieScrobblePost.Movie = new TraktMovie { IDs = new TraktMovieIDs { Trakt = 1 } };
            movieScrobblePost.Progress = 100;
            act.ShouldNotThrow();
        }
    }
}
