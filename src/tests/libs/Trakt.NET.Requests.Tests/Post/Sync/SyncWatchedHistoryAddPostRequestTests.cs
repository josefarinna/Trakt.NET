#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Sync
{
    public sealed class SyncWatchedHistoryAddPostRequestTests
    {
        private const string URIPath = "sync/history";

        [Fact]
        public void TestSyncWatchedHistoryAddPostRequestHasValidURIPath()
        {
            var syncWatchedHistoryAddPostRequest = new SyncWatchedHistoryAddPostRequest
            {
                TraktSyncHistoryPost = new TraktSyncHistoryPost()
            };

            syncWatchedHistoryAddPostRequest.BuildUri();
            syncWatchedHistoryAddPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncWatchedHistoryAddPostRequestHasValidOAuthRequirement()
        {
            var syncWatchedHistoryAddPostRequest = new SyncWatchedHistoryAddPostRequest { TraktSyncHistoryPost = default! };
            syncWatchedHistoryAddPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncWatchedHistoryAddPostRequestIsPostRequest()
        {
            var syncWatchedHistoryAddPostRequest = new SyncWatchedHistoryAddPostRequest { TraktSyncHistoryPost = default! };
            syncWatchedHistoryAddPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSyncWatchedHistoryAddPostRequestHasCorrectRequestObjectType()
        {
            var syncWatchedHistoryAddPostRequest = new SyncWatchedHistoryAddPostRequest { TraktSyncHistoryPost = default! };
            syncWatchedHistoryAddPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncWatchedHistoryAddPostRequestValidate()
        {
            var syncWatchedHistoryAddPostRequest = new SyncWatchedHistoryAddPostRequest { TraktSyncHistoryPost = default! };
            Action act = () => syncWatchedHistoryAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
