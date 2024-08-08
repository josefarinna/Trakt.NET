namespace TraktNET.GetRequests.Seasons
{
    public sealed class SeasonRatingsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/seasons/1/ratings";

        [Fact]
        public void TestSeasonRatingsGetRequestHasValidURIPath()
        {
            var seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonRatingsGetRequest.BuildUri();
            seasonRatingsGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSeasonRatingsGetRequestHasValidOAuthRequirement()
        {
            var seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonRatingsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSeasonRatingsGetRequestIsGetRequest()
        {
            var seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonRatingsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestSeasonRatingsGetRequestHasCorrectRequestObjectType()
        {
            var seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 1
            };

            seasonRatingsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Season);
        }

        [Fact]
        public void TestSeasonRatingsGetRequestValidate()
        {
            var seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = string.Empty,
                SeasonNumber = 1
            };

            Action act = () => seasonRatingsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = "  ",
                SeasonNumber = 1
            };

            act = () => seasonRatingsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = "id with spaces",
                SeasonNumber = 1
            };

            act = () => seasonRatingsGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            seasonRatingsGetRequest = new SeasonRatingsGetRequest
            {
                ShowId = ShowID,
                SeasonNumber = 0
            };

            act = () => seasonRatingsGetRequest.Validate();
            act.Should().NotThrow();
        }
    }
}
