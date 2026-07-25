#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Comments
{
    public sealed class CommentItemGetRequestTests
    {
        private const string URIPath = "comments/123/item";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCommentItemGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var commentItemGetRequest = new CommentItemGetRequest
            {
                Id = 123,
                ExtendedInfo = extendedInfo
            };

            commentItemGetRequest.BuildUri();
            commentItemGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCommentItemGetRequestHasValidOAuthRequirement()
        {
            var commentItemGetRequest = new CommentItemGetRequest { Id = default! };
            commentItemGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCommentItemGetRequestIsGetRequest()
        {
            var commentItemGetRequest = new CommentItemGetRequest { Id = default! };
            commentItemGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCommentItemGetRequestHasCorrectRequestObjectType()
        {
            var commentItemGetRequest = new CommentItemGetRequest { Id = default! };
            commentItemGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Comment);
        }

        [Fact]
        public void TestCommentItemGetRequestValidate()
        {
            var commentItemGetRequest = new CommentItemGetRequest { Id = 0 };
            Action act = () => commentItemGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
