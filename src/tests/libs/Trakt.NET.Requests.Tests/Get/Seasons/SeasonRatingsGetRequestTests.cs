#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonRatingsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/seasons/1/ratings";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.All, $"{URIPath}?extended=all")]
        public void TestSeasonRatingsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedUri)
        {
            var seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                ExtendedInfo = extendedInfo,
            };

            seasonRatingsGetRequest.BuildUri();
            seasonRatingsGetRequest.RequestUri.ShouldBe(new Uri(expectedUri, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonRatingsGetRequestHasValidOAuthRequirement()
        {
            var seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonRatingsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonRatingsGetRequestIsGetRequest()
        {
            var seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonRatingsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSeasonRatingsGetRequestHasCorrectRequestObjectType()
        {
            var seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonRatingsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Season);
        }

        [Fact]
        public void TestSeasonRatingsGetRequestValidate()
        {
            var seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1
            };

            Action act = () => seasonRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1
            };

            act = () => seasonRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1
            };

            act = () => seasonRatingsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0
            };

            act = () => seasonRatingsGetRequest.Validate();
            act.ShouldNotThrow();
        }
    }
}
