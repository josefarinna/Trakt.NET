#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncCollectionMinimalEpisodesGetRequestTests
    {
        private const string URIPath = "sync/collection/minimal/episodes";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData("netflix", $"{URIPath}?available_on=netflix")]
        public void TestSyncCollectionMinimalEpisodesGetRequestHasValidURIPath(string? availableOn, string expectedURIPath)
        {
            var syncCollectionMinimalEpisodesGetRequest = new SyncCollectionMinimalEpisodesGetRequest
            {
                AvailableOn = availableOn
            };

            syncCollectionMinimalEpisodesGetRequest.BuildUri();
            syncCollectionMinimalEpisodesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncCollectionMinimalEpisodesGetRequestHasValidOAuthRequirement()
        {
            var syncCollectionMinimalEpisodesGetRequest = new SyncCollectionMinimalEpisodesGetRequest();
            syncCollectionMinimalEpisodesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncCollectionMinimalEpisodesGetRequestIsGetRequest()
        {
            var syncCollectionMinimalEpisodesGetRequest = new SyncCollectionMinimalEpisodesGetRequest();
            syncCollectionMinimalEpisodesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncCollectionMinimalEpisodesGetRequestHasCorrectRequestObjectType()
        {
            var syncCollectionMinimalEpisodesGetRequest = new SyncCollectionMinimalEpisodesGetRequest();
            syncCollectionMinimalEpisodesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
