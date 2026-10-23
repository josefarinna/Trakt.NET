#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncCollectionMinimalMoviesGetRequestTests
    {
        private const string URIPath = "sync/collection/minimal/movies";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktAvailableOn.Digital, $"{URIPath}?available_on=digital")]
        [InlineData(TraktAvailableOn.Other, $"{URIPath}?available_on=other")]
        [InlineData(TraktAvailableOn.Plex, $"{URIPath}?available_on=plex")]
        [InlineData(TraktAvailableOn.Jellyfin, $"{URIPath}?available_on=jellyfin")]
        public void TestSyncCollectionMinimalMoviesGetRequestHasValidURIPath(TraktAvailableOn? availableOn, string expectedURIPath)
        {
            var syncCollectionMinimalMoviesGetRequest = new SyncCollectionMinimalMoviesGetRequest
            {
                AvailableOn = availableOn
            };

            syncCollectionMinimalMoviesGetRequest.BuildUri();
            syncCollectionMinimalMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncCollectionMinimalMoviesGetRequestHasValidOAuthRequirement()
        {
            var syncCollectionMinimalMoviesGetRequest = new SyncCollectionMinimalMoviesGetRequest();
            syncCollectionMinimalMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncCollectionMinimalMoviesGetRequestIsGetRequest()
        {
            var syncCollectionMinimalMoviesGetRequest = new SyncCollectionMinimalMoviesGetRequest();
            syncCollectionMinimalMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncCollectionMinimalMoviesGetRequestHasCorrectRequestObjectType()
        {
            var syncCollectionMinimalMoviesGetRequest = new SyncCollectionMinimalMoviesGetRequest();
            syncCollectionMinimalMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}

