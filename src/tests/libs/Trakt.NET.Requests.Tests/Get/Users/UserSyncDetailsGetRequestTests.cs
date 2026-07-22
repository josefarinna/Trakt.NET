#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserSyncDetailsGetRequestTests
    {
        private const string URIPath = "users/syncs/12345";

        [Fact]
        public void TestUserSyncDetailsGetRequestHasValidURIPath()
        {
            var request = new UserSyncDetailsGetRequest { Id = 12345UL };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSyncDetailsGetRequestHasValidOAuthRequirement()
        {
            var request = new UserSyncDetailsGetRequest { Id = 12345UL };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserSyncDetailsGetRequestIsGetRequest()
        {
            var request = new UserSyncDetailsGetRequest { Id = 12345UL };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserSyncDetailsGetRequestHasCorrectRequestObjectType()
        {
            var request = new UserSyncDetailsGetRequest { Id = 12345UL };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserSyncDetailsGetRequestValidate()
        {
            var request = new UserSyncDetailsGetRequest { Id = 0UL };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
