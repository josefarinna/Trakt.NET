namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowTranslationsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/translations";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData("", URIPath)]
        [InlineData(" ", URIPath)]
        [InlineData("en", $"{URIPath}/en")]
        public void TestShowTranslationsGetRequestHasValidURIPath(string? language, string expectedURIPath)
        {
            var showTranslationsGetRequest = new ShowTranslationsGetRequest
            {
                Id = ShowID,
                Language = language
            };

            showTranslationsGetRequest.BuildUri();
            showTranslationsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowTranslationsGetRequestHasValidOAuthRequirement()
        {
            var showTranslationsGetRequest = new ShowTranslationsGetRequest { Id = ShowID };
            showTranslationsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowTranslationsGetRequestIsGetRequest()
        {
            var showTranslationsGetRequest = new ShowTranslationsGetRequest { Id = ShowID };
            showTranslationsGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
