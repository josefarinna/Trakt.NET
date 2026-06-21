#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncWatchedMoviesGetRequestTests
    {
        private const string URIPath = "sync/watched/movies";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestSyncWatchedMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var syncWatchedMoviesGetRequest = new SyncWatchedMoviesGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            syncWatchedMoviesGetRequest.BuildUri();
            syncWatchedMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncWatchedMoviesGetRequestHasValidOAuthRequirement()
        {
            var syncWatchedMoviesGetRequest = new SyncWatchedMoviesGetRequest();
            syncWatchedMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncWatchedMoviesGetRequestIsGetRequest()
        {
            var syncWatchedMoviesGetRequest = new SyncWatchedMoviesGetRequest();
            syncWatchedMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncWatchedMoviesGetRequestHasCorrectRequestObjectType()
        {
            var syncWatchedMoviesGetRequest = new SyncWatchedMoviesGetRequest();
            syncWatchedMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
