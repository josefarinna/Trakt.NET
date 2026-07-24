#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Comments
{
    public sealed class CommentReactionsGetRequestTests
    {
        private const string URIPath = "comments/123/reactions";

        [Theory]
        [InlineData(null, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, 1, null, $"{URIPath}?page=1")]
        [InlineData(null, null, 10, $"{URIPath}?limit=10")]
        [InlineData(TraktExtendedInfo.Full, 1, 10, $"{URIPath}?extended=full&page=1&limit=10")]
        public void TestCommentReactionsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var request = new CommentReactionsGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentReactionsGetRequestHasValidOAuthRequirement()
        {
            var request = new CommentReactionsGetRequest { Id = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCommentReactionsGetRequestIsGetRequest()
        {
            var request = new CommentReactionsGetRequest { Id = default! };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCommentReactionsGetRequestHasCorrectRequestObjectType()
        {
            var request = new CommentReactionsGetRequest { Id = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentReactionsGetRequestValidate()
        {
            var request = new CommentReactionsGetRequest { Id = string.Empty };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new CommentReactionsGetRequest { Id = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new CommentReactionsGetRequest { Id = "id with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
