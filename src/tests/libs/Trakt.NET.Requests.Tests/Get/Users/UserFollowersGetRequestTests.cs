#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserFollowersGetRequestTests
    {
        private const string URIPath = "users/123/followers";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestUserFollowersGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var userFollowersGetRequest = new UserFollowersGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo
            };

            userFollowersGetRequest.BuildUri();
            userFollowersGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserFollowersGetRequestHasValidOAuthRequirement()
        {
            var userFollowersGetRequest = new UserFollowersGetRequest { Id = default! };
            userFollowersGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserFollowersGetRequestIsGetRequest()
        {
            var userFollowersGetRequest = new UserFollowersGetRequest { Id = default! };
            userFollowersGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserFollowersGetRequestHasCorrectRequestObjectType()
        {
            var userFollowersGetRequest = new UserFollowersGetRequest { Id = default! };
            userFollowersGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserFollowersGetRequestValidate()
        {
            var userFollowersGetRequest = new UserFollowersGetRequest { Id = string.Empty };
            Action act = () => userFollowersGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userFollowersGetRequest = new UserFollowersGetRequest { Id = "  " };
            act = () => userFollowersGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userFollowersGetRequest = new UserFollowersGetRequest { Id = "id with spaces" };
            act = () => userFollowersGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
