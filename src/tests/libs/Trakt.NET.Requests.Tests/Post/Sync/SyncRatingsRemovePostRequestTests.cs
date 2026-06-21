#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Sync
{
    public sealed class SyncRatingsRemovePostRequestTests
    {
        private const string URIPath = "sync/ratings/remove";

        [Fact]
        public void TestSyncRatingsRemovePostRequestHasValidURIPath()
        {
            var syncRatingsRemovePostRequest = new SyncRatingsRemovePostRequest
            {
                TraktSyncRatingsRemovePost = new TraktSyncRatingsRemovePost()
            };

            syncRatingsRemovePostRequest.BuildUri();
            syncRatingsRemovePostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncRatingsRemovePostRequestHasValidOAuthRequirement()
        {
            var syncRatingsRemovePostRequest = new SyncRatingsRemovePostRequest { TraktSyncRatingsRemovePost = default! };
            syncRatingsRemovePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncRatingsRemovePostRequestIsPostRequest()
        {
            var syncRatingsRemovePostRequest = new SyncRatingsRemovePostRequest { TraktSyncRatingsRemovePost = default! };
            syncRatingsRemovePostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSyncRatingsRemovePostRequestHasCorrectRequestObjectType()
        {
            var syncRatingsRemovePostRequest = new SyncRatingsRemovePostRequest { TraktSyncRatingsRemovePost = default! };
            syncRatingsRemovePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncRatingsRemovePostRequestValidate()
        {
            var syncRatingsRemovePostRequest = new SyncRatingsRemovePostRequest { TraktSyncRatingsRemovePost = default! };
            Action act = () => syncRatingsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
