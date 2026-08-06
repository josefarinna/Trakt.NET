#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Search
{
    public sealed class SearchTextQueryGetRequestTests
    {
        [Theory]
        [InlineData(null, null, null, null, "search/movie?query=123")]
        [InlineData(null, null, 10, null, "search/movie?query=123&page=10")]
        [InlineData(null, null, null, 20, "search/movie?query=123&limit=20")]
        [InlineData(null, null, 10, 20, "search/movie?query=123&page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, null, null, "search/movie?query=123")]
        [InlineData(null, TraktExtendedInfo.None, 10, null, "search/movie?query=123&page=10")]
        [InlineData(null, TraktExtendedInfo.None, null, 20, "search/movie?query=123&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, 20, "search/movie?query=123&page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, "search/movie?query=123&extended=full")]
        [InlineData(null, TraktExtendedInfo.Full, 10, null, "search/movie?query=123&extended=full&page=10")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20, "search/movie?query=123&extended=full&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, 10, 20, "search/movie?query=123&extended=full&page=10&limit=20")]
        [InlineData(TraktSearchFields.Unspecified, null, null, null, "search/movie?query=123")]
        [InlineData(TraktSearchFields.Unspecified, null, 10, null, "search/movie?query=123&page=10")]
        [InlineData(TraktSearchFields.Unspecified, null, null, 20, "search/movie?query=123&limit=20")]
        [InlineData(TraktSearchFields.Unspecified, null, 10, 20, "search/movie?query=123&page=10&limit=20")]
        [InlineData(TraktSearchFields.Unspecified, TraktExtendedInfo.None, null, null, "search/movie?query=123")]
        [InlineData(TraktSearchFields.Unspecified, TraktExtendedInfo.None, 10, null, "search/movie?query=123&page=10")]
        [InlineData(TraktSearchFields.Unspecified, TraktExtendedInfo.None, null, 20, "search/movie?query=123&limit=20")]
        [InlineData(TraktSearchFields.Unspecified, TraktExtendedInfo.None, 10, 20, "search/movie?query=123&page=10&limit=20")]
        [InlineData(TraktSearchFields.Unspecified, TraktExtendedInfo.Full, null, null, "search/movie?query=123&extended=full")]
        [InlineData(TraktSearchFields.Unspecified, TraktExtendedInfo.Full, 10, null, "search/movie?query=123&extended=full&page=10")]
        [InlineData(TraktSearchFields.Unspecified, TraktExtendedInfo.Full, null, 20, "search/movie?query=123&extended=full&limit=20")]
        [InlineData(TraktSearchFields.Unspecified, TraktExtendedInfo.Full, 10, 20, "search/movie?query=123&extended=full&page=10&limit=20")]
        [InlineData(TraktSearchFields.Title, null, null, null, "search/movie?query=123&fields=title")]
        [InlineData(TraktSearchFields.Title, null, 10, null, "search/movie?query=123&fields=title&page=10")]
        [InlineData(TraktSearchFields.Title, null, null, 20, "search/movie?query=123&fields=title&limit=20")]
        [InlineData(TraktSearchFields.Title, null, 10, 20, "search/movie?query=123&fields=title&page=10&limit=20")]
        [InlineData(TraktSearchFields.Title, TraktExtendedInfo.None, null, null, "search/movie?query=123&fields=title")]
        [InlineData(TraktSearchFields.Title, TraktExtendedInfo.None, 10, null, "search/movie?query=123&fields=title&page=10")]
        [InlineData(TraktSearchFields.Title, TraktExtendedInfo.None, null, 20, "search/movie?query=123&fields=title&limit=20")]
        [InlineData(TraktSearchFields.Title, TraktExtendedInfo.None, 10, 20, "search/movie?query=123&fields=title&page=10&limit=20")]
        [InlineData(TraktSearchFields.Title, TraktExtendedInfo.Full, null, null, "search/movie?query=123&fields=title&extended=full")]
        [InlineData(TraktSearchFields.Title, TraktExtendedInfo.Full, 10, null, "search/movie?query=123&fields=title&extended=full&page=10")]
        [InlineData(TraktSearchFields.Title, TraktExtendedInfo.Full, null, 20, "search/movie?query=123&fields=title&extended=full&limit=20")]
        [InlineData(TraktSearchFields.Title, TraktExtendedInfo.Full, 10, 20, "search/movie?query=123&fields=title&extended=full&page=10&limit=20")]
        public void TestSearchTextQueryGetRequestHasValidURIPath(TraktSearchFields? searchField, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var searchTextQueryGetRequest = new SearchTextQueryGetRequest
            {
                Type = (TraktSearchResultType)1,
                Query = "123",
                SearchField = searchField,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            searchTextQueryGetRequest.BuildUri();
            searchTextQueryGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSearchTextQueryGetRequestHasValidOAuthRequirement()
        {
            var searchTextQueryGetRequest = new SearchTextQueryGetRequest { Query = default! };
            searchTextQueryGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSearchTextQueryGetRequestIsGetRequest()
        {
            var searchTextQueryGetRequest = new SearchTextQueryGetRequest { Query = default! };
            searchTextQueryGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSearchTextQueryGetRequestHasCorrectRequestObjectType()
        {
            var searchTextQueryGetRequest = new SearchTextQueryGetRequest { Query = default! };
            searchTextQueryGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSearchTextQueryGetRequestValidate()
        {
            var searchTextQueryGetRequest = new SearchTextQueryGetRequest { Query = default! };
            Action act = () => searchTextQueryGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
