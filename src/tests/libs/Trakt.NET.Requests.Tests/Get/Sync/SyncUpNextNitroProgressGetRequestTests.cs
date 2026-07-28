#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncUpNextNitroProgressGetRequestTests
    {
        private const string URIPath = "sync/progress/up_next_nitro";

        [Theory]
        [InlineData(null, null, null, null, null, null, null, URIPath)]
        [InlineData(null, null, null, null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, null, null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktSortBy.Title, null, null, null, null, null, null, $"{URIPath}?sort_by=title")]
        [InlineData(null, TraktSortHow.Ascending, null, null, null, null, null, $"{URIPath}?sort_how=asc")]
        [InlineData(null, null, TraktUpNextIntent.Start, null, null, null, null, $"{URIPath}?intent=start")]
        [InlineData(null, null, null, "any", null, null, null, $"{URIPath}?watchnow=any")]
        [InlineData(TraktSortBy.Title, TraktSortHow.Ascending, TraktUpNextIntent.Continue, "favorites", null, 1, 10, $"{URIPath}?sort_by=title&sort_how=asc&intent=continue&watchnow=favorites&page=1&limit=10")]
        public void TestSyncUpNextNitroProgressGetRequestHasValidURIPath(TraktSortBy? sortBy, TraktSortHow? sortHow, TraktUpNextIntent? intent, string? watchNow, TraktFilter? filter, int? page, int? limit, string expectedURIPath)
        {
            var syncUpNextNitroProgressGetRequest = new SyncUpNextNitroProgressGetRequest
            {
                SortBy = sortBy,
                SortHow = sortHow,
                Intent = intent,
                WatchNow = watchNow,
                Filter = filter,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            syncUpNextNitroProgressGetRequest.BuildUri();
            syncUpNextNitroProgressGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncUpNextNitroProgressGetRequestHasValidOAuthRequirement()
        {
            var syncUpNextNitroProgressGetRequest = new SyncUpNextNitroProgressGetRequest();
            syncUpNextNitroProgressGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncUpNextNitroProgressGetRequestIsGetRequest()
        {
            var syncUpNextNitroProgressGetRequest = new SyncUpNextNitroProgressGetRequest();
            syncUpNextNitroProgressGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncUpNextNitroProgressGetRequestHasCorrectRequestObjectType()
        {
            var syncUpNextNitroProgressGetRequest = new SyncUpNextNitroProgressGetRequest();
            syncUpNextNitroProgressGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
