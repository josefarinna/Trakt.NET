#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieAwardsGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}/awards";

        [Fact]
        public void TestMovieAwardsGetRequestHasValidURIPath()
        {
            var request = new MovieAwardsGetRequest { Id = MovieID };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieAwardsGetRequestHasValidOAuthRequirement()
        {
            var request = new MovieAwardsGetRequest { Id = MovieID };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieAwardsGetRequestIsGetRequest()
        {
            var request = new MovieAwardsGetRequest { Id = MovieID };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieAwardsGetRequestHasCorrectRequestObjectType()
        {
            var request = new MovieAwardsGetRequest { Id = MovieID };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieAwardsGetRequestValidate()
        {
            var request = new MovieAwardsGetRequest { Id = string.Empty };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new MovieAwardsGetRequest { Id = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new MovieAwardsGetRequest { Id = "id with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
