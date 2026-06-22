#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserListLikePostRequestTests
    {
        private const string URIPath = "users/123/lists/123/like";

        [Fact]
        public void TestUserListLikePostRequestHasValidURIPath()
        {
            var userListLikePostRequest = new UserListLikePostRequest
            {
                Id = "123",
                ListId = "123"
            };

            userListLikePostRequest.BuildUri();
            userListLikePostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserListLikePostRequestHasValidOAuthRequirement()
        {
            var userListLikePostRequest = new UserListLikePostRequest { Id = default!, ListId = default! };
            userListLikePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserListLikePostRequestIsPostRequest()
        {
            var userListLikePostRequest = new UserListLikePostRequest { Id = default!, ListId = default! };
            userListLikePostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserListLikePostRequestHasCorrectRequestObjectType()
        {
            var userListLikePostRequest = new UserListLikePostRequest { Id = default!, ListId = default! };
            userListLikePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserListLikePostRequestValidate()
        {
            var userListLikePostRequest = new UserListLikePostRequest { Id = string.Empty, ListId = default! };
            Action act = () => userListLikePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListLikePostRequest = new UserListLikePostRequest { Id = "  ", ListId = default! };
            act = () => userListLikePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListLikePostRequest = new UserListLikePostRequest { Id = "id with spaces", ListId = default! };
            act = () => userListLikePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListLikePostRequest = new UserListLikePostRequest { Id = "id", ListId = string.Empty };
            act = () => userListLikePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListLikePostRequest = new UserListLikePostRequest { Id = "id", ListId = "  " };
            act = () => userListLikePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListLikePostRequest = new UserListLikePostRequest { Id = "id", ListId = "id with spaces" };
            act = () => userListLikePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
