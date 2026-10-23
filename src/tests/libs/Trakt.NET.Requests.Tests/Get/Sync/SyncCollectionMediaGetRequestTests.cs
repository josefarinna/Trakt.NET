#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncCollectionMediaGetRequestTests
    {
        private const string URIPath = "sync/collection/media";

        [Theory]
        [InlineData(null, null, null, null, URIPath)]
        [InlineData(TraktAvailableOn.Digital, null, null, null, $"{URIPath}?available_on=digital")]
        [InlineData(TraktAvailableOn.Other, null, null, null, $"{URIPath}?available_on=other")]
        [InlineData(TraktAvailableOn.Plex, null, null, null, $"{URIPath}?available_on=plex")]
        [InlineData(TraktAvailableOn.Jellyfin, null, null, null, $"{URIPath}?available_on=jellyfin")]
        [InlineData(null, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktAvailableOn.Digital, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?available_on=digital&extended=full&page=10&limit=20")]
        public void TestSyncCollectionMediaGetRequestHasValidURIPath(TraktAvailableOn? availableOn, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var syncCollectionMediaGetRequest = new SyncCollectionMediaGetRequest
            {
                AvailableOn = availableOn,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            syncCollectionMediaGetRequest.BuildUri();
            syncCollectionMediaGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncCollectionMediaGetRequestHasValidOAuthRequirement()
        {
            var syncCollectionMediaGetRequest = new SyncCollectionMediaGetRequest();
            syncCollectionMediaGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncCollectionMediaGetRequestIsGetRequest()
        {
            var syncCollectionMediaGetRequest = new SyncCollectionMediaGetRequest();
            syncCollectionMediaGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncCollectionMediaGetRequestHasCorrectRequestObjectType()
        {
            var syncCollectionMediaGetRequest = new SyncCollectionMediaGetRequest();
            syncCollectionMediaGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}

