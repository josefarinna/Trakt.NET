#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Users
{
    public sealed class UserListUnlikeDeleteRequestTests
    {
        private const string URIPath = "users/123/lists/123/like";

        [Fact]
        public void TestUserListUnlikeDeleteRequestHasValidURIPath()
        {
            var userListUnlikeDeleteRequest = new UserListUnlikeDeleteRequest
            {
                Id = "123",
                ListId = "123"
            };

            userListUnlikeDeleteRequest.BuildUri();
            userListUnlikeDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserListUnlikeDeleteRequestHasValidOAuthRequirement()
        {
            var userListUnlikeDeleteRequest = new UserListUnlikeDeleteRequest { Id = default!, ListId = default! };
            userListUnlikeDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserListUnlikeDeleteRequestIsDeleteRequest()
        {
            var userListUnlikeDeleteRequest = new UserListUnlikeDeleteRequest { Id = default!, ListId = default! };
            userListUnlikeDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestUserListUnlikeDeleteRequestHasCorrectRequestObjectType()
        {
            var userListUnlikeDeleteRequest = new UserListUnlikeDeleteRequest { Id = default!, ListId = default! };
            userListUnlikeDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserListUnlikeDeleteRequestValidate()
        {
            var userListUnlikeDeleteRequest = new UserListUnlikeDeleteRequest { Id = string.Empty, ListId = default! };
            Action act = () => userListUnlikeDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListUnlikeDeleteRequest = new UserListUnlikeDeleteRequest { Id = "  ", ListId = default! };
            act = () => userListUnlikeDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListUnlikeDeleteRequest = new UserListUnlikeDeleteRequest { Id = "id with spaces", ListId = default! };
            act = () => userListUnlikeDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListUnlikeDeleteRequest = new UserListUnlikeDeleteRequest { Id = "id", ListId = string.Empty };
            act = () => userListUnlikeDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListUnlikeDeleteRequest = new UserListUnlikeDeleteRequest { Id = "id", ListId = "  " };
            act = () => userListUnlikeDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListUnlikeDeleteRequest = new UserListUnlikeDeleteRequest { Id = "id", ListId = "id with spaces" };
            act = () => userListUnlikeDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
