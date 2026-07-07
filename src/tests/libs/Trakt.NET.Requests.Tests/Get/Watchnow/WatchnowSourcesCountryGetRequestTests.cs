#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Watchnow
{
    public sealed class WatchnowSourcesCountryGetRequestTests
    {
        private const string CountryCode = "us";
        private const string URIPath = $"watchnow/sources/{CountryCode}";

        [Fact]
        public void TestWatchnowSourcesCountryGetRequestHasValidURIPath()
        {
            var request = new WatchnowSourcesCountryGetRequest
            {
                CountryCode = CountryCode
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestWatchnowSourcesCountryGetRequestHasValidOAuthRequirement()
        {
            var request = new WatchnowSourcesCountryGetRequest { CountryCode = CountryCode };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestWatchnowSourcesCountryGetRequestIsGetRequest()
        {
            var request = new WatchnowSourcesCountryGetRequest { CountryCode = CountryCode };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestWatchnowSourcesCountryGetRequestValidate()
        {
            var request = new WatchnowSourcesCountryGetRequest { CountryCode = string.Empty };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new WatchnowSourcesCountryGetRequest { CountryCode = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new WatchnowSourcesCountryGetRequest { CountryCode = "country with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
