#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserPlexSettingsGetRequestTests
    {
        [Fact]
        public void TestUserPlexSettingsGetRequestHasValidURIPath()
        {
            var request = new UserPlexSettingsGetRequest();
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri("users/settings/plex", UriKind.Relative));
        }

        [Fact]
        public void TestUserPlexSettingsGetRequestHasValidOAuthRequirement()
        {
            var request = new UserPlexSettingsGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPlexSettingsGetRequestIsGetRequest()
        {
            var request = new UserPlexSettingsGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserPlexSettingsGetRequestHasCorrectRequestObjectType()
        {
            var request = new UserPlexSettingsGetRequest();
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
