#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncCollectionMoviesGetRequestTests
    {
        private const string URIPath = "sync/collection/movies";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestSyncCollectionMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var syncCollectionMoviesGetRequest = new SyncCollectionMoviesGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            syncCollectionMoviesGetRequest.BuildUri();
            syncCollectionMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncCollectionMoviesGetRequestHasValidOAuthRequirement()
        {
            var syncCollectionMoviesGetRequest = new SyncCollectionMoviesGetRequest();
            syncCollectionMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncCollectionMoviesGetRequestIsGetRequest()
        {
            var syncCollectionMoviesGetRequest = new SyncCollectionMoviesGetRequest();
            syncCollectionMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncCollectionMoviesGetRequestHasCorrectRequestObjectType()
        {
            var syncCollectionMoviesGetRequest = new SyncCollectionMoviesGetRequest();
            syncCollectionMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
