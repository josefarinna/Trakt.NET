#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Comments
{
    public sealed class CommentSummaryGetRequestTests
    {
        private const string URIPath = "comments/123";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCommentSummaryGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var commentSummaryGetRequest = new CommentSummaryGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo
            };

            commentSummaryGetRequest.BuildUri();
            commentSummaryGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentSummaryGetRequestHasValidOAuthRequirement()
        {
            var commentSummaryGetRequest = new CommentSummaryGetRequest { Id = default! };
            commentSummaryGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCommentSummaryGetRequestIsGetRequest()
        {
            var commentSummaryGetRequest = new CommentSummaryGetRequest { Id = default! };
            commentSummaryGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCommentSummaryGetRequestHasCorrectRequestObjectType()
        {
            var commentSummaryGetRequest = new CommentSummaryGetRequest { Id = default! };
            commentSummaryGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentSummaryGetRequestValidate()
        {
            var commentSummaryGetRequest = new CommentSummaryGetRequest { Id = string.Empty };
            Action act = () => commentSummaryGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentSummaryGetRequest = new CommentSummaryGetRequest { Id = "  " };
            act = () => commentSummaryGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentSummaryGetRequest = new CommentSummaryGetRequest { Id = "id with spaces" };
            act = () => commentSummaryGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
