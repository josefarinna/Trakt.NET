#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/info";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestSeasonGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var seasonGetRequest = new SeasonGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                ExtendedInfo = extendedInfo
            };

            seasonGetRequest.BuildUri();
            seasonGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonGetRequestHasValidOAuthRequirement()
        {
            var seasonGetRequest = new SeasonGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonGetRequestIsGetRequest()
        {
            var seasonGetRequest = new SeasonGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestSeasonGetRequestHasCorrectRequestObjectType()
        {
            var seasonGetRequest = new SeasonGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Season);
        }

        [Fact]
        public void TestSeasonGetRequestValidate()
        {
            var seasonGetRequest = new SeasonGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1
            };

            Action act = () => seasonGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            seasonGetRequest = new SeasonGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1
            };

            act = () => seasonGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            seasonGetRequest = new SeasonGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1
            };

            act = () => seasonGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            seasonGetRequest = new SeasonGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0
            };

            act = () => seasonGetRequest.Validate();
            act.Should().NotThrow();
        }
    }
}
