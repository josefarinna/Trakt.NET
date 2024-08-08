namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowWatchingGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/watching";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.VIP | TraktExtendedInfo.Full, $"{URIPath}?extended=full,vip")]
        public void TestShowWatchingGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var showWatchingGetRequest = new ShowWatchingGetRequest
            {
                Id = ShowID,
                ExtendedInfo = extendedInfo
            };

            showWatchingGetRequest.BuildUri();
            showWatchingGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowWatchingGetRequestHasValidOAuthRequirement()
        {
            var showWatchingGetRequest = new ShowWatchingGetRequest { Id = ShowID };
            showWatchingGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowWatchingGetRequestIsGetRequest()
        {
            var showWatchingGetRequest = new ShowWatchingGetRequest { Id = ShowID };
            showWatchingGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestShowWatchingGetRequestHasCorrectRequestObjectType()
        {
            var showWatchingGetRequest = new ShowWatchingGetRequest { Id = ShowID };
            showWatchingGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowWatchingGetRequestValidate()
        {
            var showWatchingGetRequest = new ShowWatchingGetRequest { Id = string.Empty };

            Action act = () => showWatchingGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showWatchingGetRequest = new ShowWatchingGetRequest { Id = "  " };

            act = () => showWatchingGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showWatchingGetRequest = new ShowWatchingGetRequest { Id = "id with spaces" };

            act = () => showWatchingGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
