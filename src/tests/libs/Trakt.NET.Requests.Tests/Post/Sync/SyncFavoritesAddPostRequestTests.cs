#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Sync
{
    public sealed class SyncFavoritesAddPostRequestTests
    {
        private const string URIPath = "sync/favorites";

        [Fact]
        public void TestSyncFavoritesAddPostRequestHasValidURIPath()
        {
            var syncFavoritesAddPostRequest = new SyncFavoritesAddPostRequest
            {
                TraktSyncFavoritesPost = new TraktSyncFavoritesPost()
            };

            syncFavoritesAddPostRequest.BuildUri();
            syncFavoritesAddPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncFavoritesAddPostRequestHasValidOAuthRequirement()
        {
            var syncFavoritesAddPostRequest = new SyncFavoritesAddPostRequest { TraktSyncFavoritesPost = default! };
            syncFavoritesAddPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncFavoritesAddPostRequestIsPostRequest()
        {
            var syncFavoritesAddPostRequest = new SyncFavoritesAddPostRequest { TraktSyncFavoritesPost = default! };
            syncFavoritesAddPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSyncFavoritesAddPostRequestHasCorrectRequestObjectType()
        {
            var syncFavoritesAddPostRequest = new SyncFavoritesAddPostRequest { TraktSyncFavoritesPost = default! };
            syncFavoritesAddPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncFavoritesAddPostRequestValidate()
        {
            var syncFavoritesAddPostRequest = new SyncFavoritesAddPostRequest { TraktSyncFavoritesPost = default! };
            Action act = () => syncFavoritesAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
