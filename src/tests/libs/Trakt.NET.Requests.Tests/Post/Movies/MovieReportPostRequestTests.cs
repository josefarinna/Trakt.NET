#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Movies
{
    public sealed class MovieReportPostRequestTests
    {
        private const string URIPath = "movies/123/report";

        [Fact]
        public void TestMovieReportPostRequestHasValidURIPath()
        {
            var movieReportPostRequest = new MovieReportPostRequest
            {
                Id = "123",
                TraktReportPost = new TraktReportPost()
            };

            movieReportPostRequest.BuildUri();
            movieReportPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMovieReportPostRequestHasValidOAuthRequirement()
        {
            var movieReportPostRequest = new MovieReportPostRequest { Id = default!, TraktReportPost = default! };
            movieReportPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestMovieReportPostRequestIsPostRequest()
        {
            var movieReportPostRequest = new MovieReportPostRequest { Id = default!, TraktReportPost = default! };
            movieReportPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestMovieReportPostRequestHasCorrectRequestObjectType()
        {
            var movieReportPostRequest = new MovieReportPostRequest { Id = default!, TraktReportPost = default! };
            movieReportPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Movie);
        }

        [Fact]
        public void TestMovieReportPostRequestValidate()
        {
            var movieReportPostRequest = new MovieReportPostRequest { Id = string.Empty, TraktReportPost = default! };
            Action act = () => movieReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieReportPostRequest = new MovieReportPostRequest { Id = "  ", TraktReportPost = default! };
            act = () => movieReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieReportPostRequest = new MovieReportPostRequest { Id = "id with spaces", TraktReportPost = default! };
            act = () => movieReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieReportPostRequest = new MovieReportPostRequest { Id = "id", TraktReportPost = default! };
            act = () => movieReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            movieReportPostRequest = new MovieReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost() };
            act = () => movieReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            movieReportPostRequest = new MovieReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost { Reason = TraktReason.Other } };
            act = () => movieReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
