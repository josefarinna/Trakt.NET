#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserWatchedShowsGetRequestTests
    {
        private const string URIPath = "users/123/watched/shows";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestUserWatchedShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var userWatchedShowsGetRequest = new UserWatchedShowsGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo
            };

            userWatchedShowsGetRequest.BuildUri();
            userWatchedShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserWatchedShowsGetRequestHasValidOAuthRequirement()
        {
            var userWatchedShowsGetRequest = new UserWatchedShowsGetRequest { Id = default! };
            userWatchedShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserWatchedShowsGetRequestIsGetRequest()
        {
            var userWatchedShowsGetRequest = new UserWatchedShowsGetRequest { Id = default! };
            userWatchedShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserWatchedShowsGetRequestHasCorrectRequestObjectType()
        {
            var userWatchedShowsGetRequest = new UserWatchedShowsGetRequest { Id = default! };
            userWatchedShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserWatchedShowsGetRequestValidate()
        {
            var userWatchedShowsGetRequest = new UserWatchedShowsGetRequest { Id = string.Empty };
            Action act = () => userWatchedShowsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchedShowsGetRequest = new UserWatchedShowsGetRequest { Id = "  " };
            act = () => userWatchedShowsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userWatchedShowsGetRequest = new UserWatchedShowsGetRequest { Id = "id with spaces" };
            act = () => userWatchedShowsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
