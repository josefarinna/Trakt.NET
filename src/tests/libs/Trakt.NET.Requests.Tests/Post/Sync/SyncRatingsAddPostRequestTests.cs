#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Sync
{
    public sealed class SyncRatingsAddPostRequestTests
    {
        private const string URIPath = "sync/ratings";

        [Fact]
        public void TestSyncRatingsAddPostRequestHasValidURIPath()
        {
            var syncRatingsAddPostRequest = new SyncRatingsAddPostRequest
            {
                TraktSyncRatingsPost = new TraktSyncRatingsPost()
            };

            syncRatingsAddPostRequest.BuildUri();
            syncRatingsAddPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncRatingsAddPostRequestHasValidOAuthRequirement()
        {
            var syncRatingsAddPostRequest = new SyncRatingsAddPostRequest { TraktSyncRatingsPost = default! };
            syncRatingsAddPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncRatingsAddPostRequestIsPostRequest()
        {
            var syncRatingsAddPostRequest = new SyncRatingsAddPostRequest { TraktSyncRatingsPost = default! };
            syncRatingsAddPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSyncRatingsAddPostRequestHasCorrectRequestObjectType()
        {
            var syncRatingsAddPostRequest = new SyncRatingsAddPostRequest { TraktSyncRatingsPost = default! };
            syncRatingsAddPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncRatingsAddPostRequestValidate()
        {
            var syncRatingsAddPostRequest = new SyncRatingsAddPostRequest { TraktSyncRatingsPost = default! };
            Action act = () => syncRatingsAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
