#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Users
{
    public sealed class UserSavedFilterDeleteRequestTests
    {
        [Fact]
        public void TestUserSavedFilterDeleteRequestHasValidURIPath()
        {
            var request = new UserSavedFilterDeleteRequest { Id = 123U };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri("users/saved_filters/123", UriKind.Relative));
        }

        [Fact]
        public void TestUserSavedFilterDeleteRequestHasValidOAuthRequirement()
        {
            var request = new UserSavedFilterDeleteRequest { Id = 123U };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserSavedFilterDeleteRequestIsDeleteRequest()
        {
            var request = new UserSavedFilterDeleteRequest { Id = 123U };
            request.Method.ShouldBe(HttpMethod.Delete);
        }
    }
}
