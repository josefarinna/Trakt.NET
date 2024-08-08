namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowCollectionProgressGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/progress/collection";

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
        public void TestShowCollectionProgressGetRequestHasValidURIPath(bool? hidden, bool? specials, bool? countSpecials,
            TraktLastActivity? lastActivity, string expectedURIPath)
        {
            var showCollectionProgressGetRequest = new ShowCollectionProgressGetRequest
            {
                Id = ShowID,
                Hidden = hidden,
                Specials = specials,
                CountSpecials = countSpecials,
                LastActivity = lastActivity
            };

            showCollectionProgressGetRequest.BuildUri();
            showCollectionProgressGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowCollectionProgressGetRequestHasValidOAuthRequirement()
        {
            var showCollectionProgressGetRequest = new ShowCollectionProgressGetRequest { Id = ShowID };
            showCollectionProgressGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestShowCollectionProgressGetRequestIsGetRequest()
        {
            var showCollectionProgressGetRequest = new ShowCollectionProgressGetRequest { Id = ShowID };
            showCollectionProgressGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestShowCollectionProgressGetRequestHasCorrectRequestObjectType()
        {
            var showCollectionProgressGetRequest = new ShowCollectionProgressGetRequest { Id = ShowID };
            showCollectionProgressGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowCollectionProgressGetRequestValidate()
        {
            var showCollectionProgressGetRequest = new ShowCollectionProgressGetRequest { Id = string.Empty };

            Action act = () => showCollectionProgressGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showCollectionProgressGetRequest = new ShowCollectionProgressGetRequest { Id = "  " };

            act = () => showCollectionProgressGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showCollectionProgressGetRequest = new ShowCollectionProgressGetRequest { Id = "id with spaces" };

            act = () => showCollectionProgressGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
