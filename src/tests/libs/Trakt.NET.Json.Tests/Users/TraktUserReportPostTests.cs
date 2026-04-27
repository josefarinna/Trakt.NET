namespace TraktNET.Json.Users
{
    public sealed class TraktUserReportPostTests
    {
        [Fact]
        public void TestTraktUserReportPostValidate()
        {
            var userReasonPost = new TraktUserReportPost();

            // reason = null, message = null
            Action act = () => userReasonPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // reason = Other, message = null
            userReasonPost.Reason = TraktReason.Other;
            act.ShouldThrow<TraktPostValidationException>();

            // reason = Other, message = empty
            userReasonPost.Message = string.Empty;
            act.ShouldThrow<TraktPostValidationException>();

            // reason = Other, message = valid
            userReasonPost.Message = "reason message";
            act.ShouldNotThrow();

            // reason = Span, message = null
            userReasonPost.Reason = TraktReason.Spam;
            userReasonPost.Message = null;
            act.ShouldNotThrow();
        }
    }
}
