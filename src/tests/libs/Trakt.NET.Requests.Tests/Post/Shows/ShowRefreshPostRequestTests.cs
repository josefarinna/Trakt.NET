#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Shows
{
    public sealed class ShowRefreshPostRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/refresh";

        [Fact]
        public void TestShowRefreshPostRequestHasValidURIPath()
        {
            var showRefreshPostRequest = new ShowRefreshPostRequest
            {
                Id = ShowID
            };

            showRefreshPostRequest.BuildUri();
            showRefreshPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowRefreshPostRequestHasValidOAuthRequirement()
        {
            var showRefreshPostRequest = new ShowRefreshPostRequest { Id = ShowID };
            showRefreshPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestShowRefreshPostRequestIsPostRequest()
        {
            var showRefreshPostRequest = new ShowRefreshPostRequest { Id = ShowID };
            showRefreshPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestShowRefreshPostRequestHasCorrectRequestObjectType()
        {
            var showRefreshPostRequest = new ShowRefreshPostRequest { Id = ShowID };
            showRefreshPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowRefreshPostRequestValidate()
        {
            var showRefreshPostRequest = new ShowRefreshPostRequest { Id = string.Empty };
            Action act = () => showRefreshPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showRefreshPostRequest = new ShowRefreshPostRequest { Id = "  " };
            act = () => showRefreshPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showRefreshPostRequest = new ShowRefreshPostRequest { Id = "id with spaces" };
            act = () => showRefreshPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
