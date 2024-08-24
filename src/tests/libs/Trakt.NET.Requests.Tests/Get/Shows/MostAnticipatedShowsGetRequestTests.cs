#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class MostAnticipatedShowsGetRequestTests
    {
        private const string URIPath = $"shows/anticipated";

        [Theory]
        [InlineData(null, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        public void TestMostAnticipatedShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var mostAnticipatedShowsGetRequest = new MostAnticipatedShowsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            mostAnticipatedShowsGetRequest.BuildUri();
            mostAnticipatedShowsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMostAnticipatedShowsGetRequestHasValidOAuthRequirement()
        {
            var mostAnticipatedShowsGetRequest = new MostAnticipatedShowsGetRequest();
            mostAnticipatedShowsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMostAnticipatedShowsGetRequestIsGetRequest()
        {
            var mostAnticipatedShowsGetRequest = new MostAnticipatedShowsGetRequest();
            mostAnticipatedShowsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestMostAnticipatedShowsGetRequestHasCorrectRequestObjectType()
        {
            var mostAnticipatedShowsGetRequest = new MostAnticipatedShowsGetRequest();
            mostAnticipatedShowsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.None);
        }
    }
}
