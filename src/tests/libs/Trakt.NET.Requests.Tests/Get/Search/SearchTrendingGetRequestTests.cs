#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Search
{
    public sealed class SearchTrendingGetRequestTests
    {
        [Theory]
        [InlineData(null, null, null, null, "search/recent_by_id/global/movies")]
        [InlineData("123", null, null, null, "search/recent_by_id/global/movies?query=123")]
        [InlineData(null, null, 10, null, "search/recent_by_id/global/movies?page=10")]
        [InlineData(null, null, null, 20, "search/recent_by_id/global/movies?limit=20")]
        [InlineData("123", null, 10, 20, "search/recent_by_id/global/movies?query=123&page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, null, null, "search/recent_by_id/global/movies")]
        [InlineData("123", TraktExtendedInfo.None, 10, 20, "search/recent_by_id/global/movies?query=123&page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, "search/recent_by_id/global/movies?extended=full")]
        [InlineData("123", TraktExtendedInfo.Full, 10, 20, "search/recent_by_id/global/movies?query=123&extended=full&page=10&limit=20")]
        public void TestSearchTrendingGetRequestHasValidURIPath(string? query, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var request = new SearchTrendingGetRequest
            {
                Type = TraktSearchRecentType.Movie,
                Query = query,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSearchTrendingGetRequestHasValidOAuthRequirement()
        {
            var request = new SearchTrendingGetRequest();
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSearchTrendingGetRequestIsGetRequest()
        {
            var request = new SearchTrendingGetRequest();
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSearchTrendingGetRequestHasCorrectRequestObjectType()
        {
            var request = new SearchTrendingGetRequest();
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSearchTrendingGetRequestValidate()
        {
            var request = new SearchTrendingGetRequest();
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
