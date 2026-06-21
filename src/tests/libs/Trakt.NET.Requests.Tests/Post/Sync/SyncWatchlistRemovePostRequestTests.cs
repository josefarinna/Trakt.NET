#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Sync
{
    public sealed class SyncWatchlistRemovePostRequestTests
    {
        private const string URIPath = "sync/watchlist/remove";

        [Fact]
        public void TestSyncWatchlistRemovePostRequestHasValidURIPath()
        {
            var syncWatchlistRemovePostRequest = new SyncWatchlistRemovePostRequest
            {
                TraktSyncWatchlistRemovePost = new TraktSyncWatchlistRemovePost()
            };

            syncWatchlistRemovePostRequest.BuildUri();
            syncWatchlistRemovePostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncWatchlistRemovePostRequestHasValidOAuthRequirement()
        {
            var syncWatchlistRemovePostRequest = new SyncWatchlistRemovePostRequest { TraktSyncWatchlistRemovePost = default! };
            syncWatchlistRemovePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncWatchlistRemovePostRequestIsPostRequest()
        {
            var syncWatchlistRemovePostRequest = new SyncWatchlistRemovePostRequest { TraktSyncWatchlistRemovePost = default! };
            syncWatchlistRemovePostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSyncWatchlistRemovePostRequestHasCorrectRequestObjectType()
        {
            var syncWatchlistRemovePostRequest = new SyncWatchlistRemovePostRequest { TraktSyncWatchlistRemovePost = default! };
            syncWatchlistRemovePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncWatchlistRemovePostRequestValidate()
        {
            var syncWatchlistRemovePostRequest = new SyncWatchlistRemovePostRequest { TraktSyncWatchlistRemovePost = default! };
            Action act = () => syncWatchlistRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
