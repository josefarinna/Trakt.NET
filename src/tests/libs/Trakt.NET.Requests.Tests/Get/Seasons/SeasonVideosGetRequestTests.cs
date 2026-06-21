#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonVideosGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/seasons/1/videos";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestSeasonVideosGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var seasonVideosGetRequest = new SeasonVideosGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                ExtendedInfo = extendedInfo
            };

            seasonVideosGetRequest.BuildUri();
            seasonVideosGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonVideosGetRequestHasValidOAuthRequirement()
        {
            var seasonVideosGetRequest = new SeasonVideosGetRequest { ShowId = default!, SeasonNumber = default! };
            seasonVideosGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonVideosGetRequestIsGetRequest()
        {
            var seasonVideosGetRequest = new SeasonVideosGetRequest { ShowId = default!, SeasonNumber = default! };
            seasonVideosGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSeasonVideosGetRequestHasCorrectRequestObjectType()
        {
            var seasonVideosGetRequest = new SeasonVideosGetRequest { ShowId = default!, SeasonNumber = default! };
            seasonVideosGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Season);
        }

        [Fact]
        public void TestSeasonVideosGetRequestValidate()
        {
            var seasonVideosGetRequest = new SeasonVideosGetRequest { ShowId = string.Empty, SeasonNumber = default! };
            Action act = () => seasonVideosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonVideosGetRequest = new SeasonVideosGetRequest { ShowId = "  ", SeasonNumber = default! };
            act = () => seasonVideosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonVideosGetRequest = new SeasonVideosGetRequest { ShowId = "id with spaces", SeasonNumber = default! };
            act = () => seasonVideosGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
