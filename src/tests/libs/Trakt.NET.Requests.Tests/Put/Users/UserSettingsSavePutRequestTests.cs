#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PutRequests.Users
{
    public sealed class UserSettingsSavePutRequestTests
    {
        private const string URIPath = "users/settings";

        [Fact]
        public async Task TestUserSettingsSavePutRequestHasValidURIPath()
        {
            var request = new UserSettingsSavePutRequest
            {
                TraktUserSettingsPost = new TraktUserSettingsPost()
            };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public async Task TestUserSettingsSavePutRequestHasValidOAuthRequirement()
        {
            var request = new UserSettingsSavePutRequest { TraktUserSettingsPost = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public async Task TestUserSettingsSavePutRequestIsPutRequest()
        {
            var request = new UserSettingsSavePutRequest { TraktUserSettingsPost = default! };
            request.Method.ShouldBe(HttpMethod.Put);
        }

        [Fact]
        public void TestUserSettingsSavePutRequestValidate()
        {
            var request = new UserSettingsSavePutRequest { TraktUserSettingsPost = default! };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
