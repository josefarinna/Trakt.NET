#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieSentimentsGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}/sentiments";

        [Fact]
        public void TestMovieSentimentsGetRequestHasValidURIPath()
        {
            var movieSentimentsGetRequest = new MovieSentimentsGetRequest { Id = MovieID };

            movieSentimentsGetRequest.BuildUri();
            movieSentimentsGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieSentimentsGetRequestHasValidOAuthRequirement()
        {
            var movieSentimentsGetRequest = new MovieSentimentsGetRequest { Id = MovieID };
            movieSentimentsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieSentimentsGetRequestIsGetRequest()
        {
            var movieSentimentsGetRequest = new MovieSentimentsGetRequest { Id = MovieID };
            movieSentimentsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieSentimentsGetRequestHasCorrectRequestObjectType()
        {
            var movieSentimentsGetRequest = new MovieSentimentsGetRequest { Id = MovieID };
            movieSentimentsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieSentimentsGetRequestValidate()
        {
            var movieSentimentsGetRequest = new MovieSentimentsGetRequest { Id = string.Empty };
            Action act = () => movieSentimentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieSentimentsGetRequest = new MovieSentimentsGetRequest { Id = "  " };
            act = () => movieSentimentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieSentimentsGetRequest = new MovieSentimentsGetRequest { Id = "id with spaces" };
            act = () => movieSentimentsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
