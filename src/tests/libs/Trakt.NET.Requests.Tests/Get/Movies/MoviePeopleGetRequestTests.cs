#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class MoviePeopleGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string URIPath = $"movies/{MovieID}/people";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestMoviePeopleGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var moviePeopleGetRequest = new MoviePeopleGetRequest
            {
                Id = MovieID,
                ExtendedInfo = extendedInfo
            };

            moviePeopleGetRequest.BuildUri();
            moviePeopleGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMoviePeopleGetRequestHasValidOAuthRequirement()
        {
            var moviePeopleGetRequest = new MoviePeopleGetRequest { Id = MovieID };
            moviePeopleGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMoviePeopleGetRequestIsGetRequest()
        {
            var moviePeopleGetRequest = new MoviePeopleGetRequest { Id = MovieID };
            moviePeopleGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestMoviePeopleGetRequestHasCorrectRequestObjectType()
        {
            var moviePeopleGetRequest = new MoviePeopleGetRequest { Id = MovieID };
            moviePeopleGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMoviePeopleGetRequestValidate()
        {
            var moviePeopleGetRequest = new MoviePeopleGetRequest { Id = string.Empty };

            Action act = () => moviePeopleGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            moviePeopleGetRequest = new MoviePeopleGetRequest { Id = "  " };

            act = () => moviePeopleGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            moviePeopleGetRequest = new MoviePeopleGetRequest { Id = "id with spaces" };

            act = () => moviePeopleGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
