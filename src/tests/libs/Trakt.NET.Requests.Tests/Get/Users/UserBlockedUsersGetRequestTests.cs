#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserBlockedUsersGetRequestTests
    {
        private const string URIPath = "users/blocked";

        [Fact]
        public void TestUserBlockedUsersGetRequestHasValidURIPath()
        {
            var request = new UserBlockedUsersGetRequest();
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserBlockedUsersGetRequestHasValidOAuthRequirement()
        {
            var request = new UserBlockedUsersGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserBlockedUsersGetRequestIsGetRequest()
        {
            var request = new UserBlockedUsersGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserBlockedUsersGetRequestHasCorrectRequestObjectType()
        {
            var request = new UserBlockedUsersGetRequest();
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
