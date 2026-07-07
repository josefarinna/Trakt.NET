#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodeWatchnowGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string Country = "us";
        private const string URIPath = $"shows/{ShowID}/seasons/1/episodes/2/watchnow/{Country}";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(true, null, $"{URIPath}?links=true")]
        [InlineData(false, null, $"{URIPath}?links=false")]
        [InlineData(null, TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        [InlineData(true, TraktExtendedInfo.Full, $"{URIPath}?links=true&extended=full")]
        public void TestEpisodeWatchnowGetRequestHasValidURIPath(bool? links, TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var request = new EpisodeWatchnowGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 2,
                Country = Country,
                Links = links,
                ExtendedInfo = extendedInfo
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodeWatchnowGetRequestHasValidOAuthRequirement()
        {
            var request = new EpisodeWatchnowGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 2,
                Country = Country
            };

            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestEpisodeWatchnowGetRequestIsGetRequest()
        {
            var request = new EpisodeWatchnowGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 2,
                Country = Country
            };

            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestEpisodeWatchnowGetRequestHasCorrectRequestObjectType()
        {
            var request = new EpisodeWatchnowGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 2,
                Country = Country
            };

            request.RequestObjectType.ShouldBe(TraktRequestObjectType.Episode);
        }

        [Fact]
        public void TestEpisodeWatchnowGetRequestValidate()
        {
            var request = new EpisodeWatchnowGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1,
                EpisodeNumber = 2,
                Country = Country
            };

            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new EpisodeWatchnowGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1,
                EpisodeNumber = 2,
                Country = Country
            };

            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new EpisodeWatchnowGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1,
                EpisodeNumber = 2,
                Country = Country
            };

            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new EpisodeWatchnowGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0,
                EpisodeNumber = 2,
                Country = Country
            };

            act = () => request.Validate();
            act.ShouldNotThrow();

            request = new EpisodeWatchnowGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 0,
                Country = Country
            };

            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new EpisodeWatchnowGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 2,
                Country = string.Empty
            };

            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new EpisodeWatchnowGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 2,
                Country = "  "
            };

            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new EpisodeWatchnowGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 2,
                Country = "country with spaces"
            };

            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
