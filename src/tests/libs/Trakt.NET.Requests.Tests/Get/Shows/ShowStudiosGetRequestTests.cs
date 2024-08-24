#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowStudiosGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/studios";

        [Fact]
        public void TestShowStudiosGetRequestHasValidURIPath()
        {
            var showStudiosGetRequest = new ShowStudiosGetRequest { Id = ShowID };

            showStudiosGetRequest.BuildUri();
            showStudiosGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowStudiosGetRequestHasValidOAuthRequirement()
        {
            var showStudiosGetRequest = new ShowStudiosGetRequest { Id = ShowID };
            showStudiosGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowStudiosGetRequestIsGetRequest()
        {
            var showStudiosGetRequest = new ShowStudiosGetRequest { Id = ShowID };
            showStudiosGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestShowStudiosGetRequestHasCorrectRequestObjectType()
        {
            var showStudiosGetRequest = new ShowStudiosGetRequest { Id = ShowID };
            showStudiosGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowStudiosGetRequestValidate()
        {
            var showStudiosGetRequest = new ShowStudiosGetRequest { Id = string.Empty };

            Action act = () => showStudiosGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showStudiosGetRequest = new ShowStudiosGetRequest { Id = "  " };

            act = () => showStudiosGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showStudiosGetRequest = new ShowStudiosGetRequest { Id = "id with spaces" };

            act = () => showStudiosGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
