#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncWatchedEpisodesGetRequestTests
    {
        private const string URIPath = "sync/watched/episodes";

        [Theory]
        [InlineData(null, null, null, URIPath)]
        [InlineData(null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        public void TestSyncWatchedEpisodesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var syncWatchedEpisodesGetRequest = new SyncWatchedEpisodesGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            syncWatchedEpisodesGetRequest.BuildUri();
            syncWatchedEpisodesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncWatchedEpisodesGetRequestHasValidOAuthRequirement()
        {
            var syncWatchedEpisodesGetRequest = new SyncWatchedEpisodesGetRequest();
            syncWatchedEpisodesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncWatchedEpisodesGetRequestIsGetRequest()
        {
            var syncWatchedEpisodesGetRequest = new SyncWatchedEpisodesGetRequest();
            syncWatchedEpisodesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncWatchedEpisodesGetRequestHasCorrectRequestObjectType()
        {
            var syncWatchedEpisodesGetRequest = new SyncWatchedEpisodesGetRequest();
            syncWatchedEpisodesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
