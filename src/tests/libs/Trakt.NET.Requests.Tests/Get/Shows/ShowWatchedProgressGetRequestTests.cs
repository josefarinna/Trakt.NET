namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowWatchedProgressGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/progress/watched";

        [Theory]
        [InlineData(null, null, null, null, URIPath)]
        [InlineData(true, null, null, null, $"{URIPath}?hidden=true")]
        [InlineData(null, true, null, null, $"{URIPath}?specials=true")]
        [InlineData(null, null, true, null, $"{URIPath}?count_specials=true")]
        [InlineData(null, null, null, TraktLastActivity.Unspecified, URIPath)]
        [InlineData(null, null, null, TraktLastActivity.Collected, $"{URIPath}?last_activity=collected")]
        [InlineData(true, null, null, TraktLastActivity.Unspecified, $"{URIPath}?hidden=true")]
        [InlineData(true, null, null, TraktLastActivity.Collected, $"{URIPath}?hidden=true&last_activity=collected")]
        [InlineData(null, true, null, TraktLastActivity.Unspecified, $"{URIPath}?specials=true")]
        [InlineData(null, true, null, TraktLastActivity.Collected, $"{URIPath}?specials=true&last_activity=collected")]
        [InlineData(null, null, true, TraktLastActivity.Unspecified, $"{URIPath}?count_specials=true")]
        [InlineData(null, null, true, TraktLastActivity.Collected, $"{URIPath}?count_specials=true&last_activity=collected")]
        [InlineData(true, true, true, TraktLastActivity.Unspecified, $"{URIPath}?hidden=true&specials=true&count_specials=true")]
        [InlineData(true, true, true, TraktLastActivity.Collected, $"{URIPath}?hidden=true&specials=true&count_specials=true&last_activity=collected")]
        public void TestShowWatchedProgressGetRequestHasValidURIPath(bool? hidden, bool? specials, bool? countSpecials,
            TraktLastActivity? lastActivity, string expectedURIPath)
        {
            var showWatchedProgressGetRequest = new ShowWatchedProgressGetRequest
            {
                Id = ShowID,
                Hidden = hidden,
                Specials = specials,
                CountSpecials = countSpecials,
                LastActivity = lastActivity
            };

            showWatchedProgressGetRequest.BuildUri();
            showWatchedProgressGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowWatchedProgressGetRequestHasValidOAuthRequirement()
        {
            var showWatchedProgressGetRequest = new ShowWatchedProgressGetRequest { Id = ShowID };
            showWatchedProgressGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestShowWatchedProgressGetRequestIsGetRequest()
        {
            var showWatchedProgressGetRequest = new ShowWatchedProgressGetRequest { Id = ShowID };
            showWatchedProgressGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestShowWatchedProgressGetRequestHasCorrectRequestObjectType()
        {
            var showWatchedProgressGetRequest = new ShowWatchedProgressGetRequest { Id = ShowID };
            showWatchedProgressGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowWatchedProgressGetRequestValidate()
        {
            var showWatchedProgressGetRequest = new ShowWatchedProgressGetRequest { Id = string.Empty };

            Action act = () => showWatchedProgressGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showWatchedProgressGetRequest = new ShowWatchedProgressGetRequest { Id = "  " };

            act = () => showWatchedProgressGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showWatchedProgressGetRequest = new ShowWatchedProgressGetRequest { Id = "id with spaces" };

            act = () => showWatchedProgressGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
