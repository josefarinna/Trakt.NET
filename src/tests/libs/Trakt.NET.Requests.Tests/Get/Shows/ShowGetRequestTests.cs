namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestShowGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var showGetRequest = new ShowGetRequest
            {
                Id = ShowID,
                ExtendedInfo = extendedInfo
            };

            showGetRequest.BuildUri();
            showGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowGetRequestHasValidOAuthRequirement()
        {
            var showGetRequest = new ShowGetRequest { Id = ShowID };
            showGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowGetRequestIsGetRequest()
        {
            var showGetRequest = new ShowGetRequest { Id = ShowID };
            showGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
