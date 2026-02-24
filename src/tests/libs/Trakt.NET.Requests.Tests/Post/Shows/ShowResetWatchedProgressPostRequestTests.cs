#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Shows
{
    public sealed class ShowResetWatchedProgressPostRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/progress/watched/reset";

        [Fact]
        public void TestShowResetWatchedProgressPostRequestHasValidURIPath()
        {
            var showResetWatchedProgressPostRequest = new ShowResetWatchedProgressPostRequest
            {
                Id = ShowID
            };

            showResetWatchedProgressPostRequest.BuildUri();
            showResetWatchedProgressPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowResetWatchedProgressPostRequestHasValidOAuthRequirement()
        {
            var showResetWatchedProgressPostRequest = new ShowResetWatchedProgressPostRequest { Id = ShowID };
            showResetWatchedProgressPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestShowResetWatchedProgressPostRequestIsPostRequest()
        {
            var showResetWatchedProgressPostRequest = new ShowResetWatchedProgressPostRequest { Id = ShowID };
            showResetWatchedProgressPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestShowResetWatchedProgressPostRequestHasCorrectRequestObjectType()
        {
            var showResetWatchedProgressPostRequest = new ShowResetWatchedProgressPostRequest { Id = ShowID };
            showResetWatchedProgressPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowResetWatchedProgressPostRequestValidate()
        {
            var showResetWatchedProgressPostRequest = new ShowResetWatchedProgressPostRequest { Id = string.Empty };

            Action act = () => showResetWatchedProgressPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showResetWatchedProgressPostRequest = new ShowResetWatchedProgressPostRequest { Id = "  " };

            act = () => showResetWatchedProgressPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showResetWatchedProgressPostRequest = new ShowResetWatchedProgressPostRequest { Id = "id with spaces" };

            act = () => showResetWatchedProgressPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
