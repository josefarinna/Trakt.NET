#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserSyncsByTypeGetRequestTests
    {
        private const string URIPath = "users/syncs/plex";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(10, null, $"{URIPath}?page=10")]
        [InlineData(null, 20, $"{URIPath}?limit=20")]
        [InlineData(10, 20, $"{URIPath}?page=10&limit=20")]
        public void TestUserSyncsByTypeGetRequestHasValidURIPath(int? page, int? limit, string expectedURIPath)
        {
            var request = new UserSyncsByTypeGetRequest
            {
                TypePath = TraktUserSyncType.Plex.AsPathParameter(),
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSyncsByTypeGetRequestHasValidOAuthRequirement()
        {
            var request = new UserSyncsByTypeGetRequest { TypePath = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserSyncsByTypeGetRequestIsGetRequest()
        {
            var request = new UserSyncsByTypeGetRequest { TypePath = default! };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserSyncsByTypeGetRequestHasCorrectRequestObjectType()
        {
            var request = new UserSyncsByTypeGetRequest { TypePath = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
