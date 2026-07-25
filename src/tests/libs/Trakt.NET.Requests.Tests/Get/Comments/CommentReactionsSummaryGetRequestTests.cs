#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Comments
{
    public sealed class CommentReactionsSummaryGetRequestTests
    {
        private const string URIPath = "comments/123/reactions/summary";

        [Fact]
        public void TestCommentReactionsSummaryGetRequestHasValidURIPath()
        {
            var request = new CommentReactionsSummaryGetRequest
            {
                Id = 123
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentReactionsSummaryGetRequestHasValidOAuthRequirement()
        {
            var request = new CommentReactionsSummaryGetRequest { Id = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCommentReactionsSummaryGetRequestIsGetRequest()
        {
            var request = new CommentReactionsSummaryGetRequest { Id = default! };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCommentReactionsSummaryGetRequestHasCorrectRequestObjectType()
        {
            var request = new CommentReactionsSummaryGetRequest { Id = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentReactionsSummaryGetRequestValidate()
        {
            var request = new CommentReactionsSummaryGetRequest { Id = 0 };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
