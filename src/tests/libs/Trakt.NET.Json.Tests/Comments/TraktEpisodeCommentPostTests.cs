namespace TraktNET.Json.Comments
{
    public sealed class TraktEpisodeCommentPostTests
    {
        [Fact]
        public void TestTraktEpisodeCommentPostValidate()
        {
#pragma warning disable CS8625
            var episodeCommentPost = new TraktEpisodeCommentPost
            {
                Comment = null
            };
#pragma warning restore CS8625

            // Comment = null
            Action act = () => episodeCommentPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // Comment = less than five words
            episodeCommentPost.Comment = "one two three four";
            act.ShouldThrow<TraktPostValidationException>();

            // Episode = null
            episodeCommentPost.Comment = "one two three four five";
            act.ShouldThrow<TraktPostValidationException>();

            // Episode Ids = null
            episodeCommentPost.Episode = new TraktEpisode();
            act.ShouldThrow<TraktPostValidationException>();

            // Episode IDs have no valid id
            episodeCommentPost.Episode = new TraktEpisode
            {
                IDs = new TraktEpisodeIDs()
            };
            act.ShouldThrow<TraktPostValidationException>();

            // valid
            episodeCommentPost.Episode = new TraktEpisode
            {
                IDs = new TraktEpisodeIDs { Trakt = 1U }
            };
            act.ShouldNotThrow();
        }
    }
}
