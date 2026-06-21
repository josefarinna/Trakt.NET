#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserProfileGetRequestTests
    {
        private const string URIPath = "users/123";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestUserProfileGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var userProfileGetRequest = new UserProfileGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo
            };

            userProfileGetRequest.BuildUri();
            userProfileGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserProfileGetRequestHasValidOAuthRequirement()
        {
            var userProfileGetRequest = new UserProfileGetRequest { Id = default! };
            userProfileGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserProfileGetRequestIsGetRequest()
        {
            var userProfileGetRequest = new UserProfileGetRequest { Id = default! };
            userProfileGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserProfileGetRequestHasCorrectRequestObjectType()
        {
            var userProfileGetRequest = new UserProfileGetRequest { Id = default! };
            userProfileGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserProfileGetRequestValidate()
        {
            var userProfileGetRequest = new UserProfileGetRequest { Id = string.Empty };
            Action act = () => userProfileGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userProfileGetRequest = new UserProfileGetRequest { Id = "  " };
            act = () => userProfileGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userProfileGetRequest = new UserProfileGetRequest { Id = "id with spaces" };
            act = () => userProfileGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
