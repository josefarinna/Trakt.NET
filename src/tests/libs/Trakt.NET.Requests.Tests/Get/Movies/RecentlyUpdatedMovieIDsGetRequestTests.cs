#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

using System.Globalization;

namespace TraktNET.GetRequests.Movies
{
    public sealed class RecentlyUpdatedMovieIDsGetRequestTests
    {
        private const string URIPath = $"movies/updates/id";
        private const string StartDateURIValue = "2024-07-20T00:00:00Z";
        private static readonly DateTime StartDate = DateTime.Parse(StartDateURIValue, CultureInfo.InvariantCulture);

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(10, null, $"{URIPath}?page=10")]
        [InlineData(null, 20, $"{URIPath}?limit=20")]
        [InlineData(10, 20, $"{URIPath}?page=10&limit=20")]
        public void TestRecentlyUpdatedMovieIDsGetRequestHasValidURIPath(int? page, int? limit, string expectedURIPath)
        {
            var recentlyUpdatedMovieIDsGetRequest = new RecentlyUpdatedMovieIDsGetRequest
            {
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            recentlyUpdatedMovieIDsGetRequest.BuildUri();
            recentlyUpdatedMovieIDsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(10, null, $"{URIPath}/{StartDateURIValue}?page=10")]
        [InlineData(null, 20, $"{URIPath}/{StartDateURIValue}?limit=20")]
        [InlineData(10, 20, $"{URIPath}/{StartDateURIValue}?page=10&limit=20")]
        public void TestRecentlyUpdatedMovieIDsGetRequestHasValidURIPathWithStartDate(int? page, int? limit, string expectedURIPath)
        {
            var recentlyUpdatedMovieIDsGetRequest = new RecentlyUpdatedMovieIDsGetRequest
            {
                StartDate = StartDate,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            recentlyUpdatedMovieIDsGetRequest.BuildUri();
            recentlyUpdatedMovieIDsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestRecentlyUpdatedMovieIDsGetRequestHasValidOAuthRequirement()
        {
            var recentlyUpdatedMovieIDsGetRequest = new RecentlyUpdatedMovieIDsGetRequest();
            recentlyUpdatedMovieIDsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestRecentlyUpdatedMovieIDsGetRequestIsGetRequest()
        {
            var recentlyUpdatedMovieIDsGetRequest = new RecentlyUpdatedMovieIDsGetRequest();
            recentlyUpdatedMovieIDsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestRecentlyUpdatedMovieIDsGetRequestHasCorrectRequestObjectType()
        {
            var recentlyUpdatedMovieIDsGetRequest = new RecentlyUpdatedMovieIDsGetRequest();
            recentlyUpdatedMovieIDsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.None);
        }
    }
}
