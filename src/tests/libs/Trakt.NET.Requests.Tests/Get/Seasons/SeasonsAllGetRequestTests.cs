namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonsAllGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestSeasonsAllGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var seasonsAllGetRequest = new SeasonsAllGetRequest
            {
                ShowId = ShowID,
                ExtendedInfo = extendedInfo
            };

            seasonsAllGetRequest.BuildUri();
            seasonsAllGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonsAllGetRequestHasValidOAuthRequirement()
        {
            var seasonsAllGetRequest = new SeasonsAllGetRequest { ShowId = ShowID };
            seasonsAllGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonsAllGetRequestIsGetRequest()
        {
            var seasonsAllGetRequest = new SeasonsAllGetRequest { ShowId = ShowID };
            seasonsAllGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestSeasonsAllGetRequestHasCorrectRequestObjectType()
        {
            var seasonsAllGetRequest = new SeasonsAllGetRequest { ShowId = ShowID };
            seasonsAllGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestSeasonsAllGetRequestValidate()
        {
            var seasonsAllGetRequest = new SeasonsAllGetRequest { ShowId = string.Empty };

            Action act = () => seasonsAllGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            seasonsAllGetRequest = new SeasonsAllGetRequest { ShowId = "  " };

            act = () => seasonsAllGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            seasonsAllGetRequest = new SeasonsAllGetRequest { ShowId = "id with spaces" };

            act = () => seasonsAllGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
