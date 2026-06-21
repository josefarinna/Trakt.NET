#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Users
{
    public sealed class UserDenyFollowerDeleteRequestTests
    {
        private const string URIPath = "users/requests/123";

        [Fact]
        public void TestUserDenyFollowerDeleteRequestHasValidURIPath()
        {
            var userDenyFollowerDeleteRequest = new UserDenyFollowerDeleteRequest
            {
                Id = "123"
            };

            userDenyFollowerDeleteRequest.BuildUri();
            userDenyFollowerDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserDenyFollowerDeleteRequestHasValidOAuthRequirement()
        {
            var userDenyFollowerDeleteRequest = new UserDenyFollowerDeleteRequest { Id = default! };
            userDenyFollowerDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserDenyFollowerDeleteRequestIsDeleteRequest()
        {
            var userDenyFollowerDeleteRequest = new UserDenyFollowerDeleteRequest { Id = default! };
            userDenyFollowerDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestUserDenyFollowerDeleteRequestHasCorrectRequestObjectType()
        {
            var userDenyFollowerDeleteRequest = new UserDenyFollowerDeleteRequest { Id = default! };
            userDenyFollowerDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserDenyFollowerDeleteRequestValidate()
        {
            var userDenyFollowerDeleteRequest = new UserDenyFollowerDeleteRequest { Id = string.Empty };
            Action act = () => userDenyFollowerDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userDenyFollowerDeleteRequest = new UserDenyFollowerDeleteRequest { Id = "  " };
            act = () => userDenyFollowerDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userDenyFollowerDeleteRequest = new UserDenyFollowerDeleteRequest { Id = "id with spaces" };
            act = () => userDenyFollowerDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
