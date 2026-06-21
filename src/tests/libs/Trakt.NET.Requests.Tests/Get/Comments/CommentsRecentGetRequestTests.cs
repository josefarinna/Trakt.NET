#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Comments
{
    public sealed class CommentsRecentGetRequestTests
    {
        private const string URIPath = "comments/recent";

        [Theory]
        [InlineData(null, null, null, null, URIPath)]
        [InlineData(null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktCommentObjectType.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktCommentObjectType.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktCommentObjectType.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktCommentObjectType.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktCommentObjectType.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktCommentObjectType.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktCommentObjectType.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktCommentObjectType.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktCommentObjectType.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktCommentObjectType.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktCommentObjectType.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktCommentObjectType.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktCommentObjectType.Movie, null, null, null, $"{URIPath}/movies")]
        [InlineData(TraktCommentObjectType.Movie, null, 10, null, $"{URIPath}/movies?page=10")]
        [InlineData(TraktCommentObjectType.Movie, null, null, 20, $"{URIPath}/movies?limit=20")]
        [InlineData(TraktCommentObjectType.Movie, null, 10, 20, $"{URIPath}/movies?page=10&limit=20")]
        [InlineData(TraktCommentObjectType.Movie, TraktExtendedInfo.None, null, null, $"{URIPath}/movies")]
        [InlineData(TraktCommentObjectType.Movie, TraktExtendedInfo.None, 10, null, $"{URIPath}/movies?page=10")]
        [InlineData(TraktCommentObjectType.Movie, TraktExtendedInfo.None, null, 20, $"{URIPath}/movies?limit=20")]
        [InlineData(TraktCommentObjectType.Movie, TraktExtendedInfo.None, 10, 20, $"{URIPath}/movies?page=10&limit=20")]
        [InlineData(TraktCommentObjectType.Movie, TraktExtendedInfo.Full, null, null, $"{URIPath}/movies?extended=full")]
        [InlineData(TraktCommentObjectType.Movie, TraktExtendedInfo.Full, 10, null, $"{URIPath}/movies?extended=full&page=10")]
        [InlineData(TraktCommentObjectType.Movie, TraktExtendedInfo.Full, null, 20, $"{URIPath}/movies?extended=full&limit=20")]
        [InlineData(TraktCommentObjectType.Movie, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/movies?extended=full&page=10&limit=20")]
        public void TestCommentsRecentGetRequestHasValidURIPath(TraktCommentObjectType? type, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var commentsRecentGetRequest = new CommentsRecentGetRequest
            {
                Type = type,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            commentsRecentGetRequest.BuildUri();
            commentsRecentGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentsRecentGetRequestHasValidOAuthRequirement()
        {
            var commentsRecentGetRequest = new CommentsRecentGetRequest();
            commentsRecentGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCommentsRecentGetRequestIsGetRequest()
        {
            var commentsRecentGetRequest = new CommentsRecentGetRequest();
            commentsRecentGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCommentsRecentGetRequestHasCorrectRequestObjectType()
        {
            var commentsRecentGetRequest = new CommentsRecentGetRequest();
            commentsRecentGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }
    }
}
