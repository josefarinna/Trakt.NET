#if TRAKT_OLDER_NET_TARGETS
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonTranslationsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
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
            seasonTranslationsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonTranslationsGetRequestHasValidOAuthRequirement()
        {
            var seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonTranslationsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonTranslationsGetRequestIsGetRequest()
        {
            var seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonTranslationsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestSeasonTranslationsGetRequestHasCorrectRequestObjectType()
        {
            var seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonTranslationsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Season);
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
            act.Should().Throw<TraktRequestValidationException>();

            seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1
            };

            act = () => seasonTranslationsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1
            };

            act = () => seasonTranslationsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            seasonTranslationsGetRequest = new SeasonTranslationsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0
            };

            act = () => seasonTranslationsGetRequest.Validate();
            act.Should().NotThrow();
        }
    }
}
