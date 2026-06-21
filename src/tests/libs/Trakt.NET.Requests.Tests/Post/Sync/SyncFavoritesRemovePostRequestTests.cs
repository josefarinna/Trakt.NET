#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Sync
{
    public sealed class SyncFavoritesRemovePostRequestTests
    {
        private const string URIPath = "sync/favorites/remove";

        [Fact]
        public void TestSyncFavoritesRemovePostRequestHasValidURIPath()
        {
            var syncFavoritesRemovePostRequest = new SyncFavoritesRemovePostRequest
            {
                TraktSyncFavoritesRemovePost = new TraktSyncFavoritesRemovePost()
            };

            syncFavoritesRemovePostRequest.BuildUri();
            syncFavoritesRemovePostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncFavoritesRemovePostRequestHasValidOAuthRequirement()
        {
            var syncFavoritesRemovePostRequest = new SyncFavoritesRemovePostRequest { TraktSyncFavoritesRemovePost = default! };
            syncFavoritesRemovePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncFavoritesRemovePostRequestIsPostRequest()
        {
            var syncFavoritesRemovePostRequest = new SyncFavoritesRemovePostRequest { TraktSyncFavoritesRemovePost = default! };
            syncFavoritesRemovePostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSyncFavoritesRemovePostRequestHasCorrectRequestObjectType()
        {
            var syncFavoritesRemovePostRequest = new SyncFavoritesRemovePostRequest { TraktSyncFavoritesRemovePost = default! };
            syncFavoritesRemovePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncFavoritesRemovePostRequestValidate()
        {
            var syncFavoritesRemovePostRequest = new SyncFavoritesRemovePostRequest { TraktSyncFavoritesRemovePost = default! };
            Action act = () => syncFavoritesRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
