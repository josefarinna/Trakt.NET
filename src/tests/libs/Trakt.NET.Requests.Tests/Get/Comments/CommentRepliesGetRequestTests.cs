#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Comments
{
    public sealed class CommentRepliesGetRequestTests
    {
        private const string URIPath = "comments/123/replies";

        [Theory]
        [InlineData(null, null, null, URIPath)]
        [InlineData(null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        public void TestCommentRepliesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var commentRepliesGetRequest = new CommentRepliesGetRequest
            {
                Id = 123,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            commentRepliesGetRequest.BuildUri();
            commentRepliesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentRepliesGetRequestHasValidOAuthRequirement()
        {
            var commentRepliesGetRequest = new CommentRepliesGetRequest { Id = default! };
            commentRepliesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Optional);
        }

        [Fact]
        public void TestCommentRepliesGetRequestIsGetRequest()
        {
            var commentRepliesGetRequest = new CommentRepliesGetRequest { Id = default! };
            commentRepliesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCommentRepliesGetRequestHasCorrectRequestObjectType()
        {
            var commentRepliesGetRequest = new CommentRepliesGetRequest { Id = default! };
            commentRepliesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentRepliesGetRequestValidate()
        {
            var commentRepliesGetRequest = new CommentRepliesGetRequest { Id = 0 };
            Action act = () => commentRepliesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
