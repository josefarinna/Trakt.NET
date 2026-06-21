#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Languages
{
    public sealed class LanguagesMoviesGetRequestTests
    {
        private const string URIPath = "languages/movies";

        [Fact]
        public void TestLanguagesMoviesGetRequestHasValidURIPath()
        {
            var languagesMoviesGetRequest = new LanguagesMoviesGetRequest();

            languagesMoviesGetRequest.BuildUri();
            languagesMoviesGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestLanguagesMoviesGetRequestHasValidOAuthRequirement()
        {
            var languagesMoviesGetRequest = new LanguagesMoviesGetRequest();
            languagesMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestLanguagesMoviesGetRequestIsGetRequest()
        {
            var languagesMoviesGetRequest = new LanguagesMoviesGetRequest();
            languagesMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestLanguagesMoviesGetRequestHasCorrectRequestObjectType()
        {
            var languagesMoviesGetRequest = new LanguagesMoviesGetRequest();
            languagesMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
