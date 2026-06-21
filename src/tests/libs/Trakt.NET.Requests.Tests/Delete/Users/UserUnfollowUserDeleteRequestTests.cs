#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Users
{
    public sealed class UserUnfollowUserDeleteRequestTests
    {
        private const string URIPath = "users/123/follow";

        [Fact]
        public void TestUserUnfollowUserDeleteRequestHasValidURIPath()
        {
            var userUnfollowUserDeleteRequest = new UserUnfollowUserDeleteRequest
            {
                Id = "123"
            };

            userUnfollowUserDeleteRequest.BuildUri();
            userUnfollowUserDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserUnfollowUserDeleteRequestHasValidOAuthRequirement()
        {
            var userUnfollowUserDeleteRequest = new UserUnfollowUserDeleteRequest { Id = default! };
            userUnfollowUserDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserUnfollowUserDeleteRequestIsDeleteRequest()
        {
            var userUnfollowUserDeleteRequest = new UserUnfollowUserDeleteRequest { Id = default! };
            userUnfollowUserDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestUserUnfollowUserDeleteRequestHasCorrectRequestObjectType()
        {
            var userUnfollowUserDeleteRequest = new UserUnfollowUserDeleteRequest { Id = default! };
            userUnfollowUserDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserUnfollowUserDeleteRequestValidate()
        {
            var userUnfollowUserDeleteRequest = new UserUnfollowUserDeleteRequest { Id = string.Empty };
            Action act = () => userUnfollowUserDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userUnfollowUserDeleteRequest = new UserUnfollowUserDeleteRequest { Id = "  " };
            act = () => userUnfollowUserDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userUnfollowUserDeleteRequest = new UserUnfollowUserDeleteRequest { Id = "id with spaces" };
            act = () => userUnfollowUserDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
