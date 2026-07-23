#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowSentimentsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/sentiments";

        [Fact]
        public void TestShowSentimentsGetRequestHasValidURIPath()
        {
            var showSentimentsGetRequest = new ShowSentimentsGetRequest { Id = ShowID };

            showSentimentsGetRequest.BuildUri();
            showSentimentsGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowSentimentsGetRequestHasValidOAuthRequirement()
        {
            var showSentimentsGetRequest = new ShowSentimentsGetRequest { Id = ShowID };
            showSentimentsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowSentimentsGetRequestIsGetRequest()
        {
            var showSentimentsGetRequest = new ShowSentimentsGetRequest { Id = ShowID };
            showSentimentsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestShowSentimentsGetRequestHasCorrectRequestObjectType()
        {
            var showSentimentsGetRequest = new ShowSentimentsGetRequest { Id = ShowID };
            showSentimentsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowSentimentsGetRequestValidate()
        {
            var showSentimentsGetRequest = new ShowSentimentsGetRequest { Id = string.Empty };
            Action act = () => showSentimentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showSentimentsGetRequest = new ShowSentimentsGetRequest { Id = "  " };
            act = () => showSentimentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showSentimentsGetRequest = new ShowSentimentsGetRequest { Id = "id with spaces" };
            act = () => showSentimentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
