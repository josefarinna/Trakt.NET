#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserFollowRequestsGetRequestTests
    {
        private const string URIPath = "users/requests";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestUserFollowRequestsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var userFollowRequestsGetRequest = new UserFollowRequestsGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            userFollowRequestsGetRequest.BuildUri();
            userFollowRequestsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserFollowRequestsGetRequestHasValidOAuthRequirement()
        {
            var userFollowRequestsGetRequest = new UserFollowRequestsGetRequest();
            userFollowRequestsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserFollowRequestsGetRequestIsGetRequest()
        {
            var userFollowRequestsGetRequest = new UserFollowRequestsGetRequest();
            userFollowRequestsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserFollowRequestsGetRequestHasCorrectRequestObjectType()
        {
            var userFollowRequestsGetRequest = new UserFollowRequestsGetRequest();
            userFollowRequestsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
