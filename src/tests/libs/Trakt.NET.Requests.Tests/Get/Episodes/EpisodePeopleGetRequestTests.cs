#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Episodes
{
    public sealed class EpisodePeopleGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/episodes/1/people";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestEpisodePeopleGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var episodePeopleGetRequest = new EpisodePeopleGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1,
                ExtendedInfo = extendedInfo
            };

            episodePeopleGetRequest.BuildUri();
            episodePeopleGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestEpisodePeopleGetRequestHasValidOAuthRequirement()
        {
            var episodePeopleGetRequest = new EpisodePeopleGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodePeopleGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestEpisodePeopleGetRequestIsGetRequest()
        {
            var episodePeopleGetRequest = new EpisodePeopleGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodePeopleGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestEpisodePeopleGetRequestHasCorrectRequestObjectType()
        {
            var episodePeopleGetRequest = new EpisodePeopleGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            episodePeopleGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Episode);
        }

        [Fact]
        public void TestEpisodePeopleGetRequestValidate()
        {
            var episodePeopleGetRequest = new EpisodePeopleGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            Action act = () => episodePeopleGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            episodePeopleGetRequest = new EpisodePeopleGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodePeopleGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            episodePeopleGetRequest = new EpisodePeopleGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1,
                EpisodeNumber = 1
            };

            act = () => episodePeopleGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            episodePeopleGetRequest = new EpisodePeopleGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0,
                EpisodeNumber = 1
            };

            act = () => episodePeopleGetRequest.Validate();
            act.Should().NotThrow();

            episodePeopleGetRequest = new EpisodePeopleGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                EpisodeNumber = 0
            };

            act = () => episodePeopleGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
