#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Comments
{
    public sealed class CommentLikesGetRequestTests
    {
        private const string URIPath = "comments/123/likes";

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
        public void TestCommentLikesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var commentLikesGetRequest = new CommentLikesGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            commentLikesGetRequest.BuildUri();
            commentLikesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentLikesGetRequestHasValidOAuthRequirement()
        {
            var commentLikesGetRequest = new CommentLikesGetRequest { Id = default! };
            commentLikesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCommentLikesGetRequestIsGetRequest()
        {
            var commentLikesGetRequest = new CommentLikesGetRequest { Id = default! };
            commentLikesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCommentLikesGetRequestHasCorrectRequestObjectType()
        {
            var commentLikesGetRequest = new CommentLikesGetRequest { Id = default! };
            commentLikesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentLikesGetRequestValidate()
        {
            var commentLikesGetRequest = new CommentLikesGetRequest { Id = string.Empty };
            Action act = () => commentLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentLikesGetRequest = new CommentLikesGetRequest { Id = "  " };
            act = () => commentLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            commentLikesGetRequest = new CommentLikesGetRequest { Id = "id with spaces" };
            act = () => commentLikesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
