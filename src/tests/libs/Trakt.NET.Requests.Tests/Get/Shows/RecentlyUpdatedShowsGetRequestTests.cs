#if TRAKT_OLDER_NET_TARGETS
using System.Net.Http;
#endif

using System.Globalization;

namespace TraktNET.GetRequests.Shows
{
    public sealed class RecentlyUpdatedShowsGetRequestTests
    {
        private const string URIPath = $"shows/updates";
        private const string StartDateURIValue = "2024-07-20T00:00:00Z";
        private static readonly DateTime StartDate = DateTime.Parse(StartDateURIValue, CultureInfo.InvariantCulture);

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
        public void TestRecentlyUpdatedShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var recentlyUpdatedShowsGetRequest = new RecentlyUpdatedShowsGetRequest
            {
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            recentlyUpdatedShowsGetRequest.BuildUri();
            recentlyUpdatedShowsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, null, null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.None, null, null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{URIPath}/{StartDateURIValue}?extended=full")]
        [InlineData(null, 10, null, $"{URIPath}/{StartDateURIValue}?page=10")]
        [InlineData(null, null, 20, $"{URIPath}/{StartDateURIValue}?limit=20")]
        [InlineData(null, 10, 20, $"{URIPath}/{StartDateURIValue}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, null, $"{URIPath}/{StartDateURIValue}?page=10")]
        [InlineData(TraktExtendedInfo.Full, 10, null, $"{URIPath}/{StartDateURIValue}?extended=full&page=10")]
        [InlineData(TraktExtendedInfo.None, null, 20, $"{URIPath}/{StartDateURIValue}?limit=20")]
        [InlineData(TraktExtendedInfo.Full, null, 20, $"{URIPath}/{StartDateURIValue}?extended=full&limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, 20, $"{URIPath}/{StartDateURIValue}?page=10&limit=20")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, $"{URIPath}/{StartDateURIValue}?extended=full&page=10&limit=20")]
        public void TestRecentlyUpdatedShowsGetRequestHasValidURIPathWithStartDate(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var recentlyUpdatedShowsGetRequest = new RecentlyUpdatedShowsGetRequest
            {
                StartDate = StartDate,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            recentlyUpdatedShowsGetRequest.BuildUri();
            recentlyUpdatedShowsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestRecentlyUpdatedShowsGetRequestHasValidOAuthRequirement()
        {
            var recentlyUpdatedShowsGetRequest = new RecentlyUpdatedShowsGetRequest();
            recentlyUpdatedShowsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestRecentlyUpdatedShowsGetRequestIsGetRequest()
        {
            var recentlyUpdatedShowsGetRequest = new RecentlyUpdatedShowsGetRequest();
            recentlyUpdatedShowsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestRecentlyUpdatedShowsGetRequestHasCorrectRequestObjectType()
        {
            var recentlyUpdatedShowsGetRequest = new RecentlyUpdatedShowsGetRequest();
            recentlyUpdatedShowsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.None);
        }
    }
}
