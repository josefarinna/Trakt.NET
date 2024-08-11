#if TRAKT_OLDER_NET_TARGETS
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowNextEpisodeGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/next_episode";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestShowNextEpisodeGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest
            {
                Id = ShowID,
                ExtendedInfo = extendedInfo
            };

            showNextEpisodeGetRequest.BuildUri();
            showNextEpisodeGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowNextEpisodeGetRequestHasValidOAuthRequirement()
        {
            var showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest { Id = ShowID };
            showNextEpisodeGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowNextEpisodeGetRequestIsGetRequest()
        {
            var showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest { Id = ShowID };
            showNextEpisodeGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestShowNextEpisodeGetRequestHasCorrectRequestObjectType()
        {
            var showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest { Id = ShowID };
            showNextEpisodeGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowNextEpisodeGetRequestValidate()
        {
            var showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest { Id = string.Empty };

            Action act = () => showNextEpisodeGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest { Id = "  " };

            act = () => showNextEpisodeGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest { Id = "id with spaces" };

            act = () => showNextEpisodeGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
