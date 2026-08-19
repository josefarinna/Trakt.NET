#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserCommentReactionsGetRequestTests
    {
        private const string URIPath = "users/reactions/comments";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(10, null, $"{URIPath}?page=10")]
        [InlineData(null, 20, $"{URIPath}?limit=20")]
        [InlineData(10, 20, $"{URIPath}?page=10&limit=20")]
        public void TestUserCommentReactionsGetRequestHasValidURIPath(int? page, int? limit, string expectedURIPath)
        {
            var request = new UserCommentReactionsGetRequest
            {
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserCommentReactionsGetRequestHasValidOAuthRequirement()
        {
            var request = new UserCommentReactionsGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserCommentReactionsGetRequestIsGetRequest()
        {
            var request = new UserCommentReactionsGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }
    }
}
