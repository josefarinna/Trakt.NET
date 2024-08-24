#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowRatingsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/ratings";

        [Fact]
        public void TestShowRatingsGetRequestHasValidURIPath()
        {
            var showRatingsGetRequest = new ShowRatingsGetRequest { Id = ShowID };

            showRatingsGetRequest.BuildUri();
            showRatingsGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowRatingsGetRequestHasValidOAuthRequirement()
        {
            var showRatingsGetRequest = new ShowRatingsGetRequest { Id = ShowID };
            showRatingsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowRatingsGetRequestIsGetRequest()
        {
            var showRatingsGetRequest = new ShowRatingsGetRequest { Id = ShowID };
            showRatingsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestShowRatingsGetRequestHasCorrectRequestObjectType()
        {
            var showRatingsGetRequest = new ShowRatingsGetRequest { Id = ShowID };
            showRatingsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowRatingsGetRequestValidate()
        {
            var showRatingsGetRequest = new ShowRatingsGetRequest { Id = string.Empty };

            Action act = () => showRatingsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showRatingsGetRequest = new ShowRatingsGetRequest { Id = "  " };

            act = () => showRatingsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showRatingsGetRequest = new ShowRatingsGetRequest { Id = "id with spaces" };

            act = () => showRatingsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
