namespace TraktNET.Json.Comments
{
    public sealed class TraktSeasonCommentPostTests
    {
        [Fact]
        public void TestTraktSeasonCommentPostValidate()
        {
#pragma warning disable CS8625
            var SeasonCommentPost = new TraktSeasonCommentPost
            {
                Comment = null
            };
#pragma warning restore CS8625

            // Comment = null
            Action act = () => SeasonCommentPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // Comment = less than five words
            SeasonCommentPost.Comment = "one two three four";
            act.ShouldThrow<TraktPostValidationException>();

            // Season = null
            SeasonCommentPost.Comment = "one two three four five";
            act.ShouldThrow<TraktPostValidationException>();

            // Season Ids = null
            SeasonCommentPost.Season = new TraktSeason();
            act.ShouldThrow<TraktPostValidationException>();

            // Season IDs have no valid id
            SeasonCommentPost.Season = new TraktSeason
            {
                IDs = new TraktSeasonIDs()
            };
            act.ShouldThrow<TraktPostValidationException>();

            // valid
            SeasonCommentPost.Season = new TraktSeason
            {
                IDs = new TraktSeasonIDs { Trakt = 1U }
            };
            act.ShouldNotThrow();
        }
    }
}
