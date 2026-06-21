#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserPendingFollowingRequestsGetRequestTests
    {
        private const string URIPath = "users/requests/following";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestUserPendingFollowingRequestsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var userPendingFollowingRequestsGetRequest = new UserPendingFollowingRequestsGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            userPendingFollowingRequestsGetRequest.BuildUri();
            userPendingFollowingRequestsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPendingFollowingRequestsGetRequestHasValidOAuthRequirement()
        {
            var userPendingFollowingRequestsGetRequest = new UserPendingFollowingRequestsGetRequest();
            userPendingFollowingRequestsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Optional);
        }

        [Fact]
        public void TestUserPendingFollowingRequestsGetRequestIsGetRequest()
        {
            var userPendingFollowingRequestsGetRequest = new UserPendingFollowingRequestsGetRequest();
            userPendingFollowingRequestsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserPendingFollowingRequestsGetRequestHasCorrectRequestObjectType()
        {
            var userPendingFollowingRequestsGetRequest = new UserPendingFollowingRequestsGetRequest();
            userPendingFollowingRequestsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
