#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Sync
{
    public sealed class SyncPlaybackDeleteRequestTests
    {
        private const string URIPath = "sync/playback/123";

        [Fact]
        public void TestSyncPlaybackDeleteRequestHasValidURIPath()
        {
            var syncPlaybackDeleteRequest = new SyncPlaybackDeleteRequest
            {
                Id = "123"
            };

            syncPlaybackDeleteRequest.BuildUri();
            syncPlaybackDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSyncPlaybackDeleteRequestHasValidOAuthRequirement()
        {
            var syncPlaybackDeleteRequest = new SyncPlaybackDeleteRequest { Id = default! };
            syncPlaybackDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestSyncPlaybackDeleteRequestIsDeleteRequest()
        {
            var syncPlaybackDeleteRequest = new SyncPlaybackDeleteRequest { Id = default! };
            syncPlaybackDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestSyncPlaybackDeleteRequestHasCorrectRequestObjectType()
        {
            var syncPlaybackDeleteRequest = new SyncPlaybackDeleteRequest { Id = default! };
            syncPlaybackDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSyncPlaybackDeleteRequestValidate()
        {
            var syncPlaybackDeleteRequest = new SyncPlaybackDeleteRequest { Id = string.Empty };
            Action act = () => syncPlaybackDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            syncPlaybackDeleteRequest = new SyncPlaybackDeleteRequest { Id = "  " };
            act = () => syncPlaybackDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            syncPlaybackDeleteRequest = new SyncPlaybackDeleteRequest { Id = "id with spaces" };
            act = () => syncPlaybackDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
