namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonPeopleGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/people";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestSeasonPeopleGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var seasonPeopleGetRequest = new SeasonPeopleGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1,
                ExtendedInfo = extendedInfo
            };

            seasonPeopleGetRequest.BuildUri();
            seasonPeopleGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonPeopleGetRequestHasValidOAuthRequirement()
        {
            var seasonPeopleGetRequest = new SeasonPeopleGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonPeopleGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonPeopleGetRequestIsGetRequest()
        {
            var seasonPeopleGetRequest = new SeasonPeopleGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonPeopleGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestSeasonPeopleGetRequestHasCorrectRequestObjectType()
        {
            var seasonPeopleGetRequest = new SeasonPeopleGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonPeopleGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Season);
        }

        [Fact]
        public void TestSeasonPeopleGetRequestValidate()
        {
            var seasonPeopleGetRequest = new SeasonPeopleGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1
            };

            Action act = () => seasonPeopleGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            seasonPeopleGetRequest = new SeasonPeopleGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1
            };

            act = () => seasonPeopleGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            seasonPeopleGetRequest = new SeasonPeopleGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1
            };

            act = () => seasonPeopleGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            seasonPeopleGetRequest = new SeasonPeopleGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0
            };

            act = () => seasonPeopleGetRequest.Validate();
            act.Should().NotThrow();
        }
    }
}
