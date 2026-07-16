#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PutRequests.Users
{
    public sealed class UserPlexSettingsPutRequestTests
    {
        [Fact]
        public void TestUserPlexSettingsPutRequestHasValidURIPath()
        {
            var request = new UserPlexSettingsPutRequest
            {
                TraktPlexSettingsUpdate = new TraktPlexSettingsUpdate()
            };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri("users/settings/plex", UriKind.Relative));
        }

        [Fact]
        public void TestUserPlexSettingsPutRequestHasValidOAuthRequirement()
        {
            var request = new UserPlexSettingsPutRequest { TraktPlexSettingsUpdate = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPlexSettingsPutRequestIsPutRequest()
        {
            var request = new UserPlexSettingsPutRequest { TraktPlexSettingsUpdate = default! };
            request.Method.ShouldBe(HttpMethod.Put);
        }

        [Fact]
        public void TestUserPlexSettingsPutRequestHasCorrectRequestObjectType()
        {
            var request = new UserPlexSettingsPutRequest { TraktPlexSettingsUpdate = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserPlexSettingsPutRequestValidate()
        {
            var request = new UserPlexSettingsPutRequest { TraktPlexSettingsUpdate = default! };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
