#if TRAKT_OLDER_NET_TARGETS
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieStatisticsGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}/stats";

        [Fact]
        public void TestMovieStatisticsGetRequestHasValidURIPath()
        {
            var movieStatisticsGetRequest = new MovieStatisticsGetRequest { Id = MovieID };

            movieStatisticsGetRequest.BuildUri();
            movieStatisticsGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieStatisticsGetRequestHasValidOAuthRequirement()
        {
            var movieStatisticsGetRequest = new MovieStatisticsGetRequest { Id = MovieID };
            movieStatisticsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieStatisticsGetRequestIsGetRequest()
        {
            var movieStatisticsGetRequest = new MovieStatisticsGetRequest { Id = MovieID };
            movieStatisticsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieStatisticsGetRequestHasCorrectRequestObjectType()
        {
            var movieStatisticsGetRequest = new MovieStatisticsGetRequest { Id = MovieID };
            movieStatisticsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieStatisticsGetRequestValidate()
        {
            var movieStatisticsGetRequest = new MovieStatisticsGetRequest { Id = string.Empty };

            Action act = () => movieStatisticsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieStatisticsGetRequest = new MovieStatisticsGetRequest { Id = "  " };

            act = () => movieStatisticsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            movieStatisticsGetRequest = new MovieStatisticsGetRequest { Id = "id with spaces" };

            act = () => movieStatisticsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
