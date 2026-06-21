#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserFollowUserPostRequestTests
    {
        private const string URIPath = "users/123/follow";

        [Fact]
        public void TestUserFollowUserPostRequestHasValidURIPath()
        {
            var userFollowUserPostRequest = new UserFollowUserPostRequest
            {
                Id = "123"
            };

            userFollowUserPostRequest.BuildUri();
            userFollowUserPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserFollowUserPostRequestHasValidOAuthRequirement()
        {
            var userFollowUserPostRequest = new UserFollowUserPostRequest { Id = default! };
            userFollowUserPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserFollowUserPostRequestIsPostRequest()
        {
            var userFollowUserPostRequest = new UserFollowUserPostRequest { Id = default! };
            userFollowUserPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserFollowUserPostRequestHasCorrectRequestObjectType()
        {
            var userFollowUserPostRequest = new UserFollowUserPostRequest { Id = default! };
            userFollowUserPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserFollowUserPostRequestValidate()
        {
            var userFollowUserPostRequest = new UserFollowUserPostRequest { Id = string.Empty };
            Action act = () => userFollowUserPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userFollowUserPostRequest = new UserFollowUserPostRequest { Id = "  " };
            act = () => userFollowUserPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userFollowUserPostRequest = new UserFollowUserPostRequest { Id = "id with spaces" };
            act = () => userFollowUserPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
