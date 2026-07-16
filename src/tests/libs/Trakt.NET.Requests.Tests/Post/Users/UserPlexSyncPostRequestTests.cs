#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserPlexSyncPostRequestTests
    {
        [Fact]
        public void TestUserPlexSyncPostRequestHasValidURIPath()
        {
            var request = new UserPlexSyncPostRequest
            {
                TraktPlexSyncPost = new TraktPlexSyncPost()
            };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri("users/settings/plex/sync", UriKind.Relative));
        }

        [Fact]
        public void TestUserPlexSyncPostRequestHasValidOAuthRequirement()
        {
            var request = new UserPlexSyncPostRequest { TraktPlexSyncPost = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPlexSyncPostRequestIsPostRequest()
        {
            var request = new UserPlexSyncPostRequest { TraktPlexSyncPost = default! };
            request.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserPlexSyncPostRequestHasCorrectRequestObjectType()
        {
            var request = new UserPlexSyncPostRequest { TraktPlexSyncPost = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserPlexSyncPostRequestValidate()
        {
            var request = new UserPlexSyncPostRequest { TraktPlexSyncPost = default! };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
