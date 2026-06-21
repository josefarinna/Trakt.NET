#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PutRequests.Sync
{
    public sealed class SyncFavoriteItemUpdatePostRequestTests
    {
        private const string URIPath = "sync/favorites/123";

        [Fact]
        public void TestSyncFavoriteItemUpdatePostRequestHasValidURIPath()
        {
            var syncFavoriteItemUpdatePostRequest = new SyncFavoriteItemUpdatePostRequest
            {
                ListItemId = 123U,
                TraktListItemUpdatePost = new TraktListItemUpdatePost()
            };

            syncFavoriteItemUpdatePostRequest.BuildUri();
            syncFavoriteItemUpdatePostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncFavoriteItemUpdatePostRequestHasValidOAuthRequirement()
        {
            var syncFavoriteItemUpdatePostRequest = new SyncFavoriteItemUpdatePostRequest();
            syncFavoriteItemUpdatePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncFavoriteItemUpdatePostRequestIsPutRequest()
        {
            var syncFavoriteItemUpdatePostRequest = new SyncFavoriteItemUpdatePostRequest();
            syncFavoriteItemUpdatePostRequest.Method.ShouldBe(HttpMethod.Put);
        }

        [Fact]
        public void TestSyncFavoriteItemUpdatePostRequestHasCorrectRequestObjectType()
        {
            var syncFavoriteItemUpdatePostRequest = new SyncFavoriteItemUpdatePostRequest();
            syncFavoriteItemUpdatePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncFavoriteItemUpdatePostRequestValidate()
        {
            var syncFavoriteItemUpdatePostRequest = new SyncFavoriteItemUpdatePostRequest { TraktListItemUpdatePost = default! };
            Action act = () => syncFavoriteItemUpdatePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
