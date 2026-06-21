#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieRelatedMoviesGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}/related";

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
        public void TestMovieRelatedMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var movieRelatedMoviesGetRequest = new MovieRelatedMoviesGetRequest
            {
                Id = MovieID,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            movieRelatedMoviesGetRequest.BuildUri();
            movieRelatedMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieRelatedMoviesGetRequestHasValidOAuthRequirement()
        {
            var movieRelatedMoviesGetRequest = new MovieRelatedMoviesGetRequest { Id = MovieID };
            movieRelatedMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieRelatedMoviesGetRequestIsGetRequest()
        {
            var movieRelatedMoviesGetRequest = new MovieRelatedMoviesGetRequest { Id = MovieID };
            movieRelatedMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieRelatedMoviesGetRequestHasCorrectRequestObjectType()
        {
            var movieRelatedMoviesGetRequest = new MovieRelatedMoviesGetRequest { Id = MovieID };
            movieRelatedMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieRelatedMoviesGetRequestValidate()
        {
            var movieRelatedMoviesGetRequest = new MovieRelatedMoviesGetRequest { Id = string.Empty };
            Action act = () => movieRelatedMoviesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieRelatedMoviesGetRequest = new MovieRelatedMoviesGetRequest { Id = "  " };
            act = () => movieRelatedMoviesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieRelatedMoviesGetRequest = new MovieRelatedMoviesGetRequest { Id = "id with spaces" };
            act = () => movieRelatedMoviesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
