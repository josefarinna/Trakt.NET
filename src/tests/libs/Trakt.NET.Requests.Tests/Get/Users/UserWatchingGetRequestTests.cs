#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserWatchingGetRequestTests
    {
        private const string URIPath = "users/123/watching";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestUserWatchingGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var userWatchingGetRequest = new UserWatchingGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo
            };

            userWatchingGetRequest.BuildUri();
            userWatchingGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserWatchingGetRequestHasValidOAuthRequirement()
        {
            var userWatchingGetRequest = new UserWatchingGetRequest { Id = default! };
            userWatchingGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserWatchingGetRequestIsGetRequest()
        {
            var userWatchingGetRequest = new UserWatchingGetRequest { Id = default! };
            userWatchingGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserWatchingGetRequestHasCorrectRequestObjectType()
        {
            var userWatchingGetRequest = new UserWatchingGetRequest { Id = default! };
            userWatchingGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserWatchingGetRequestValidate()
        {
            var userWatchingGetRequest = new UserWatchingGetRequest { Id = string.Empty };
            Action act = () => userWatchingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchingGetRequest = new UserWatchingGetRequest { Id = "  " };
            act = () => userWatchingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchingGetRequest = new UserWatchingGetRequest { Id = "id with spaces" };
            act = () => userWatchingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
