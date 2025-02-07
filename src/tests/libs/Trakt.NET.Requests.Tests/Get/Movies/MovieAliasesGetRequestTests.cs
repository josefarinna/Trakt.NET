#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieAliasesGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}/aliases";

        [Fact]
        public void TestMovieAliasesGetRequestHasValidURIPath()
        {
            var movieAliasesGetRequest = new MovieAliasesGetRequest { Id = MovieID };

            movieAliasesGetRequest.BuildUri();
            movieAliasesGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieAliasesGetRequestHasValidOAuthRequirement()
        {
            var movieAliasesGetRequest = new MovieAliasesGetRequest { Id = MovieID };
            movieAliasesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieAliasesGetRequestIsGetRequest()
        {
            var movieAliasesGetRequest = new MovieAliasesGetRequest { Id = MovieID };
            movieAliasesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieAliasesGetRequestHasCorrectRequestObjectType()
        {
            var movieAliasesGetRequest = new MovieAliasesGetRequest { Id = MovieID };
            movieAliasesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieAliasesGetRequestValidate()
        {
            var movieAliasesGetRequest = new MovieAliasesGetRequest { Id = string.Empty };

            Action act = () => movieAliasesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieAliasesGetRequest = new MovieAliasesGetRequest { Id = "  " };

            act = () => movieAliasesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieAliasesGetRequest = new MovieAliasesGetRequest { Id = "id with spaces" };

            act = () => movieAliasesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
