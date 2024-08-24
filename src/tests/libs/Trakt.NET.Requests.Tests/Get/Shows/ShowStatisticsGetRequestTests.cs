#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowStatisticsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/stats";

        [Fact]
        public void TestShowStatisticsGetRequestHasValidURIPath()
        {
            var showStatisticsGetRequest = new ShowStatisticsGetRequest { Id = ShowID };

            showStatisticsGetRequest.BuildUri();
            showStatisticsGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowStatisticsGetRequestHasValidOAuthRequirement()
        {
            var showStatisticsGetRequest = new ShowStatisticsGetRequest { Id = ShowID };
            showStatisticsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowStatisticsGetRequestIsGetRequest()
        {
            var showStatisticsGetRequest = new ShowStatisticsGetRequest { Id = ShowID };
            showStatisticsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestShowStatisticsGetRequestHasCorrectRequestObjectType()
        {
            var showStatisticsGetRequest = new ShowStatisticsGetRequest { Id = ShowID };
            showStatisticsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowStatisticsGetRequestValidate()
        {
            var showStatisticsGetRequest = new ShowStatisticsGetRequest { Id = string.Empty };

            Action act = () => showStatisticsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showStatisticsGetRequest = new ShowStatisticsGetRequest { Id = "  " };

            act = () => showStatisticsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showStatisticsGetRequest = new ShowStatisticsGetRequest { Id = "id with spaces" };

            act = () => showStatisticsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
