#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Users
{
    public sealed class UserSyncUndoDeleteRequestTests
    {
        private const string URIPath = "users/syncs/12345";

        [Fact]
        public void TestUserSyncUndoDeleteRequestHasValidURIPath()
        {
            var request = new UserSyncUndoDeleteRequest { Id = 12345UL };
            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSyncUndoDeleteRequestHasValidOAuthRequirement()
        {
            var request = new UserSyncUndoDeleteRequest { Id = 12345UL };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserSyncUndoDeleteRequestIsDeleteRequest()
        {
            var request = new UserSyncUndoDeleteRequest { Id = 12345UL };
            request.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestUserSyncUndoDeleteRequestHasCorrectRequestObjectType()
        {
            var request = new UserSyncUndoDeleteRequest { Id = 12345UL };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserSyncUndoDeleteRequestValidate()
        {
            var request = new UserSyncUndoDeleteRequest { Id = 0UL };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
