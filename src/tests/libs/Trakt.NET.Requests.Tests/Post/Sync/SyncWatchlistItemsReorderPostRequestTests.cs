#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Sync
{
    public sealed class SyncWatchlistItemsReorderPostRequestTests
    {
        private const string URIPath = "sync/watchlist/reorder";

        [Fact]
        public void TestSyncWatchlistItemsReorderPostRequestHasValidURIPath()
        {
            var syncWatchlistItemsReorderPostRequest = new SyncWatchlistItemsReorderPostRequest
            {
                TraktListItemsReorderPost = new TraktListItemsReorderPost()
            };

            syncWatchlistItemsReorderPostRequest.BuildUri();
            syncWatchlistItemsReorderPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncWatchlistItemsReorderPostRequestHasValidOAuthRequirement()
        {
            var syncWatchlistItemsReorderPostRequest = new SyncWatchlistItemsReorderPostRequest { TraktListItemsReorderPost = default! };
            syncWatchlistItemsReorderPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncWatchlistItemsReorderPostRequestIsPostRequest()
        {
            var syncWatchlistItemsReorderPostRequest = new SyncWatchlistItemsReorderPostRequest { TraktListItemsReorderPost = default! };
            syncWatchlistItemsReorderPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSyncWatchlistItemsReorderPostRequestHasCorrectRequestObjectType()
        {
            var syncWatchlistItemsReorderPostRequest = new SyncWatchlistItemsReorderPostRequest { TraktListItemsReorderPost = default! };
            syncWatchlistItemsReorderPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncWatchlistItemsReorderPostRequestValidate()
        {
            var syncWatchlistItemsReorderPostRequest = new SyncWatchlistItemsReorderPostRequest { TraktListItemsReorderPost = default! };
            Action act = () => syncWatchlistItemsReorderPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
