using System.Globalization;

namespace TraktNET.GetRequests.Shows
{
    public sealed class RecentlyUpdatedShowIdsGetRequestTests
    {
        private const string URIPath = $"shows/updates/id";
        private const string StartDateURIValue = "2024-07-20T00:00:00Z";
        private static readonly DateTime StartDate = DateTime.Parse(StartDateURIValue, CultureInfo.InvariantCulture);

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(10, null, $"{URIPath}?page=10")]
        [InlineData(null, 20, $"{URIPath}?limit=20")]
        [InlineData(10, 20, $"{URIPath}?page=10&limit=20")]
        public void TestRecentlyUpdatedShowIdsGetRequestHasValidURIPath(int? page, int? limit, string expectedURIPath)
        {
            var recentlyUpdatedShowIdsGetRequest = new RecentlyUpdatedShowIdsGetRequest
            {
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            recentlyUpdatedShowIdsGetRequest.BuildUri();
            recentlyUpdatedShowIdsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(10, null, $"{URIPath}/{StartDateURIValue}?page=10")]
        [InlineData(null, 20, $"{URIPath}/{StartDateURIValue}?limit=20")]
        [InlineData(10, 20, $"{URIPath}/{StartDateURIValue}?page=10&limit=20")]
        public void TestRecentlyUpdatedShowIdsGetRequestHasValidURIPathWithStartDate(int? page, int? limit, string expectedURIPath)
        {
            var recentlyUpdatedShowIdsGetRequest = new RecentlyUpdatedShowIdsGetRequest
            {
                StartDate = StartDate,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            recentlyUpdatedShowIdsGetRequest.BuildUri();
            recentlyUpdatedShowIdsGetRequest.RequestUri.Should().Be(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestRecentlyUpdatedShowIdsGetRequestHasValidOAuthRequirement()
        {
            var recentlyUpdatedShowIdsGetRequest = new RecentlyUpdatedShowIdsGetRequest();
            recentlyUpdatedShowIdsGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestRecentlyUpdatedShowIdsGetRequestIsGetRequest()
        {
            var recentlyUpdatedShowIdsGetRequest = new RecentlyUpdatedShowIdsGetRequest();
            recentlyUpdatedShowIdsGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestRecentlyUpdatedShowIdsGetRequestHasCorrectRequestObjectType()
        {
            var recentlyUpdatedShowIdsGetRequest = new RecentlyUpdatedShowIdsGetRequest();
            recentlyUpdatedShowIdsGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.None);
        }
    }
}
