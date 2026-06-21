#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserFollowingGetRequestTests
    {
        private const string URIPath = "users/123/following";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestUserFollowingGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var userFollowingGetRequest = new UserFollowingGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo
            };

            userFollowingGetRequest.BuildUri();
            userFollowingGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserFollowingGetRequestHasValidOAuthRequirement()
        {
            var userFollowingGetRequest = new UserFollowingGetRequest { Id = default! };
            userFollowingGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserFollowingGetRequestIsGetRequest()
        {
            var userFollowingGetRequest = new UserFollowingGetRequest { Id = default! };
            userFollowingGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserFollowingGetRequestHasCorrectRequestObjectType()
        {
            var userFollowingGetRequest = new UserFollowingGetRequest { Id = default! };
            userFollowingGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserFollowingGetRequestValidate()
        {
            var userFollowingGetRequest = new UserFollowingGetRequest { Id = string.Empty };
            Action act = () => userFollowingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userFollowingGetRequest = new UserFollowingGetRequest { Id = "  " };
            act = () => userFollowingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userFollowingGetRequest = new UserFollowingGetRequest { Id = "id with spaces" };
            act = () => userFollowingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
