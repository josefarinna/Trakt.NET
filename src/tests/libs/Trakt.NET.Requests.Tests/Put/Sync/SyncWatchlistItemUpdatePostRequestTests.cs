#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PutRequests.Sync
{
    public sealed class SyncWatchlistItemUpdatePostRequestTests
    {
        private const string URIPath = "sync/watchlist/123";

        [Fact]
        public void TestSyncWatchlistItemUpdatePostRequestHasValidURIPath()
        {
            var syncWatchlistItemUpdatePostRequest = new SyncWatchlistItemUpdatePostRequest
            {
                ListItemId = 123U,
                TraktListItemUpdatePost = new TraktListItemUpdatePost()
            };

            syncWatchlistItemUpdatePostRequest.BuildUri();
            syncWatchlistItemUpdatePostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncWatchlistItemUpdatePostRequestHasValidOAuthRequirement()
        {
            var syncWatchlistItemUpdatePostRequest = new SyncWatchlistItemUpdatePostRequest();
            syncWatchlistItemUpdatePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncWatchlistItemUpdatePostRequestIsPutRequest()
        {
            var syncWatchlistItemUpdatePostRequest = new SyncWatchlistItemUpdatePostRequest();
            syncWatchlistItemUpdatePostRequest.Method.ShouldBe(HttpMethod.Put);
        }

        [Fact]
        public void TestSyncWatchlistItemUpdatePostRequestHasCorrectRequestObjectType()
        {
            var syncWatchlistItemUpdatePostRequest = new SyncWatchlistItemUpdatePostRequest();
            syncWatchlistItemUpdatePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncWatchlistItemUpdatePostRequestValidate()
        {
            var syncWatchlistItemUpdatePostRequest = new SyncWatchlistItemUpdatePostRequest { TraktListItemUpdatePost = default! };
            Action act = () => syncWatchlistItemUpdatePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
