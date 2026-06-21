#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Sync
{
    public sealed class SyncWatchedHistoryRemovePostRequestTests
    {
        private const string URIPath = "sync/history/remove";

        [Fact]
        public void TestSyncWatchedHistoryRemovePostRequestHasValidURIPath()
        {
            var syncWatchedHistoryRemovePostRequest = new SyncWatchedHistoryRemovePostRequest
            {
                TraktSyncHistoryRemovePost = new TraktSyncHistoryRemovePost()
            };

            syncWatchedHistoryRemovePostRequest.BuildUri();
            syncWatchedHistoryRemovePostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncWatchedHistoryRemovePostRequestHasValidOAuthRequirement()
        {
            var syncWatchedHistoryRemovePostRequest = new SyncWatchedHistoryRemovePostRequest { TraktSyncHistoryRemovePost = default! };
            syncWatchedHistoryRemovePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncWatchedHistoryRemovePostRequestIsPostRequest()
        {
            var syncWatchedHistoryRemovePostRequest = new SyncWatchedHistoryRemovePostRequest { TraktSyncHistoryRemovePost = default! };
            syncWatchedHistoryRemovePostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSyncWatchedHistoryRemovePostRequestHasCorrectRequestObjectType()
        {
            var syncWatchedHistoryRemovePostRequest = new SyncWatchedHistoryRemovePostRequest { TraktSyncHistoryRemovePost = default! };
            syncWatchedHistoryRemovePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncWatchedHistoryRemovePostRequestValidate()
        {
            var syncWatchedHistoryRemovePostRequest = new SyncWatchedHistoryRemovePostRequest { TraktSyncHistoryRemovePost = default! };
            Action act = () => syncWatchedHistoryRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
