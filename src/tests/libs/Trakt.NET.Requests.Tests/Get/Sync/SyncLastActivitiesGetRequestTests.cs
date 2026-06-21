#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Sync
{
    public sealed class SyncLastActivitiesGetRequestTests
    {
        private const string URIPath = "sync/last_activities";

        [Fact]
        public void TestSyncLastActivitiesGetRequestHasValidURIPath()
        {
            var syncLastActivitiesGetRequest = new SyncLastActivitiesGetRequest();

            syncLastActivitiesGetRequest.BuildUri();
            syncLastActivitiesGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncLastActivitiesGetRequestHasValidOAuthRequirement()
        {
            var syncLastActivitiesGetRequest = new SyncLastActivitiesGetRequest();
            syncLastActivitiesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncLastActivitiesGetRequestIsGetRequest()
        {
            var syncLastActivitiesGetRequest = new SyncLastActivitiesGetRequest();
            syncLastActivitiesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSyncLastActivitiesGetRequestHasCorrectRequestObjectType()
        {
            var syncLastActivitiesGetRequest = new SyncLastActivitiesGetRequest();
            syncLastActivitiesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
