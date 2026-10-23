#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncCollectionEpisodesGetRequestTests
    {
        private const string URIPath = "sync/collection/episodes";

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
        public void TestSyncCollectionEpisodesGetRequestHasValidURIPath(TraktAvailableOn? availableOn, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var syncCollectionEpisodesGetRequest = new SyncCollectionEpisodesGetRequest
            {
                AvailableOn = availableOn,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            syncCollectionEpisodesGetRequest.BuildUri();
            syncCollectionEpisodesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncCollectionEpisodesGetRequestHasValidOAuthRequirement()
        {
            var syncCollectionEpisodesGetRequest = new SyncCollectionEpisodesGetRequest();
            syncCollectionEpisodesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncCollectionEpisodesGetRequestIsGetRequest()
        {
            var syncCollectionEpisodesGetRequest = new SyncCollectionEpisodesGetRequest();
            syncCollectionEpisodesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncCollectionEpisodesGetRequestHasCorrectRequestObjectType()
        {
            var syncCollectionEpisodesGetRequest = new SyncCollectionEpisodesGetRequest();
            syncCollectionEpisodesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}

