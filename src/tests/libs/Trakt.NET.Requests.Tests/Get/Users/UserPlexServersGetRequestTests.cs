#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserPlexServersGetRequestTests
    {
        [Fact]
        public void TestUserPlexServersGetRequestHasValidURIPath()
        {
            var request = new UserPlexServersGetRequest();
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri("users/settings/plex/servers", UriKind.Relative));
        }

        [Fact]
        public void TestUserPlexServersGetRequestHasValidOAuthRequirement()
        {
            var request = new UserPlexServersGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPlexServersGetRequestIsGetRequest()
        {
            var request = new UserPlexServersGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserPlexServersGetRequestHasCorrectRequestObjectType()
        {
            var request = new UserPlexServersGetRequest();
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
