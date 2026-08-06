#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncCollectionMinimalShowsGetRequestTests
    {
        private const string URIPath = "sync/collection/minimal/shows";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData("netflix", $"{URIPath}?available_on=netflix")]
        public void TestSyncCollectionMinimalShowsGetRequestHasValidURIPath(string? availableOn, string expectedURIPath)
        {
            var syncCollectionMinimalShowsGetRequest = new SyncCollectionMinimalShowsGetRequest
            {
                AvailableOn = availableOn
            };

            syncCollectionMinimalShowsGetRequest.BuildUri();
            syncCollectionMinimalShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncCollectionMinimalShowsGetRequestHasValidOAuthRequirement()
        {
            var syncCollectionMinimalShowsGetRequest = new SyncCollectionMinimalShowsGetRequest();
            syncCollectionMinimalShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncCollectionMinimalShowsGetRequestIsGetRequest()
        {
            var syncCollectionMinimalShowsGetRequest = new SyncCollectionMinimalShowsGetRequest();
            syncCollectionMinimalShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncCollectionMinimalShowsGetRequestHasCorrectRequestObjectType()
        {
            var syncCollectionMinimalShowsGetRequest = new SyncCollectionMinimalShowsGetRequest();
            syncCollectionMinimalShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
