#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Movies
{
    public sealed class MovieJustwatchLinksGetRequestTests
    {
        private const string MovieID = TestConstants.Movies.MovieSlug;
        private const string Country = "us";
        private const string URIPath = $"movies/{MovieID}/watchnow/justwatch_links/{Country}";

        [Fact]
        public void TestMovieJustwatchLinksGetRequestHasValidURIPath()
        {
            var request = new MovieJustwatchLinksGetRequest
            {
                Id = MovieID,
                Country = Country
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieJustwatchLinksGetRequestHasValidOAuthRequirement()
        {
            var request = new MovieJustwatchLinksGetRequest { Id = MovieID, Country = Country };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMovieJustwatchLinksGetRequestIsGetRequest()
        {
            var request = new MovieJustwatchLinksGetRequest { Id = MovieID, Country = Country };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestMovieJustwatchLinksGetRequestHasCorrectRequestObjectType()
        {
            var request = new MovieJustwatchLinksGetRequest { Id = MovieID, Country = Country };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieJustwatchLinksGetRequestValidate()
        {
            var request = new MovieJustwatchLinksGetRequest { Id = string.Empty, Country = Country };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new MovieJustwatchLinksGetRequest { Id = "  ", Country = Country };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new MovieJustwatchLinksGetRequest { Id = "id with spaces", Country = Country };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new MovieJustwatchLinksGetRequest { Id = MovieID, Country = string.Empty };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new MovieJustwatchLinksGetRequest { Id = MovieID, Country = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new MovieJustwatchLinksGetRequest { Id = MovieID, Country = "country with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
