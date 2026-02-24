#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowNextEpisodeGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
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
            showNextEpisodeGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowNextEpisodeGetRequestHasValidOAuthRequirement()
        {
            var showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest { Id = ShowID };
            showNextEpisodeGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowNextEpisodeGetRequestIsGetRequest()
        {
            var showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest { Id = ShowID };
            showNextEpisodeGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestShowNextEpisodeGetRequestHasCorrectRequestObjectType()
        {
            var showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest { Id = ShowID };
            showNextEpisodeGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowNextEpisodeGetRequestValidate()
        {
            var showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest { Id = string.Empty };

            Action act = () => showNextEpisodeGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest { Id = "  " };

            act = () => showNextEpisodeGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showNextEpisodeGetRequest = new ShowNextEpisodeGetRequest { Id = "id with spaces" };

            act = () => showNextEpisodeGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
