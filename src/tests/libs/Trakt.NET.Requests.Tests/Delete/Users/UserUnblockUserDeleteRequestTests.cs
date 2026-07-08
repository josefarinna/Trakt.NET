#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Users
{
    public sealed class UserUnblockUserDeleteRequestTests
    {
        private const string URIPath = "users/123/block";

        [Fact]
        public void TestUserUnblockUserDeleteRequestHasValidURIPath()
        {
            var userUnblockUserDeleteRequest = new UserUnblockUserDeleteRequest
            {
                Id = "123"
            };

            userUnblockUserDeleteRequest.BuildUri();
            userUnblockUserDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserUnblockUserDeleteRequestHasValidOAuthRequirement()
        {
            var userUnblockUserDeleteRequest = new UserUnblockUserDeleteRequest { Id = default! };
            userUnblockUserDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserUnblockUserDeleteRequestIsDeleteRequest()
        {
            var userUnblockUserDeleteRequest = new UserUnblockUserDeleteRequest { Id = default! };
            userUnblockUserDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestUserUnblockUserDeleteRequestHasCorrectRequestObjectType()
        {
            var userUnblockUserDeleteRequest = new UserUnblockUserDeleteRequest { Id = default! };
            userUnblockUserDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserUnblockUserDeleteRequestValidate()
        {
            var userUnblockUserDeleteRequest = new UserUnblockUserDeleteRequest { Id = string.Empty };
            Action act = () => userUnblockUserDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userUnblockUserDeleteRequest = new UserUnblockUserDeleteRequest { Id = "  " };
            act = () => userUnblockUserDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userUnblockUserDeleteRequest = new UserUnblockUserDeleteRequest { Id = "id with spaces" };
            act = () => userUnblockUserDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
