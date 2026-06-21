#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Sync
{
    public sealed class SyncFavoritedItemsReorderPostRequestTests
    {
        private const string URIPath = "sync/favorites/reorder";

        [Fact]
        public void TestSyncFavoritedItemsReorderPostRequestHasValidURIPath()
        {
            var syncFavoritedItemsReorderPostRequest = new SyncFavoritedItemsReorderPostRequest
            {
                TraktListItemsReorderPost = new TraktListItemsReorderPost()
            };

            syncFavoritedItemsReorderPostRequest.BuildUri();
            syncFavoritedItemsReorderPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncFavoritedItemsReorderPostRequestHasValidOAuthRequirement()
        {
            var syncFavoritedItemsReorderPostRequest = new SyncFavoritedItemsReorderPostRequest { TraktListItemsReorderPost = default! };
            syncFavoritedItemsReorderPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncFavoritedItemsReorderPostRequestIsPostRequest()
        {
            var syncFavoritedItemsReorderPostRequest = new SyncFavoritedItemsReorderPostRequest { TraktListItemsReorderPost = default! };
            syncFavoritedItemsReorderPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestSyncFavoritedItemsReorderPostRequestHasCorrectRequestObjectType()
        {
            var syncFavoritedItemsReorderPostRequest = new SyncFavoritedItemsReorderPostRequest { TraktListItemsReorderPost = default! };
            syncFavoritedItemsReorderPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncFavoritedItemsReorderPostRequestValidate()
        {
            var syncFavoritedItemsReorderPostRequest = new SyncFavoritedItemsReorderPostRequest { TraktListItemsReorderPost = default! };
            Action act = () => syncFavoritedItemsReorderPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
