#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class PopularMoviesGetRequestTests
    {
        private const string URIPath = $"movies/popular";

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
        public void TestPopularMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var popularMoviesGetRequest = new PopularMoviesGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            popularMoviesGetRequest.BuildUri();
            popularMoviesGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestPopularMoviesGetRequestHasValidOAuthRequirement()
        {
            var popularMoviesGetRequest = new PopularMoviesGetRequest();
            popularMoviesGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestPopularMoviesGetRequestIsGetRequest()
        {
            var popularMoviesGetRequest = new PopularMoviesGetRequest();
            popularMoviesGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestPopularMoviesGetRequestHasCorrectRequestObjectType()
        {
            var popularMoviesGetRequest = new PopularMoviesGetRequest();
            popularMoviesGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.None);
        }
    }
}
