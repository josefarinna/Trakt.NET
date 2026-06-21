#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Sync
{
    public sealed class SyncWatchlistAddPostRequestTests
    {
        private const string URIPath = "sync/watchlist";

        [Fact]
        public void TestSyncWatchlistAddPostRequestHasValidURIPath()
        {
            var syncWatchlistAddPostRequest = new SyncWatchlistAddPostRequest
            {
                TraktSyncWatchlistPost = new TraktSyncWatchlistPost()
            };

            syncWatchlistAddPostRequest.BuildUri();
            syncWatchlistAddPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncWatchlistAddPostRequestHasValidOAuthRequirement()
        {
            var syncWatchlistAddPostRequest = new SyncWatchlistAddPostRequest { TraktSyncWatchlistPost = default! };
            syncWatchlistAddPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncWatchlistAddPostRequestIsPostRequest()
        {
            var syncWatchlistAddPostRequest = new SyncWatchlistAddPostRequest { TraktSyncWatchlistPost = default! };
            syncWatchlistAddPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSyncWatchlistAddPostRequestHasCorrectRequestObjectType()
        {
            var syncWatchlistAddPostRequest = new SyncWatchlistAddPostRequest { TraktSyncWatchlistPost = default! };
            syncWatchlistAddPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncWatchlistAddPostRequestValidate()
        {
            var syncWatchlistAddPostRequest = new SyncWatchlistAddPostRequest { TraktSyncWatchlistPost = default! };
            Action act = () => syncWatchlistAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
