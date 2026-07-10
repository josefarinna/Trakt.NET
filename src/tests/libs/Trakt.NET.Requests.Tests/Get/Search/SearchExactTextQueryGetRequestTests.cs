#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Search
{
    public sealed class SearchExactTextQueryGetRequestTests
    {
        [Theory]
        [InlineData(null, null, null, "search/movie/exact?query=123")]
        [InlineData(null, 10, null, "search/movie/exact?query=123&page=10")]
        [InlineData(null, null, 20, "search/movie/exact?query=123&limit=20")]
        [InlineData(null, 10, 20, "search/movie/exact?query=123&page=10&limit=20")]
        [InlineData(TraktExtendedInfo.None, null, null, "search/movie/exact?query=123")]
        [InlineData(TraktExtendedInfo.None, 10, null, "search/movie/exact?query=123&page=10")]
        [InlineData(TraktExtendedInfo.None, null, 20, "search/movie/exact?query=123&limit=20")]
        [InlineData(TraktExtendedInfo.None, 10, 20, "search/movie/exact?query=123&page=10&limit=20")]
        [InlineData(TraktExtendedInfo.Full, null, null, "search/movie/exact?query=123&extended=full")]
        [InlineData(TraktExtendedInfo.Full, 10, null, "search/movie/exact?query=123&extended=full&page=10")]
        [InlineData(TraktExtendedInfo.Full, null, 20, "search/movie/exact?query=123&extended=full&limit=20")]
        [InlineData(TraktExtendedInfo.Full, 10, 20, "search/movie/exact?query=123&extended=full&page=10&limit=20")]
        public void TestSearchExactTextQueryGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var request = new SearchExactTextQueryGetRequest
            {
                Type = TraktSearchResultType.Movie,
                Query = "123",
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSearchExactTextQueryGetRequestHasValidOAuthRequirement()
        {
            var request = new SearchExactTextQueryGetRequest { Query = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSearchExactTextQueryGetRequestIsGetRequest()
        {
            var request = new SearchExactTextQueryGetRequest { Query = default! };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSearchExactTextQueryGetRequestHasCorrectRequestObjectType()
        {
            var request = new SearchExactTextQueryGetRequest { Query = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSearchExactTextQueryGetRequestValidate()
        {
            var request = new SearchExactTextQueryGetRequest { Query = default! };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
