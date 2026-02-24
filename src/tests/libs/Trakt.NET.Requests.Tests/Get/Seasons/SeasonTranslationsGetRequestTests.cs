#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonTranslationsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/seasons/1/translations";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData("", URIPath)]
        [InlineData(" ", URIPath)]
        [InlineData("en", $"{URIPath}/en")]
        public void TestSeasonTranslationsGetRequestHasValidURIPath(string? language, string expectedURIPath)
        {
            var seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                Language = language
            };

            seasonTranslationsGetRequest.BuildUri();
            seasonTranslationsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonTranslationsGetRequestHasValidOAuthRequirement()
        {
            var seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonTranslationsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonTranslationsGetRequestIsGetRequest()
        {
            var seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonTranslationsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSeasonTranslationsGetRequestHasCorrectRequestObjectType()
        {
            var seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonTranslationsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Season);
        }

        [Fact]
        public void TestSeasonTranslationsGetRequestValidate()
        {
            var seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1
            };

            Action act = () => seasonTranslationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1
            };

            act = () => seasonTranslationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1
            };

            act = () => seasonTranslationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0
            };

            act = () => seasonTranslationsGetRequest.Validate();
            act.ShouldNotThrow();
        }
    }
}
