namespace TraktNET.Json.Comments
{
    public sealed class TraktCommentReplyPostTests
    {
        [Fact]
        public void TestTraktCommentReplyPostValidate()
        {
#pragma warning disable CS8625
            var commentReplyPost = new TraktCommentReplyPost
            {
                Comment = null
            };
#pragma warning restore CS8625

            // Comment = null
            Action act = () => commentReplyPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // Comment = less than five words
            commentReplyPost.Comment = "one two three four";
            act.ShouldThrow<TraktPostValidationException>();

            // valid
            commentReplyPost.Comment = "one two three four five";
            act.ShouldNotThrow();

            // valid with GIF and null comment
            commentReplyPost.Comment = null;
            commentReplyPost.Gif = "https://example.com/test.gif";
            commentReplyPost.GifWidth = 480;
            commentReplyPost.GifHeight = 270;
            act.ShouldNotThrow();

            // valid with GIF and short comment
            commentReplyPost.Comment = "nice";
            act.ShouldNotThrow();
        }
    }
}
