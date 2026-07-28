#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncWatchedProgressGetRequestTests
    {
        private const string URIPath = "sync/progress/watched";

        [Theory]
        [InlineData(null, null, null, null, null, null, null, null, null, URIPath)]
        [InlineData(null, null, null, null, null, null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, null, null, null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, null, null, null, null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktSortBy.Title, null, null, null, null, null, null, null, null, $"{URIPath}?sort_by=title")]
        [InlineData(TraktSortBy.Watched, null, null, null, null, null, null, null, null, $"{URIPath}?sort_by=watched")]
        [InlineData(null, TraktSortHow.Ascending, null, null, null, null, null, null, null, $"{URIPath}?sort_how=asc")]
        [InlineData(null, TraktSortHow.Descending, null, null, null, null, null, null, null, $"{URIPath}?sort_how=desc")]
        [InlineData(null, null, true, null, null, null, null, null, null, $"{URIPath}?lifetime_stats=true")]
        [InlineData(null, null, false, null, null, null, null, null, null, $"{URIPath}?lifetime_stats=false")]
        [InlineData(null, null, null, true, null, null, null, null, null, $"{URIPath}?hide_completed=true")]
        [InlineData(null, null, null, false, null, null, null, null, null, $"{URIPath}?hide_completed=false")]
        [InlineData(null, null, null, null, true, null, null, null, null, $"{URIPath}?hide_not_completed=true")]
        [InlineData(null, null, null, null, false, null, null, null, null, $"{URIPath}?hide_not_completed=false")]
        [InlineData(null, null, null, null, null, true, null, null, null, $"{URIPath}?only_rewatching=true")]
        [InlineData(null, null, null, null, null, false, null, null, null, $"{URIPath}?only_rewatching=false")]
        [InlineData(null, null, null, null, null, null, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, null, null, null, null, null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, null, null, null, null, null, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(null, null, null, null, null, null, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(null, null, null, null, null, null, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktSortBy.Title, TraktSortHow.Ascending, true, true, false, true, TraktExtendedInfo.Full, 1, 10, $"{URIPath}?sort_by=title&sort_how=asc&lifetime_stats=true&hide_completed=true&hide_not_completed=false&only_rewatching=true&extended=full&page=1&limit=10")]
        public void TestSyncWatchedProgressGetRequestHasValidURIPath(TraktSortBy? sortBy, TraktSortHow? sortHow, bool? lifetimeStats, bool? hideCompleted, bool? hideNotCompleted, bool? onlyRewatching, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var syncWatchedProgressGetRequest = new SyncWatchedProgressGetRequest
            {
                SortBy = sortBy,
                SortHow = sortHow,
                LifetimeStats = lifetimeStats,
                HideCompleted = hideCompleted,
                HideNotCompleted = hideNotCompleted,
                OnlyRewatching = onlyRewatching,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            syncWatchedProgressGetRequest.BuildUri();
            syncWatchedProgressGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncWatchedProgressGetRequestHasValidOAuthRequirement()
        {
            var syncWatchedProgressGetRequest = new SyncWatchedProgressGetRequest();
            syncWatchedProgressGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncWatchedProgressGetRequestIsGetRequest()
        {
            var syncWatchedProgressGetRequest = new SyncWatchedProgressGetRequest();
            syncWatchedProgressGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncWatchedProgressGetRequestHasCorrectRequestObjectType()
        {
            var syncWatchedProgressGetRequest = new SyncWatchedProgressGetRequest();
            syncWatchedProgressGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
