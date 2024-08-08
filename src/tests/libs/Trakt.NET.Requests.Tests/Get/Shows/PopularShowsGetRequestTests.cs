namespace TraktNET.GetRequests.Shows
{
    public sealed class PopularShowsGetRequestTests
    {
        private const string URIPath = $"shows/popular";

        [Theory]
        [InlineData(null, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        public void TestPopularShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var popularShowsGetRequest = new PopularShowsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            popularShowsGetRequest.BuildUri();
            popularShowsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestPopularShowsGetRequestHasValidOAuthRequirement()
        {
            var popularShowsGetRequest = new PopularShowsGetRequest();
            popularShowsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestPopularShowsGetRequestIsGetRequest()
        {
            var popularShowsGetRequest = new PopularShowsGetRequest();
            popularShowsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestPopularShowsGetRequestHasCorrectRequestObjectType()
        {
            var popularShowsGetRequest = new PopularShowsGetRequest();
            popularShowsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.None);
        }
    }
}
