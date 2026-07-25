#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserSyncPausedGetRequestTests
    {
        private const string URIPath = "users/syncs/12345/paused";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(0, null, URIPath)]
        [InlineData(10, null, $"{URIPath}?page=10")]
        [InlineData(null, 0, URIPath)]
        [InlineData(null, 20, $"{URIPath}?limit=20")]
        [InlineData(10, 20, $"{URIPath}?page=10&limit=20")]
        public void TestUserSyncPausedGetRequestHasValidURIPath(int? page, int? limit, string expectedURIPath)
        {
            var request = new UserSyncPausedGetRequest
            {
                Id = 12345UL,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSyncPausedGetRequestHasValidOAuthRequirement()
        {
            var request = new UserSyncPausedGetRequest { Id = 12345UL };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserSyncPausedGetRequestIsGetRequest()
        {
            var request = new UserSyncPausedGetRequest { Id = 12345UL };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserSyncPausedGetRequestHasCorrectRequestObjectType()
        {
            var request = new UserSyncPausedGetRequest { Id = 12345UL };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserSyncPausedGetRequestValidate()
        {
            var request = new UserSyncPausedGetRequest { Id = 0UL };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
