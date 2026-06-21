#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonsAllGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/seasons";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestSeasonsAllGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var seasonsAllGetRequest = new SeasonsAllGetRequest
            {
                ShowId = ShowID,
                ExtendedInfo = extendedInfo
            };

            seasonsAllGetRequest.BuildUri();
            seasonsAllGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonsAllGetRequestHasValidOAuthRequirement()
        {
            var seasonsAllGetRequest = new SeasonsAllGetRequest { ShowId = ShowID };
            seasonsAllGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonsAllGetRequestIsGetRequest()
        {
            var seasonsAllGetRequest = new SeasonsAllGetRequest { ShowId = ShowID };
            seasonsAllGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSeasonsAllGetRequestHasCorrectRequestObjectType()
        {
            var seasonsAllGetRequest = new SeasonsAllGetRequest { ShowId = ShowID };
            seasonsAllGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Season);
        }

        [Fact]
        public void TestSeasonsAllGetRequestValidate()
        {
            var seasonsAllGetRequest = new SeasonsAllGetRequest { ShowId = string.Empty };
            Action act = () => seasonsAllGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonsAllGetRequest = new SeasonsAllGetRequest { ShowId = "  " };
            act = () => seasonsAllGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            seasonsAllGetRequest = new SeasonsAllGetRequest { ShowId = "id with spaces" };
            act = () => seasonsAllGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
