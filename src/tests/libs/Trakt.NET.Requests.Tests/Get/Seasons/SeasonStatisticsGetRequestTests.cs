#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonStatisticsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/stats";

        [Fact]
        public void TestSeasonStatisticsGetRequestHasValidURIPath()
        {
            var seasonStatisticsGetRequest = new SeasonStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonStatisticsGetRequest.BuildUri();
            seasonStatisticsGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonStatisticsGetRequestHasValidOAuthRequirement()
        {
            var seasonStatisticsGetRequest = new SeasonStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonStatisticsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonStatisticsGetRequestIsGetRequest()
        {
            var seasonStatisticsGetRequest = new SeasonStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonStatisticsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSeasonStatisticsGetRequestHasCorrectRequestObjectType()
        {
            var seasonStatisticsGetRequest = new SeasonStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonStatisticsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Season);
        }

        [Fact]
        public void TestSeasonStatisticsGetRequestValidate()
        {
            var seasonStatisticsGetRequest = new SeasonStatisticsGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1
            };

            Action act = () => seasonStatisticsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonStatisticsGetRequest = new SeasonStatisticsGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1
            };

            act = () => seasonStatisticsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonStatisticsGetRequest = new SeasonStatisticsGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1
            };

            act = () => seasonStatisticsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonStatisticsGetRequest = new SeasonStatisticsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0
            };

            act = () => seasonStatisticsGetRequest.Validate();
            act.ShouldNotThrow();
        }
    }
}
