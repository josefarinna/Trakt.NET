#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncFavoritesGetRequestTests
    {
        private const string URIPath = "sync/favorites";

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
        [InlineData(TraktSortHow.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktSortHow.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktSortHow.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktSortHow.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktSortHow.Ascending, null, null, null, $"{URIPath}/asc")]
        [InlineData(TraktSortHow.Ascending, null, 10, null, $"{URIPath}/asc?page=10")]
        [InlineData(TraktSortHow.Ascending, null, null, 20, $"{URIPath}/asc?limit=20")]
        [InlineData(TraktSortHow.Ascending, null, 10, 20, $"{URIPath}/asc?page=10&limit=20")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.None, null, null, $"{URIPath}/asc")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.None, 10, null, $"{URIPath}/asc?page=10")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.None, null, 20, $"{URIPath}/asc?limit=20")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.None, 10, 20, $"{URIPath}/asc?page=10&limit=20")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.Full, null, null, $"{URIPath}/asc?extended=full")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.Full, 10, null, $"{URIPath}/asc?extended=full&page=10")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.Full, null, 20, $"{URIPath}/asc?extended=full&limit=20")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/asc?extended=full&page=10&limit=20")]
        public void TestSyncFavoritesGetRequestHasValidURIPath(TraktSortHow? sortHow, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var syncFavoritesGetRequest = new SyncFavoritesGetRequest
            {
                SortHow = sortHow,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            syncFavoritesGetRequest.BuildUri();
            syncFavoritesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncFavoritesGetRequestHasValidOAuthRequirement()
        {
            var syncFavoritesGetRequest = new SyncFavoritesGetRequest();
            syncFavoritesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncFavoritesGetRequestIsGetRequest()
        {
            var syncFavoritesGetRequest = new SyncFavoritesGetRequest();
            syncFavoritesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncFavoritesGetRequestHasCorrectRequestObjectType()
        {
            var syncFavoritesGetRequest = new SyncFavoritesGetRequest();
            syncFavoritesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
