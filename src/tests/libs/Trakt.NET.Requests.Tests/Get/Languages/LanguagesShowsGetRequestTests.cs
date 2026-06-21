#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Languages
{
    public sealed class LanguagesShowsGetRequestTests
    {
        private const string URIPath = "languages/shows";

        [Fact]
        public void TestLanguagesShowsGetRequestHasValidURIPath()
        {
            var languagesShowsGetRequest = new LanguagesShowsGetRequest();

            languagesShowsGetRequest.BuildUri();
            languagesShowsGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestLanguagesShowsGetRequestHasValidOAuthRequirement()
        {
            var languagesShowsGetRequest = new LanguagesShowsGetRequest();
            languagesShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestLanguagesShowsGetRequestIsGetRequest()
        {
            var languagesShowsGetRequest = new LanguagesShowsGetRequest();
            languagesShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestLanguagesShowsGetRequestHasCorrectRequestObjectType()
        {
            var languagesShowsGetRequest = new LanguagesShowsGetRequest();
            languagesShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
