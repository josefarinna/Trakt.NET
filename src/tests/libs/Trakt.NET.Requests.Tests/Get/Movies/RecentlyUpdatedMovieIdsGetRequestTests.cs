#if TRAKT_OLDER_NET_TARGETS
using System.Net.Http;
#endif

using System.Globalization;

namespace TraktNET.GetRequests.Movies
{
    public sealed class RecentlyUpdatedMovieIdsGetRequestTests
    {
        private const string URIPath = $"movies/updates/id";
        private const string StartDateURIValue = "2024-07-20T00:00:00Z";
        private static readonly DateTime StartDate = DateTime.Parse(StartDateURIValue, CultureInfo.InvariantCulture);

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(10, null, $"{URIPath}?page=10")]
        [InlineData(null, 20, $"{URIPath}?limit=20")]
        [InlineData(10, 20, $"{URIPath}?page=10&limit=20")]
        public void TestRecentlyUpdatedMovieIdsGetRequestHasValidURIPath(int? page, int? limit, string expectedURIPath)
        {
            var recentlyUpdatedMovieIdsGetRequest = new RecentlyUpdatedMovieIdsGetRequest
            {
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            recentlyUpdatedMovieIdsGetRequest.BuildUri();
            recentlyUpdatedMovieIdsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(10, null, $"{URIPath}/{StartDateURIValue}?page=10")]
        [InlineData(null, 20, $"{URIPath}/{StartDateURIValue}?limit=20")]
        [InlineData(10, 20, $"{URIPath}/{StartDateURIValue}?page=10&limit=20")]
        public void TestRecentlyUpdatedMovieIdsGetRequestHasValidURIPathWithStartDate(int? page, int? limit, string expectedURIPath)
        {
            var recentlyUpdatedMovieIdsGetRequest = new RecentlyUpdatedMovieIdsGetRequest
            {
                StartDate = StartDate,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            recentlyUpdatedMovieIdsGetRequest.BuildUri();
            recentlyUpdatedMovieIdsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestRecentlyUpdatedMovieIdsGetRequestHasValidOAuthRequirement()
        {
            var recentlyUpdatedMovieIdsGetRequest = new RecentlyUpdatedMovieIdsGetRequest();
            recentlyUpdatedMovieIdsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestRecentlyUpdatedMovieIdsGetRequestIsGetRequest()
        {
            var recentlyUpdatedMovieIdsGetRequest = new RecentlyUpdatedMovieIdsGetRequest();
            recentlyUpdatedMovieIdsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestRecentlyUpdatedMovieIdsGetRequestHasCorrectRequestObjectType()
        {
            var recentlyUpdatedMovieIdsGetRequest = new RecentlyUpdatedMovieIdsGetRequest();
            recentlyUpdatedMovieIdsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.None);
        }
    }
}
