#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PutRequests.Sync
{
    public sealed class SyncWatchlistUpdatePostRequestTests
    {
        private const string URIPath = "sync/watchlist";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Images, $"{URIPath}?extended=images")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestSyncWatchlistUpdatePostRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var syncWatchlistUpdatePostRequest = new SyncWatchlistUpdatePostRequest
            {
                TraktUpdateListPost = new TraktUpdateListPost(),
                ExtendedInfo = extendedInfo
            };

            syncWatchlistUpdatePostRequest.BuildUri();
            syncWatchlistUpdatePostRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncWatchlistUpdatePostRequestHasValidOAuthRequirement()
        {
            var syncWatchlistUpdatePostRequest = new SyncWatchlistUpdatePostRequest { TraktUpdateListPost = default! };
            syncWatchlistUpdatePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncWatchlistUpdatePostRequestIsPutRequest()
        {
            var syncWatchlistUpdatePostRequest = new SyncWatchlistUpdatePostRequest { TraktUpdateListPost = default! };
            syncWatchlistUpdatePostRequest.Method.ShouldBe(HttpMethod.Put);
        }

        [Fact]
        public void TestSyncWatchlistUpdatePostRequestHasCorrectRequestObjectType()
        {
            var syncWatchlistUpdatePostRequest = new SyncWatchlistUpdatePostRequest { TraktUpdateListPost = default! };
            syncWatchlistUpdatePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncWatchlistUpdatePostRequestValidate()
        {
            var syncWatchlistUpdatePostRequest = new SyncWatchlistUpdatePostRequest { TraktUpdateListPost = default! };
            Action act = () => syncWatchlistUpdatePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
