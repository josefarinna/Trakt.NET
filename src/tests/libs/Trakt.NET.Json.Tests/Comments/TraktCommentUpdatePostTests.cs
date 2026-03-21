namespace TraktNET.Json.Comments
{
    public sealed class TraktCommentUpdatePostTests
    {
        [Fact]
        public void TestTraktCommentUpdatePostValidate()
        {
#pragma warning disable CS8625
            var commentReplyPost = new TraktCommentUpdatePost
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
        }
    }
}
