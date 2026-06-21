#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Genres
{
    public sealed class GenresShowsGetRequestTests
    {
        private const string URIPath = "genres/shows";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestGenresShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var genresShowsGetRequest = new GenresShowsGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            genresShowsGetRequest.BuildUri();
            genresShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestGenresShowsGetRequestHasValidOAuthRequirement()
        {
            var genresShowsGetRequest = new GenresShowsGetRequest();
            genresShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestGenresShowsGetRequestIsGetRequest()
        {
            var genresShowsGetRequest = new GenresShowsGetRequest();
            genresShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestGenresShowsGetRequestHasCorrectRequestObjectType()
        {
            var genresShowsGetRequest = new GenresShowsGetRequest();
            genresShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
