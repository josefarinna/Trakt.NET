#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Media
{
    public sealed class MediaPopularGetRequestTests
    {
        private const string URIPath = "media/popular";

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
        public void TestMediaPopularGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var mediaPopularGetRequest = new MediaPopularGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            mediaPopularGetRequest.BuildUri();
            mediaPopularGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMediaPopularGetRequestHasValidOAuthRequirement()
        {
            var mediaPopularGetRequest = new MediaPopularGetRequest();
            mediaPopularGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMediaPopularGetRequestIsGetRequest()
        {
            var mediaPopularGetRequest = new MediaPopularGetRequest();
            mediaPopularGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestMediaPopularGetRequestHasCorrectRequestObjectType()
        {
            var mediaPopularGetRequest = new MediaPopularGetRequest();
            mediaPopularGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestMediaPopularGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "batman" };
            var mediaPopularGetRequest = new MediaPopularGetRequest
            {
                Filter = filter
            };

            mediaPopularGetRequest.BuildUri();
            mediaPopularGetRequest.RequestUri.ShouldBe(new Uri($"{URIPath}?query=batman", UriKind.Relative));
        }
    }
}
