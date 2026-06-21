#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserWatchlistCommentsGetRequestTests
    {
        private const string URIPath = "users/123/watchlist/comments";

        [Theory]
        [InlineData(null, null, null, URIPath)]
        [InlineData(null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, URIPath)]
        [InlineData(TraktCommentSortOrder.Unspecified, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, null, null, $"{URIPath}/newest")]
        [InlineData(TraktCommentSortOrder.Newest, 10, null, $"{URIPath}/newest?page=10")]
        [InlineData(TraktCommentSortOrder.Newest, null, 20, $"{URIPath}/newest?limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, 10, 20, $"{URIPath}/newest?page=10&limit=20")]
        public void TestUserWatchlistCommentsGetRequestHasValidURIPath(TraktCommentSortOrder? sort, int? page, int? limit, string expectedURIPath)
        {
            var userWatchlistCommentsGetRequest = new UserWatchlistCommentsGetRequest
            {
                Id = "123",
                Sort = sort,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userWatchlistCommentsGetRequest.BuildUri();
            userWatchlistCommentsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserWatchlistCommentsGetRequestHasValidOAuthRequirement()
        {
            var userWatchlistCommentsGetRequest = new UserWatchlistCommentsGetRequest { Id = default! };
            userWatchlistCommentsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserWatchlistCommentsGetRequestIsGetRequest()
        {
            var userWatchlistCommentsGetRequest = new UserWatchlistCommentsGetRequest { Id = default! };
            userWatchlistCommentsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserWatchlistCommentsGetRequestHasCorrectRequestObjectType()
        {
            var userWatchlistCommentsGetRequest = new UserWatchlistCommentsGetRequest { Id = default! };
            userWatchlistCommentsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserWatchlistCommentsGetRequestValidate()
        {
            var userWatchlistCommentsGetRequest = new UserWatchlistCommentsGetRequest { Id = string.Empty };
            Action act = () => userWatchlistCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchlistCommentsGetRequest = new UserWatchlistCommentsGetRequest { Id = "  " };
            act = () => userWatchlistCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchlistCommentsGetRequest = new UserWatchlistCommentsGetRequest { Id = "id with spaces" };
            act = () => userWatchlistCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
