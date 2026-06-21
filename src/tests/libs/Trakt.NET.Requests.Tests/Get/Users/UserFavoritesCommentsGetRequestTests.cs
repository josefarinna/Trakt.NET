#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserFavoritesCommentsGetRequestTests
    {
        private const string URIPath = "users/123/favorites/comments";

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
        public void TestUserFavoritesCommentsGetRequestHasValidURIPath(TraktCommentSortOrder? sort, int? page, int? limit, string expectedURIPath)
        {
            var userFavoritesCommentsGetRequest = new UserFavoritesCommentsGetRequest
            {
                Id = "123",
                Sort = sort,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userFavoritesCommentsGetRequest.BuildUri();
            userFavoritesCommentsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserFavoritesCommentsGetRequestHasValidOAuthRequirement()
        {
            var userFavoritesCommentsGetRequest = new UserFavoritesCommentsGetRequest { Id = default! };
            userFavoritesCommentsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserFavoritesCommentsGetRequestIsGetRequest()
        {
            var userFavoritesCommentsGetRequest = new UserFavoritesCommentsGetRequest { Id = default! };
            userFavoritesCommentsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserFavoritesCommentsGetRequestHasCorrectRequestObjectType()
        {
            var userFavoritesCommentsGetRequest = new UserFavoritesCommentsGetRequest { Id = default! };
            userFavoritesCommentsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserFavoritesCommentsGetRequestValidate()
        {
            var userFavoritesCommentsGetRequest = new UserFavoritesCommentsGetRequest { Id = string.Empty };
            Action act = () => userFavoritesCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userFavoritesCommentsGetRequest = new UserFavoritesCommentsGetRequest { Id = "  " };
            act = () => userFavoritesCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userFavoritesCommentsGetRequest = new UserFavoritesCommentsGetRequest { Id = "id with spaces" };
            act = () => userFavoritesCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
