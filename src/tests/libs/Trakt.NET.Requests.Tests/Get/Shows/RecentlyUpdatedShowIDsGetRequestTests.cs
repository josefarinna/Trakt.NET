#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

using System.Globalization;

namespace TraktNET.GetRequests.Shows
{
    public sealed class RecentlyUpdatedShowIDsGetRequestTests
    {
        private const string URIPath = $"shows/updates/id";
        private const string StartDateURIValue = "2024-07-20T00:00:00Z";
        private static readonly DateTime StartDate = DateTime.Parse(StartDateURIValue, CultureInfo.InvariantCulture);

        [Theory]
        [InlineData(null, null, URIPath)]
        [InlineData(10, null, $"{URIPath}?page=10")]
        [InlineData(null, 20, $"{URIPath}?limit=20")]
        [InlineData(10, 20, $"{URIPath}?page=10&limit=20")]
        public void TestRecentlyUpdatedShowIDsGetRequestHasValidURIPath(int? page, int? limit, string expectedURIPath)
        {
            var recentlyUpdatedShowIDsGetRequest = new RecentlyUpdatedShowIDsGetRequest
            {
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            recentlyUpdatedShowIDsGetRequest.BuildUri();
            recentlyUpdatedShowIDsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(10, null, $"{URIPath}/{StartDateURIValue}?page=10")]
        [InlineData(null, 20, $"{URIPath}/{StartDateURIValue}?limit=20")]
        [InlineData(10, 20, $"{URIPath}/{StartDateURIValue}?page=10&limit=20")]
        public void TestRecentlyUpdatedShowIDsGetRequestHasValidURIPathWithStartDate(int? page, int? limit, string expectedURIPath)
        {
            var recentlyUpdatedShowIDsGetRequest = new RecentlyUpdatedShowIDsGetRequest
            {
                StartDate = StartDate,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            recentlyUpdatedShowIDsGetRequest.BuildUri();
            recentlyUpdatedShowIDsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestRecentlyUpdatedShowIDsGetRequestHasValidOAuthRequirement()
        {
            var recentlyUpdatedShowIDsGetRequest = new RecentlyUpdatedShowIDsGetRequest();
            recentlyUpdatedShowIDsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestRecentlyUpdatedShowIDsGetRequestIsGetRequest()
        {
            var recentlyUpdatedShowIDsGetRequest = new RecentlyUpdatedShowIDsGetRequest();
            recentlyUpdatedShowIDsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestRecentlyUpdatedShowIDsGetRequestHasCorrectRequestObjectType()
        {
            var recentlyUpdatedShowIDsGetRequest = new RecentlyUpdatedShowIDsGetRequest();
            recentlyUpdatedShowIDsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
