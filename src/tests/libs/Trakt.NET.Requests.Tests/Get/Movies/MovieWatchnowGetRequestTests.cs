#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieWatchnowGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string Country = "us";
        private const string URIPath = $"movies/{MovieID}/watchnow/{Country}";

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(true, null, $"{URIPath}?links=true")]
        [InlineData(false, null, $"{URIPath}?links=false")]
        [InlineData(null, TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        [InlineData(true, TraktExtendedInfo.Full, $"{URIPath}?links=true&extended=full")]
        public void TestMovieWatchnowGetRequestHasValidURIPath(bool? links, TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var request = new MovieWatchnowGetRequest
            {
                Id = MovieID,
                Country = Country,
                Links = links,
                ExtendedInfo = extendedInfo
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieWatchnowGetRequestHasValidOAuthRequirement()
        {
            var request = new MovieWatchnowGetRequest { Id = MovieID, Country = Country };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieWatchnowGetRequestIsGetRequest()
        {
            var request = new MovieWatchnowGetRequest { Id = MovieID, Country = Country };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieWatchnowGetRequestHasCorrectRequestObjectType()
        {
            var request = new MovieWatchnowGetRequest { Id = MovieID, Country = Country };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieWatchnowGetRequestValidate()
        {
            var request = new MovieWatchnowGetRequest { Id = string.Empty, Country = Country };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new MovieWatchnowGetRequest { Id = "  ", Country = Country };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new MovieWatchnowGetRequest { Id = "id with spaces", Country = Country };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new MovieWatchnowGetRequest { Id = MovieID, Country = string.Empty };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new MovieWatchnowGetRequest { Id = MovieID, Country = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new MovieWatchnowGetRequest { Id = MovieID, Country = "country with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
