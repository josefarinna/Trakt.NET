#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Countries
{
    public sealed class CountriesMoviesGetRequestTests
    {
        private const string URIPath = "countries/movies";

        [Fact]
        public void TestCountriesMoviesGetRequestHasValidURIPath()
        {
            var countriesMoviesGetRequest = new CountriesMoviesGetRequest();

            countriesMoviesGetRequest.BuildUri();
            countriesMoviesGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCountriesMoviesGetRequestHasValidOAuthRequirement()
        {
            var countriesMoviesGetRequest = new CountriesMoviesGetRequest();
            countriesMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCountriesMoviesGetRequestIsGetRequest()
        {
            var countriesMoviesGetRequest = new CountriesMoviesGetRequest();
            countriesMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCountriesMoviesGetRequestHasCorrectRequestObjectType()
        {
            var countriesMoviesGetRequest = new CountriesMoviesGetRequest();
            countriesMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
