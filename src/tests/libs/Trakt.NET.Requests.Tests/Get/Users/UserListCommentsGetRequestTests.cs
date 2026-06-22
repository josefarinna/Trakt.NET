#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserListCommentsGetRequestTests
    {
        private const string URIPath = "users/123/lists/123/comments";

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
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, null, null, null, $"{URIPath}/newest")]
        [InlineData(TraktCommentSortOrder.Newest, null, 10, null, $"{URIPath}/newest?page=10")]
        [InlineData(TraktCommentSortOrder.Newest, null, null, 20, $"{URIPath}/newest?limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, null, 10, 20, $"{URIPath}/newest?page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.None, null, null, $"{URIPath}/newest")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.None, 10, null, $"{URIPath}/newest?page=10")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.None, null, 20, $"{URIPath}/newest?limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.None, 10, 20, $"{URIPath}/newest?page=10&limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.Full, null, null, $"{URIPath}/newest?extended=full")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.Full, 10, null, $"{URIPath}/newest?extended=full&page=10")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.Full, null, 20, $"{URIPath}/newest?extended=full&limit=20")]
        [InlineData(TraktCommentSortOrder.Newest, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/newest?extended=full&page=10&limit=20")]
        public void TestUserListCommentsGetRequestHasValidURIPath(TraktCommentSortOrder? sort, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var userListCommentsGetRequest = new UserListCommentsGetRequest
            {
                Id = "123",
                ListId = "123",
                Sort = sort,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userListCommentsGetRequest.BuildUri();
            userListCommentsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserListCommentsGetRequestHasValidOAuthRequirement()
        {
            var userListCommentsGetRequest = new UserListCommentsGetRequest { Id = default!, ListId = default! };
            userListCommentsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Optional);
        }

        [Fact]
        public void TestUserListCommentsGetRequestIsGetRequest()
        {
            var userListCommentsGetRequest = new UserListCommentsGetRequest { Id = default!, ListId = default! };
            userListCommentsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserListCommentsGetRequestHasCorrectRequestObjectType()
        {
            var userListCommentsGetRequest = new UserListCommentsGetRequest { Id = default!, ListId = default! };
            userListCommentsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserListCommentsGetRequestValidate()
        {
            var userListCommentsGetRequest = new UserListCommentsGetRequest { Id = string.Empty, ListId = default! };
            Action act = () => userListCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListCommentsGetRequest = new UserListCommentsGetRequest { Id = "  ", ListId = default! };
            act = () => userListCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListCommentsGetRequest = new UserListCommentsGetRequest { Id = "id with spaces", ListId = default! };
            act = () => userListCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListCommentsGetRequest = new UserListCommentsGetRequest { Id = "id", ListId = string.Empty };
            act = () => userListCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListCommentsGetRequest = new UserListCommentsGetRequest { Id = "id", ListId = "  " };
            act = () => userListCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListCommentsGetRequest = new UserListCommentsGetRequest { Id = "id", ListId = "id with spaces" };
            act = () => userListCommentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
