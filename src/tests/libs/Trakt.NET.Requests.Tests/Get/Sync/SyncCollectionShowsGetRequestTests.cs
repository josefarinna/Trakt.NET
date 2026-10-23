#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncCollectionShowsGetRequestTests
    {
        private const string URIPath = "sync/collection/shows";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(TraktAvailableOn.Digital, null, $"{URIPath}?available_on=digital")]
        [InlineData(TraktAvailableOn.Other, null, $"{URIPath}?available_on=other")]
        [InlineData(TraktAvailableOn.Plex, null, $"{URIPath}?available_on=plex")]
        [InlineData(TraktAvailableOn.Jellyfin, null, $"{URIPath}?available_on=jellyfin")]
        [InlineData(null, TraktExtendedInfo.None, URIPath)]
        [InlineData(null, TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        [InlineData(TraktAvailableOn.Digital, TraktExtendedInfo.Full, $"{URIPath}?available_on=digital&extended=full")]
        public void TestSyncCollectionShowsGetRequestHasValidURIPath(TraktAvailableOn? availableOn, TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var syncCollectionShowsGetRequest = new SyncCollectionShowsGetRequest
            {
                AvailableOn = availableOn,
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

