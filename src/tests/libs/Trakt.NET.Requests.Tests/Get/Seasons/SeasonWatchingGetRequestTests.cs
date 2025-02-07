#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonWatchingGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/watching";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.VIP | TraktExtendedInfo.Full, $"{URIPath}?extended=full,vip")]
        public void TestSeasonWatchingGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var seasonWatchingGetRequest = new SeasonWatchingGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                ExtendedInfo = extendedInfo
            };

            seasonWatchingGetRequest.BuildUri();
            seasonWatchingGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonWatchingGetRequestHasValidOAuthRequirement()
        {
            var seasonWatchingGetRequest = new SeasonWatchingGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonWatchingGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonWatchingGetRequestIsGetRequest()
        {
            var seasonWatchingGetRequest = new SeasonWatchingGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonWatchingGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSeasonWatchingGetRequestHasCorrectRequestObjectType()
        {
            var seasonWatchingGetRequest = new SeasonWatchingGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonWatchingGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Season);
        }

        [Fact]
        public void TestSeasonWatchingGetRequestValidate()
        {
            var seasonWatchingGetRequest = new SeasonWatchingGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1
            };

            Action act = () => seasonWatchingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonWatchingGetRequest = new SeasonWatchingGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1
            };

            act = () => seasonWatchingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonWatchingGetRequest = new SeasonWatchingGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1
            };

            act = () => seasonWatchingGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonWatchingGetRequest = new SeasonWatchingGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0
            };

            act = () => seasonWatchingGetRequest.Validate();
            act.ShouldNotThrow();
        }
    }
}
