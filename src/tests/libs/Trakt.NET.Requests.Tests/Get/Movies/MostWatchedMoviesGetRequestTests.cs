namespace TraktNET.GetRequests.Movies
{
    public sealed class MostWatchedMoviesGetRequestTests
    {
        private const string URIPath = $"movies/watched";

        [Theory]
        [InlineData(null, null, null, null, URIPath)]
        [InlineData(TraktTimePeriod.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktTimePeriod.Daily, null, null, null, $"{URIPath}/daily")]
        [InlineData(null, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktTimePeriod.Daily, TraktExtendedInfo.None, null, null, $"{URIPath}/daily")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktTimePeriod.Daily, TraktExtendedInfo.Full, null, null, $"{URIPath}/daily?extended=full")]
        [InlineData(TraktTimePeriod.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktTimePeriod.Daily, null, 10, null, $"{URIPath}/daily?page=10")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktTimePeriod.Daily, null, null, 20, $"{URIPath}/daily?limit=20")]
        [InlineData(TraktTimePeriod.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktTimePeriod.Daily, null, 10, 20, $"{URIPath}/daily?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(null, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktTimePeriod.Daily, TraktExtendedInfo.Full, 10, null, $"{URIPath}/daily?extended=full&page=10")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktTimePeriod.Daily, TraktExtendedInfo.Full, null, 20, $"{URIPath}/daily?extended=full&limit=20")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktTimePeriod.Daily, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/daily?extended=full&page=10&limit=20")]
        public void TestMostWatchedMoviesGetRequestHasValidURIPath(TraktTimePeriod? timePeriod, TraktExtendedInfo? extendedInfo,
            int? page, int? limit, string expectedURIPath)
        {
            var mostWatchedMoviesGetRequest = new MostWatchedMoviesGetRequest
            {
                TimePeriod = timePeriod,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            mostWatchedMoviesGetRequest.BuildUri();
            mostWatchedMoviesGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestMostWatchedMoviesGetRequestHasValidOAuthRequirement()
        {
            var mostWatchedMoviesGetRequest = new MostWatchedMoviesGetRequest();
            mostWatchedMoviesGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestMostWatchedMoviesGetRequestIsGetRequest()
        {
            var mostWatchedMoviesGetRequest = new MostWatchedMoviesGetRequest();
            mostWatchedMoviesGetRequest.Method.Should().Be(HttpMethod.Get);
        }
    }
}
