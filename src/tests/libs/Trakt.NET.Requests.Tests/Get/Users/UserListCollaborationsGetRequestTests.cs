#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserListCollaborationsGetRequestTests
    {
        private const string URIPath = "users/123/lists/collaborations";

        [Fact]
        public void TestUserListCollaborationsGetRequestHasValidURIPath()
        {
            var userListCollaborationsGetRequest = new UserListCollaborationsGetRequest
            {
                Id = "123"
            };

            userListCollaborationsGetRequest.BuildUri();
            userListCollaborationsGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserListCollaborationsGetRequestHasValidOAuthRequirement()
        {
            var userListCollaborationsGetRequest = new UserListCollaborationsGetRequest { Id = default! };
            userListCollaborationsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserListCollaborationsGetRequestIsGetRequest()
        {
            var userListCollaborationsGetRequest = new UserListCollaborationsGetRequest { Id = default! };
            userListCollaborationsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserListCollaborationsGetRequestHasCorrectRequestObjectType()
        {
            var userListCollaborationsGetRequest = new UserListCollaborationsGetRequest { Id = default! };
            userListCollaborationsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserListCollaborationsGetRequestValidate()
        {
            var userListCollaborationsGetRequest = new UserListCollaborationsGetRequest { Id = string.Empty };
            Action act = () => userListCollaborationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListCollaborationsGetRequest = new UserListCollaborationsGetRequest { Id = "  " };
            act = () => userListCollaborationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userListCollaborationsGetRequest = new UserListCollaborationsGetRequest { Id = "id with spaces" };
            act = () => userListCollaborationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
