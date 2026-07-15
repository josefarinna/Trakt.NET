namespace TraktNET.Json.General
{
    public sealed class TraktReportPostTests
    {
        [Fact]
        public void TestTraktReportPostConstructor()
        {
            var reportPost = new TraktReportPost();

            reportPost.Reason.ShouldBeNull();
            reportPost.Message.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktReportPostFromJson()
        {
            TraktReportPost? reportPost = await TestUtility.DeserializeJsonAsync<TraktReportPost>("General\\reportpost.json");

            reportPost.ShouldNotBeNull();
            reportPost!.Reason.ShouldBe(TraktReason.Spam);
            reportPost!.Message.ShouldBe("This is spam.");
        }

        [Fact]
        public void TestTraktReportPostValidate()
        {
            var reportPost = new TraktReportPost();

            // reason = null, message = null
            Action act = () => reportPost.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            // reason = Unspecified, message = null
            reportPost.Reason = TraktReason.Unspecified;
            act.ShouldThrow<TraktPostValidationException>();

            // reason = Other, message = null
            reportPost.Reason = TraktReason.Other;
            act.ShouldThrow<TraktPostValidationException>();

            // reason = Other, message = empty
            reportPost.Message = string.Empty;
            act.ShouldThrow<TraktPostValidationException>();

            // reason = Other, message = valid
            reportPost.Message = "reason message";
            act.ShouldNotThrow();

            // reason = Spam, message = null
            reportPost.Reason = TraktReason.Spam;
            reportPost.Message = null;
            act.ShouldNotThrow();
        }
    }
}
