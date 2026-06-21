#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Sync
{
    public sealed class SyncCollectionAddPostRequestTests
    {
        private const string URIPath = "sync/collection";

        [Fact]
        public void TestSyncCollectionAddPostRequestHasValidURIPath()
        {
            var syncCollectionAddPostRequest = new SyncCollectionAddPostRequest
            {
                TraktSyncCollectionPost = new TraktSyncCollectionPost()
            };

            syncCollectionAddPostRequest.BuildUri();
            syncCollectionAddPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncCollectionAddPostRequestHasValidOAuthRequirement()
        {
            var syncCollectionAddPostRequest = new SyncCollectionAddPostRequest { TraktSyncCollectionPost = default! };
            syncCollectionAddPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncCollectionAddPostRequestIsPostRequest()
        {
            var syncCollectionAddPostRequest = new SyncCollectionAddPostRequest { TraktSyncCollectionPost = default! };
            syncCollectionAddPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSyncCollectionAddPostRequestHasCorrectRequestObjectType()
        {
            var syncCollectionAddPostRequest = new SyncCollectionAddPostRequest { TraktSyncCollectionPost = default! };
            syncCollectionAddPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncCollectionAddPostRequestValidate()
        {
            var syncCollectionAddPostRequest = new SyncCollectionAddPostRequest { TraktSyncCollectionPost = default! };
            Action act = () => syncCollectionAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
