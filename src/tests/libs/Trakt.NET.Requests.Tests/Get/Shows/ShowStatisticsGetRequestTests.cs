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
    }
}
