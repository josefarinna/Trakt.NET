#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieTranslationsGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}/translations";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData("", URIPath)]
        [InlineData(" ", URIPath)]
        [InlineData("en", $"{URIPath}/en")]
        public void TestMovieTranslationsGetRequestHasValidURIPath(string? language, string expectedURIPath)
        {
            var movieTranslationsGetRequest = new MovieTranslationsGetRequest
            {
                Id = MovieID,
                Language = language
            };

            movieTranslationsGetRequest.BuildUri();
            movieTranslationsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieTranslationsGetRequestHasValidOAuthRequirement()
        {
            var movieTranslationsGetRequest = new MovieTranslationsGetRequest { Id = MovieID };
            movieTranslationsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieTranslationsGetRequestIsGetRequest()
        {
            var movieTranslationsGetRequest = new MovieTranslationsGetRequest { Id = MovieID };
            movieTranslationsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieTranslationsGetRequestHasCorrectRequestObjectType()
        {
            var movieTranslationsGetRequest = new MovieTranslationsGetRequest { Id = MovieID };
            movieTranslationsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieTranslationsGetRequestValidate()
        {
            var movieTranslationsGetRequest = new MovieTranslationsGetRequest { Id = string.Empty };

            Action act = () => movieTranslationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieTranslationsGetRequest = new MovieTranslationsGetRequest { Id = "  " };

            act = () => movieTranslationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieTranslationsGetRequest = new MovieTranslationsGetRequest { Id = "id with spaces" };

            act = () => movieTranslationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
