namespace TraktNET.Json.Comments
{
    public sealed class TraktListCommentPostTests
    {
        [Fact]
        public void TestTraktListCommentPostValidate()
        {
#pragma warning disable CS8625
            var ListCommentPost = new TraktListCommentPost
            {
                Comment = null
            };
#pragma warning restore CS8625

            // Comment = null
            Action act = () => ListCommentPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // Comment = less than five words
            ListCommentPost.Comment = "one two three four";
            act.ShouldThrow<TraktPostValidationException>();

            // List = null
            ListCommentPost.Comment = "one two three four five";
            act.ShouldThrow<TraktPostValidationException>();

            // List Ids = null
            ListCommentPost.List = new TraktList();
            act.ShouldThrow<TraktPostValidationException>();

            // List IDs have no valid id
            ListCommentPost.List = new TraktList
            {
                IDs = new TraktListIDs()
            };
            act.ShouldThrow<TraktPostValidationException>();

            // valid
            ListCommentPost.List = new TraktList
            {
                IDs = new TraktListIDs { Trakt = 1U }
            };
            act.ShouldNotThrow();
        }
    }
}
