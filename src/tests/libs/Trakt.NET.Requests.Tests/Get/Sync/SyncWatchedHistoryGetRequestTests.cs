#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncWatchedHistoryGetRequestTests
    {
        private const string URIPath = "sync/history";

        [Theory]
        [InlineData(null, null, null, null, URIPath)]
        [InlineData(null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktSyncItemType.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktSyncItemType.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktSyncItemType.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktSyncItemType.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktSyncItemType.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktSyncItemType.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktSyncItemType.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktSyncItemType.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktSyncItemType.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktSyncItemType.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktSyncItemType.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktSyncItemType.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktSyncItemType.Movie, null, null, null, $"{URIPath}/movies")]
        [InlineData(TraktSyncItemType.Movie, null, 10, null, $"{URIPath}/movies?page=10")]
        [InlineData(TraktSyncItemType.Movie, null, null, 20, $"{URIPath}/movies?limit=20")]
        [InlineData(TraktSyncItemType.Movie, null, 10, 20, $"{URIPath}/movies?page=10&limit=20")]
        [InlineData(TraktSyncItemType.Movie, TraktExtendedInfo.None, null, null, $"{URIPath}/movies")]
        [InlineData(TraktSyncItemType.Movie, TraktExtendedInfo.None, 10, null, $"{URIPath}/movies?page=10")]
        [InlineData(TraktSyncItemType.Movie, TraktExtendedInfo.None, null, 20, $"{URIPath}/movies?limit=20")]
        [InlineData(TraktSyncItemType.Movie, TraktExtendedInfo.None, 10, 20, $"{URIPath}/movies?page=10&limit=20")]
        [InlineData(TraktSyncItemType.Movie, TraktExtendedInfo.Full, null, null, $"{URIPath}/movies?extended=full")]
        [InlineData(TraktSyncItemType.Movie, TraktExtendedInfo.Full, 10, null, $"{URIPath}/movies?extended=full&page=10")]
        [InlineData(TraktSyncItemType.Movie, TraktExtendedInfo.Full, null, 20, $"{URIPath}/movies?extended=full&limit=20")]
        [InlineData(TraktSyncItemType.Movie, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/movies?extended=full&page=10&limit=20")]
        public void TestSyncWatchedHistoryGetRequestHasValidURIPath(TraktSyncItemType? type, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var syncWatchedHistoryGetRequest = new SyncWatchedHistoryGetRequest
            {
                Type = type,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            syncWatchedHistoryGetRequest.BuildUri();
            syncWatchedHistoryGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncWatchedHistoryGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "batman" };
            var request = new SyncWatchedHistoryGetRequest
            {
                Filter = filter
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"{URIPath}?query=batman", UriKind.Relative));
        }

        [Fact]
        public void TestSyncWatchedHistoryGetRequestHasValidOAuthRequirement()
        {
            var syncWatchedHistoryGetRequest = new SyncWatchedHistoryGetRequest();
            syncWatchedHistoryGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncWatchedHistoryGetRequestIsGetRequest()
        {
            var syncWatchedHistoryGetRequest = new SyncWatchedHistoryGetRequest();
            syncWatchedHistoryGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncWatchedHistoryGetRequestHasCorrectRequestObjectType()
        {
            var syncWatchedHistoryGetRequest = new SyncWatchedHistoryGetRequest();
            syncWatchedHistoryGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
