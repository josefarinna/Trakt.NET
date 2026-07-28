#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncUpNextProgressGetRequestTests
    {
        private const string URIPath = "sync/progress/up_next";

        [Theory]
        [InlineData(null, null, null, null, null, null, null, URIPath)]
        [InlineData(null, null, null, null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, null, null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktSortBy.Title, null, null, null, null, null, null, $"{URIPath}?sort_by=title")]
        [InlineData(null, TraktSortHow.Ascending, null, null, null, null, null, $"{URIPath}?sort_how=asc")]
        [InlineData(null, null, true, null, null, null, null, $"{URIPath}?include_stats=true")]
        [InlineData(null, null, null, true, null, null, null, $"{URIPath}?lifetime_stats=true")]
        [InlineData(TraktSortBy.Title, TraktSortHow.Ascending, true, true, TraktExtendedInfo.Full, 1, 10, $"{URIPath}?sort_by=title&sort_how=asc&include_stats=true&lifetime_stats=true&extended=full&page=1&limit=10")]
        public void TestSyncUpNextProgressGetRequestHasValidURIPath(TraktSortBy? sortBy, TraktSortHow? sortHow, bool? includeStats, bool? lifetimeStats, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var syncUpNextProgressGetRequest = new SyncUpNextProgressGetRequest
            {
                SortBy = sortBy,
                SortHow = sortHow,
                IncludeStats = includeStats,
                LifetimeStats = lifetimeStats,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            syncUpNextProgressGetRequest.BuildUri();
            syncUpNextProgressGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncUpNextProgressGetRequestHasValidOAuthRequirement()
        {
            var syncUpNextProgressGetRequest = new SyncUpNextProgressGetRequest();
            syncUpNextProgressGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncUpNextProgressGetRequestIsGetRequest()
        {
            var syncUpNextProgressGetRequest = new SyncUpNextProgressGetRequest();
            syncUpNextProgressGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncUpNextProgressGetRequestHasCorrectRequestObjectType()
        {
            var syncUpNextProgressGetRequest = new SyncUpNextProgressGetRequest();
            syncUpNextProgressGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
