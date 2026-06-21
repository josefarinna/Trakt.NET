#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserSettingsGetRequestTests
    {
        private const string URIPath = "users/settings";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(10, null, $"{URIPath}?page=10")]
        [InlineData(null, 20, $"{URIPath}?limit=20")]
        [InlineData(10, 20, $"{URIPath}?page=10&limit=20")]
        public void TestUserSettingsGetRequestHasValidURIPath(int? page, int? limit, string expectedURIPath)
        {
            var userSettingsGetRequest = new UserSettingsGetRequest
            {
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            userSettingsGetRequest.BuildUri();
            userSettingsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSettingsGetRequestHasValidOAuthRequirement()
        {
            var userSettingsGetRequest = new UserSettingsGetRequest();
            userSettingsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserSettingsGetRequestIsGetRequest()
        {
            var userSettingsGetRequest = new UserSettingsGetRequest();
            userSettingsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserSettingsGetRequestHasCorrectRequestObjectType()
        {
            var userSettingsGetRequest = new UserSettingsGetRequest();
            userSettingsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
