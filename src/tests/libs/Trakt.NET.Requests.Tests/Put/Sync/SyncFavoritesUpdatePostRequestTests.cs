#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PutRequests.Sync
{
    public sealed class SyncFavoritesUpdatePostRequestTests
    {
        private const string URIPath = "sync/favorites";

        [Fact]
        public void TestSyncFavoritesUpdatePostRequestHasValidURIPath()
        {
            var syncFavoritesUpdatePostRequest = new SyncFavoritesUpdatePostRequest
            {
                TraktUpdateListPost = new TraktUpdateListPost()
            };

            syncFavoritesUpdatePostRequest.BuildUri();
            syncFavoritesUpdatePostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncFavoritesUpdatePostRequestHasValidOAuthRequirement()
        {
            var syncFavoritesUpdatePostRequest = new SyncFavoritesUpdatePostRequest { TraktUpdateListPost = default! };
            syncFavoritesUpdatePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncFavoritesUpdatePostRequestIsPutRequest()
        {
            var syncFavoritesUpdatePostRequest = new SyncFavoritesUpdatePostRequest { TraktUpdateListPost = default! };
            syncFavoritesUpdatePostRequest.Method.ShouldBe(HttpMethod.Put);
        }

        [Fact]
        public void TestSyncFavoritesUpdatePostRequestHasCorrectRequestObjectType()
        {
            var syncFavoritesUpdatePostRequest = new SyncFavoritesUpdatePostRequest { TraktUpdateListPost = default! };
            syncFavoritesUpdatePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncFavoritesUpdatePostRequestValidate()
        {
            var syncFavoritesUpdatePostRequest = new SyncFavoritesUpdatePostRequest { TraktUpdateListPost = default! };
            Action act = () => syncFavoritesUpdatePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
