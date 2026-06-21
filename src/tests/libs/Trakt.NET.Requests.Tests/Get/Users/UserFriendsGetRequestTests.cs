#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserFriendsGetRequestTests
    {
        private const string URIPath = "users/123/friends";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestUserFriendsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var userFriendsGetRequest = new UserFriendsGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo
            };

            userFriendsGetRequest.BuildUri();
            userFriendsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserFriendsGetRequestHasValidOAuthRequirement()
        {
            var userFriendsGetRequest = new UserFriendsGetRequest { Id = default! };
            userFriendsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserFriendsGetRequestIsGetRequest()
        {
            var userFriendsGetRequest = new UserFriendsGetRequest { Id = default! };
            userFriendsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserFriendsGetRequestHasCorrectRequestObjectType()
        {
            var userFriendsGetRequest = new UserFriendsGetRequest { Id = default! };
            userFriendsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserFriendsGetRequestValidate()
        {
            var userFriendsGetRequest = new UserFriendsGetRequest { Id = string.Empty };
            Action act = () => userFriendsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userFriendsGetRequest = new UserFriendsGetRequest { Id = "  " };
            act = () => userFriendsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userFriendsGetRequest = new UserFriendsGetRequest { Id = "id with spaces" };
            act = () => userFriendsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
