#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncRatingsGetRequestTests
    {
        private const string URIPath = "sync/ratings";

        [Theory]
        [InlineData(null, null, null, null, $"{URIPath}/123")]
        [InlineData(null, null, 10, null, $"{URIPath}/123?page=10")]
        [InlineData(null, null, null, 20, $"{URIPath}/123?limit=20")]
        [InlineData(null, null, 10, 20, $"{URIPath}/123?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, null, null, $"{URIPath}/123")]
        [InlineData(null, TraktExtendedInfo.None, 10, null, $"{URIPath}/123?page=10")]
        [InlineData(null, TraktExtendedInfo.None, null, 20, $"{URIPath}/123?limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, 20, $"{URIPath}/123?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{URIPath}/123?extended=full")]
        [InlineData(null, TraktExtendedInfo.Full, 10, null, $"{URIPath}/123?extended=full&page=10")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20, $"{URIPath}/123?extended=full&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/123?extended=full&page=10&limit=20")]
        [InlineData(TraktRatingsItemType.Unspecified, null, null, null, $"{URIPath}/123")]
        [InlineData(TraktRatingsItemType.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}/123?page=10")]
        [InlineData(TraktRatingsItemType.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}/123?limit=20")]
        [InlineData(TraktRatingsItemType.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}/123?page=10&limit=20")]
        [InlineData(TraktRatingsItemType.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}/123?extended=full")]
        [InlineData(TraktRatingsItemType.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}/123?extended=full&page=10")]
        [InlineData(TraktRatingsItemType.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}/123?extended=full&limit=20")]
        [InlineData(TraktRatingsItemType.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/123?extended=full&page=10&limit=20")]
        [InlineData(TraktRatingsItemType.Movie, null, null, null, $"{URIPath}/movies/123")]
        [InlineData(TraktRatingsItemType.Movie, null, 10, null, $"{URIPath}/movies/123?page=10")]
        [InlineData(TraktRatingsItemType.Movie, null, null, 20, $"{URIPath}/movies/123?limit=20")]
        [InlineData(TraktRatingsItemType.Movie, null, 10, 20, $"{URIPath}/movies/123?page=10&limit=20")]
        [InlineData(TraktRatingsItemType.Movie, TraktExtendedInfo.None, null, null, $"{URIPath}/movies/123")]
        [InlineData(TraktRatingsItemType.Movie, TraktExtendedInfo.None, 10, null, $"{URIPath}/movies/123?page=10")]
        [InlineData(TraktRatingsItemType.Movie, TraktExtendedInfo.None, null, 20, $"{URIPath}/movies/123?limit=20")]
        [InlineData(TraktRatingsItemType.Movie, TraktExtendedInfo.None, 10, 20, $"{URIPath}/movies/123?page=10&limit=20")]
        [InlineData(TraktRatingsItemType.Movie, TraktExtendedInfo.Full, null, null, $"{URIPath}/movies/123?extended=full")]
        [InlineData(TraktRatingsItemType.Movie, TraktExtendedInfo.Full, 10, null, $"{URIPath}/movies/123?extended=full&page=10")]
        [InlineData(TraktRatingsItemType.Movie, TraktExtendedInfo.Full, null, 20, $"{URIPath}/movies/123?extended=full&limit=20")]
        [InlineData(TraktRatingsItemType.Movie, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/movies/123?extended=full&page=10&limit=20")]
        public void TestSyncRatingsGetRequestHasValidURIPath(TraktRatingsItemType? type, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var syncRatingsGetRequest = new SyncRatingsGetRequest
            {
                RatingFilter = "123",
                Type = type,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            syncRatingsGetRequest.BuildUri();
            syncRatingsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncRatingsGetRequestHasValidOAuthRequirement()
        {
            var syncRatingsGetRequest = new SyncRatingsGetRequest();
            syncRatingsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncRatingsGetRequestIsGetRequest()
        {
            var syncRatingsGetRequest = new SyncRatingsGetRequest();
            syncRatingsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncRatingsGetRequestHasCorrectRequestObjectType()
        {
            var syncRatingsGetRequest = new SyncRatingsGetRequest();
            syncRatingsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
