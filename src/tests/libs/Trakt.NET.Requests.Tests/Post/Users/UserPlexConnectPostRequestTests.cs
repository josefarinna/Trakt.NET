#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserPlexConnectPostRequestTests
    {
        [Fact]
        public void TestUserPlexConnectPostRequestHasValidURIPath()
        {
            var request = new UserPlexConnectPostRequest
            {
                TraktPlexConnectPost = new TraktPlexConnectPost
                {
                    ReturnUrl = "http://localhost"
                }
            };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri("users/settings/plex/connect", UriKind.Relative));
        }

        [Fact]
        public void TestUserPlexConnectPostRequestHasValidOAuthRequirement()
        {
            var request = new UserPlexConnectPostRequest { TraktPlexConnectPost = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPlexConnectPostRequestIsPostRequest()
        {
            var request = new UserPlexConnectPostRequest { TraktPlexConnectPost = default! };
            request.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserPlexConnectPostRequestHasCorrectRequestObjectType()
        {
            var request = new UserPlexConnectPostRequest { TraktPlexConnectPost = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserPlexConnectPostRequestValidate()
        {
            var request = new UserPlexConnectPostRequest { TraktPlexConnectPost = default! };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
