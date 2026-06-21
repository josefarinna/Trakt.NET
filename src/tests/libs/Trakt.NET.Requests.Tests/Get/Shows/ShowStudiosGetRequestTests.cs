#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowStudiosGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/studios";

        [Fact]
        public void TestShowStudiosGetRequestHasValidURIPath()
        {
            var showStudiosGetRequest = new ShowStudiosGetRequest { Id = ShowID };

            showStudiosGetRequest.BuildUri();
            showStudiosGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowStudiosGetRequestHasValidOAuthRequirement()
        {
            var showStudiosGetRequest = new ShowStudiosGetRequest { Id = ShowID };
            showStudiosGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowStudiosGetRequestIsGetRequest()
        {
            var showStudiosGetRequest = new ShowStudiosGetRequest { Id = ShowID };
            showStudiosGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestShowStudiosGetRequestHasCorrectRequestObjectType()
        {
            var showStudiosGetRequest = new ShowStudiosGetRequest { Id = ShowID };
            showStudiosGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowStudiosGetRequestValidate()
        {
            var showStudiosGetRequest = new ShowStudiosGetRequest { Id = string.Empty };
            Action act = () => showStudiosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showStudiosGetRequest = new ShowStudiosGetRequest { Id = "  " };
            act = () => showStudiosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showStudiosGetRequest = new ShowStudiosGetRequest { Id = "id with spaces" };
            act = () => showStudiosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
