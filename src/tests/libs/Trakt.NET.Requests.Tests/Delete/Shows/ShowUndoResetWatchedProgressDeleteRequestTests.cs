#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Shows
{
    public sealed class ShowUndoResetWatchedProgressDeleteRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/progress/watched/reset";

        [Fact]
        public void TestShowUndoResetWatchedProgressDeleteRequestHasValidURIPath()
        {
            var showUndoResetWatchedProgressDeleteRequest = new ShowUndoResetWatchedProgressDeleteRequest
            {
                Id = ShowID
            };

            showUndoResetWatchedProgressDeleteRequest.BuildUri();
            showUndoResetWatchedProgressDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowUndoResetWatchedProgressDeleteRequestHasValidOAuthRequirement()
        {
            var showUndoResetWatchedProgressDeleteRequest = new ShowUndoResetWatchedProgressDeleteRequest { Id = ShowID };
            showUndoResetWatchedProgressDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestShowUndoResetWatchedProgressDeleteRequestIsDeleteRequest()
        {
            var showUndoResetWatchedProgressDeleteRequest = new ShowUndoResetWatchedProgressDeleteRequest { Id = ShowID };
            showUndoResetWatchedProgressDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestShowUndoResetWatchedProgressDeleteRequestHasCorrectRequestObjectType()
        {
            var showUndoResetWatchedProgressDeleteRequest = new ShowUndoResetWatchedProgressDeleteRequest { Id = ShowID };
            showUndoResetWatchedProgressDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowUndoResetWatchedProgressDeleteRequestValidate()
        {
            var showUndoResetWatchedProgressDeleteRequest = new ShowUndoResetWatchedProgressDeleteRequest { Id = string.Empty };
            Action act = () => showUndoResetWatchedProgressDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showUndoResetWatchedProgressDeleteRequest = new ShowUndoResetWatchedProgressDeleteRequest { Id = "  " };
            act = () => showUndoResetWatchedProgressDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showUndoResetWatchedProgressDeleteRequest = new ShowUndoResetWatchedProgressDeleteRequest { Id = "id with spaces" };
            act = () => showUndoResetWatchedProgressDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
