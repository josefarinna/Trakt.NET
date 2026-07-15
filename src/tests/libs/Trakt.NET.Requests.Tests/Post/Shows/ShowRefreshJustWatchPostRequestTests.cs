#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Shows
{
    public sealed class ShowRefreshJustWatchPostRequestTests
    {
        private const string URIPath = "shows/123/justwatch/refresh";

        [Fact]
        public void TestShowRefreshJustWatchPostRequestHasValidURIPath()
        {
            var showRefreshJustWatchPostRequest = new ShowRefreshJustWatchPostRequest
            {
                Id = "123"
            };

            showRefreshJustWatchPostRequest.BuildUri();
            showRefreshJustWatchPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowRefreshJustWatchPostRequestHasValidOAuthRequirement()
        {
            var showRefreshJustWatchPostRequest = new ShowRefreshJustWatchPostRequest { Id = default! };
            showRefreshJustWatchPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestShowRefreshJustWatchPostRequestIsPostRequest()
        {
            var showRefreshJustWatchPostRequest = new ShowRefreshJustWatchPostRequest { Id = default! };
            showRefreshJustWatchPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestShowRefreshJustWatchPostRequestHasCorrectRequestObjectType()
        {
            var showRefreshJustWatchPostRequest = new ShowRefreshJustWatchPostRequest { Id = default! };
            showRefreshJustWatchPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowRefreshJustWatchPostRequestValidate()
        {
            var showRefreshJustWatchPostRequest = new ShowRefreshJustWatchPostRequest { Id = string.Empty };
            Action act = () => showRefreshJustWatchPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showRefreshJustWatchPostRequest = new ShowRefreshJustWatchPostRequest { Id = "  " };
            act = () => showRefreshJustWatchPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showRefreshJustWatchPostRequest = new ShowRefreshJustWatchPostRequest { Id = "id with spaces" };
            act = () => showRefreshJustWatchPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
