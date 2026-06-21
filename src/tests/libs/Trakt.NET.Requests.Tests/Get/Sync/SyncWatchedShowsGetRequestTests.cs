#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncWatchedShowsGetRequestTests
    {
        private const string URIPath = "sync/watched/shows";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestSyncWatchedShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var syncWatchedShowsGetRequest = new SyncWatchedShowsGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            syncWatchedShowsGetRequest.BuildUri();
            syncWatchedShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncWatchedShowsGetRequestHasValidOAuthRequirement()
        {
            var syncWatchedShowsGetRequest = new SyncWatchedShowsGetRequest();
            syncWatchedShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncWatchedShowsGetRequestIsGetRequest()
        {
            var syncWatchedShowsGetRequest = new SyncWatchedShowsGetRequest();
            syncWatchedShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncWatchedShowsGetRequestHasCorrectRequestObjectType()
        {
            var syncWatchedShowsGetRequest = new SyncWatchedShowsGetRequest();
            syncWatchedShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
