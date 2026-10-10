namespace TraktNET.Json.Comments
{
    public sealed class TraktShowCommentPostTests
    {
        [Fact]
        public void TestTraktShowCommentPostValidate()
        {
#pragma warning disable CS8625
            var ShowCommentPost = new TraktShowCommentPost
            {
                Comment = null
            };
#pragma warning restore CS8625

            // Comment = null
            Action act = () => ShowCommentPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // Comment = less than five words
            ShowCommentPost.Comment = "one two three four";
            act.ShouldThrow<TraktPostValidationException>();

            // Show = null
            ShowCommentPost.Comment = "one two three four five";
            act.ShouldThrow<TraktPostValidationException>();

            // Show Ids = null
            ShowCommentPost.Show = new TraktShow();
            act.ShouldThrow<TraktPostValidationException>();

            // Show IDs have no valid id
            ShowCommentPost.Show = new TraktShow
            {
                IDs = new TraktShowIDs()
            };
            act.ShouldThrow<TraktPostValidationException>();

            // valid
            ShowCommentPost.Show = new TraktShow
            {
                IDs = new TraktShowIDs { Trakt = 1U }
            };
            act.ShouldNotThrow();

            // valid with GIF and null comment
            ShowCommentPost.Comment = null;
            ShowCommentPost.Gif = new TraktCommentGif
            {
                Url = "https://example.com/test.gif",
                Slug = "test-gif"
            };
            act.ShouldNotThrow();

            // valid with GIF and short comment
            ShowCommentPost.Comment = "nice";
            act.ShouldNotThrow();
        }
    }
}
