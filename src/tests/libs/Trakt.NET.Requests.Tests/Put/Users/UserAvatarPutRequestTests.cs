#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PutRequests.Users
{
    public sealed class UserAvatarPutRequestTests
    {
        private const string URIPath = "users/avatar";

        [Fact]
        public async Task TestUserAvatarPutRequestHasValidURIPath()
        {
            var request = new UserAvatarPutRequest
            {
                TraktUserAvatarPost = new TraktUserAvatarPost { User = new TraktUserAvatarPostUser { Avatar = "base64" } }
            };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public async Task TestUserAvatarPutRequestHasValidOAuthRequirement()
        {
            var request = new UserAvatarPutRequest { TraktUserAvatarPost = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public async Task TestUserAvatarPutRequestIsPutRequest()
        {
            var request = new UserAvatarPutRequest { TraktUserAvatarPost = default! };
            request.Method.ShouldBe(HttpMethod.Put);
        }

        [Fact]
        public void TestUserAvatarPutRequestValidate()
        {
            var request = new UserAvatarPutRequest { TraktUserAvatarPost = default! };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
