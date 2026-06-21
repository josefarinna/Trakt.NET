#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncCollectionShowsGetRequestTests
    {
        private const string URIPath = "sync/collection/shows";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestSyncCollectionShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var syncCollectionShowsGetRequest = new SyncCollectionShowsGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            syncCollectionShowsGetRequest.BuildUri();
            syncCollectionShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncCollectionShowsGetRequestHasValidOAuthRequirement()
        {
            var syncCollectionShowsGetRequest = new SyncCollectionShowsGetRequest();
            syncCollectionShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncCollectionShowsGetRequestIsGetRequest()
        {
            var syncCollectionShowsGetRequest = new SyncCollectionShowsGetRequest();
            syncCollectionShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncCollectionShowsGetRequestHasCorrectRequestObjectType()
        {
            var syncCollectionShowsGetRequest = new SyncCollectionShowsGetRequest();
            syncCollectionShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
