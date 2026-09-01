#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowTranslationsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/translations";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData("", URIPath)]
        [InlineData(" ", URIPath)]
        [InlineData("en", $"{URIPath}?language=en")]
        public void TestShowTranslationsGetRequestHasValidURIPath(string? language, string expectedURIPath)
        {
            var showTranslationsGetRequest = new ShowTranslationsGetRequest
            {
                Id = ShowID,
                Language = language
            };

            showTranslationsGetRequest.BuildUri();
            showTranslationsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowTranslationsGetRequestHasValidOAuthRequirement()
        {
            var showTranslationsGetRequest = new ShowTranslationsGetRequest { Id = ShowID };
            showTranslationsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowTranslationsGetRequestIsGetRequest()
        {
            var showTranslationsGetRequest = new ShowTranslationsGetRequest { Id = ShowID };
            showTranslationsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestShowTranslationsGetRequestHasCorrectRequestObjectType()
        {
            var showTranslationsGetRequest = new ShowTranslationsGetRequest { Id = ShowID };
            showTranslationsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowTranslationsGetRequestValidate()
        {
            var showTranslationsGetRequest = new ShowTranslationsGetRequest { Id = string.Empty };
            Action act = () => showTranslationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showTranslationsGetRequest = new ShowTranslationsGetRequest { Id = "  " };
            act = () => showTranslationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showTranslationsGetRequest = new ShowTranslationsGetRequest { Id = "id with spaces" };
            act = () => showTranslationsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
