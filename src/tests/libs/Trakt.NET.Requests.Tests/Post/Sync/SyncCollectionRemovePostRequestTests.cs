#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Sync
{
    public sealed class SyncCollectionRemovePostRequestTests
    {
        private const string URIPath = "sync/collection/remove";

        [Fact]
        public void TestSyncCollectionRemovePostRequestHasValidURIPath()
        {
            var syncCollectionRemovePostRequest = new SyncCollectionRemovePostRequest
            {
                TraktSyncCollectionRemovePost = new TraktSyncCollectionRemovePost()
            };

            syncCollectionRemovePostRequest.BuildUri();
            syncCollectionRemovePostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncCollectionRemovePostRequestHasValidOAuthRequirement()
        {
            var syncCollectionRemovePostRequest = new SyncCollectionRemovePostRequest { TraktSyncCollectionRemovePost = default! };
            syncCollectionRemovePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncCollectionRemovePostRequestIsPostRequest()
        {
            var syncCollectionRemovePostRequest = new SyncCollectionRemovePostRequest { TraktSyncCollectionRemovePost = default! };
            syncCollectionRemovePostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSyncCollectionRemovePostRequestHasCorrectRequestObjectType()
        {
            var syncCollectionRemovePostRequest = new SyncCollectionRemovePostRequest { TraktSyncCollectionRemovePost = default! };
            syncCollectionRemovePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncCollectionRemovePostRequestValidate()
        {
            var syncCollectionRemovePostRequest = new SyncCollectionRemovePostRequest { TraktSyncCollectionRemovePost = default! };
            Action act = () => syncCollectionRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
