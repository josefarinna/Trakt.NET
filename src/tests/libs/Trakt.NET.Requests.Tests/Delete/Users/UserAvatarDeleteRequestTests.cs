#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Users
{
    public sealed class UserAvatarDeleteRequestTests
    {
        private const string URIPath = "users/avatar";

        [Fact]
        public void TestUserAvatarDeleteRequestHasValidURIPath()
        {
            var request = new UserAvatarDeleteRequest();
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserAvatarDeleteRequestHasValidOAuthRequirement()
        {
            var request = new UserAvatarDeleteRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserAvatarDeleteRequestIsDeleteRequest()
        {
            var request = new UserAvatarDeleteRequest();
            request.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestUserAvatarDeleteRequestHasCorrectRequestObjectType()
        {
            var request = new UserAvatarDeleteRequest();
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
