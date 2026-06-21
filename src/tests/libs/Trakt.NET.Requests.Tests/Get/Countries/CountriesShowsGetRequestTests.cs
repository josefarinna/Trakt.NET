#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Countries
{
    public sealed class CountriesShowsGetRequestTests
    {
        private const string URIPath = "countries/shows";

        [Fact]
        public void TestCountriesShowsGetRequestHasValidURIPath()
        {
            var countriesShowsGetRequest = new CountriesShowsGetRequest();

            countriesShowsGetRequest.BuildUri();
            countriesShowsGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCountriesShowsGetRequestHasValidOAuthRequirement()
        {
            var countriesShowsGetRequest = new CountriesShowsGetRequest();
            countriesShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCountriesShowsGetRequestIsGetRequest()
        {
            var countriesShowsGetRequest = new CountriesShowsGetRequest();
            countriesShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCountriesShowsGetRequestHasCorrectRequestObjectType()
        {
            var countriesShowsGetRequest = new CountriesShowsGetRequest();
            countriesShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
