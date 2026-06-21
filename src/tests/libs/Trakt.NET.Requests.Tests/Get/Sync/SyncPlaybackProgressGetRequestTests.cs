#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncPlaybackProgressGetRequestTests
    {
        private const string URIPath = "sync/playback";

        [Theory]
        [InlineData(null, null, null, URIPath)]
        [InlineData(null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktSyncType.Unspecified, null, null, URIPath)]
        [InlineData(TraktSyncType.Unspecified, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktSyncType.Unspecified, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktSyncType.Unspecified, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktSyncType.Movie, null, null, $"{URIPath}/movies")]
        [InlineData(TraktSyncType.Movie, 10, null, $"{URIPath}/movies?page=10")]
        [InlineData(TraktSyncType.Movie, null, 20, $"{URIPath}/movies?limit=20")]
        [InlineData(TraktSyncType.Movie, 10, 20, $"{URIPath}/movies?page=10&limit=20")]
        public void TestSyncPlaybackProgressGetRequestHasValidURIPath(TraktSyncType? type, int? page, int? limit, string expectedURIPath)
        {
            var syncPlaybackProgressGetRequest = new SyncPlaybackProgressGetRequest
            {
                Type = type,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            syncPlaybackProgressGetRequest.BuildUri();
            syncPlaybackProgressGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncPlaybackProgressGetRequestHasValidOAuthRequirement()
        {
            var syncPlaybackProgressGetRequest = new SyncPlaybackProgressGetRequest();
            syncPlaybackProgressGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncPlaybackProgressGetRequestIsGetRequest()
        {
            var syncPlaybackProgressGetRequest = new SyncPlaybackProgressGetRequest();
            syncPlaybackProgressGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncPlaybackProgressGetRequestHasCorrectRequestObjectType()
        {
            var syncPlaybackProgressGetRequest = new SyncPlaybackProgressGetRequest();
            syncPlaybackProgressGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
