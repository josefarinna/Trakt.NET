#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserSyncsGetRequestTests
    {
        private const string URIPath = "users/syncs";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(10, null, $"{URIPath}?page=10")]
        [InlineData(null, 20, $"{URIPath}?limit=20")]
        [InlineData(10, 20, $"{URIPath}?page=10&limit=20")]
        public void TestUserSyncsGetRequestHasValidURIPath(int? page, int? limit, string expectedURIPath)
        {
            var request = new UserSyncsGetRequest
            {
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSyncsGetRequestHasValidOAuthRequirement()
        {
            var request = new UserSyncsGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserSyncsGetRequestIsGetRequest()
        {
            var request = new UserSyncsGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserSyncsGetRequestHasCorrectRequestObjectType()
        {
            var request = new UserSyncsGetRequest();
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
