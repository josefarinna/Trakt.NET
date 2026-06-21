#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Search
{
    public sealed class SearchIDLookupGetRequestTests
    {
        [Theory]
        [InlineData(null, null, null, null, "search/trakt/123")]
        [InlineData(null, null, 10, null, "search/trakt/123?page=10")]
        [InlineData(null, null, null, 20, "search/trakt/123?limit=20")]
        [InlineData(null, null, 10, 20, "search/trakt/123?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, null, null, "search/trakt/123")]
        [InlineData(null, TraktExtendedInfo.None, 10, null, "search/trakt/123?page=10")]
        [InlineData(null, TraktExtendedInfo.None, null, 20, "search/trakt/123?limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, 20, "search/trakt/123?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, "search/trakt/123?extended=full")]
        [InlineData(null, TraktExtendedInfo.Full, 10, null, "search/trakt/123?extended=full&page=10")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20, "search/trakt/123?extended=full&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, 10, 20, "search/trakt/123?extended=full&page=10&limit=20")]
        [InlineData(TraktSearchResultType.Unspecified, null, null, null, "search/trakt/123")]
        [InlineData(TraktSearchResultType.Unspecified, null, 10, null, "search/trakt/123?page=10")]
        [InlineData(TraktSearchResultType.Unspecified, null, null, 20, "search/trakt/123?limit=20")]
        [InlineData(TraktSearchResultType.Unspecified, null, 10, 20, "search/trakt/123?page=10&limit=20")]
        [InlineData(TraktSearchResultType.Unspecified, TraktExtendedInfo.None, null, null, "search/trakt/123")]
        [InlineData(TraktSearchResultType.Unspecified, TraktExtendedInfo.None, 10, null, "search/trakt/123?page=10")]
        [InlineData(TraktSearchResultType.Unspecified, TraktExtendedInfo.None, null, 20, "search/trakt/123?limit=20")]
        [InlineData(TraktSearchResultType.Unspecified, TraktExtendedInfo.None, 10, 20, "search/trakt/123?page=10&limit=20")]
        [InlineData(TraktSearchResultType.Unspecified, TraktExtendedInfo.Full, null, null, "search/trakt/123?extended=full")]
        [InlineData(TraktSearchResultType.Unspecified, TraktExtendedInfo.Full, 10, null, "search/trakt/123?extended=full&page=10")]
        [InlineData(TraktSearchResultType.Unspecified, TraktExtendedInfo.Full, null, 20, "search/trakt/123?extended=full&limit=20")]
        [InlineData(TraktSearchResultType.Unspecified, TraktExtendedInfo.Full, 10, 20, "search/trakt/123?extended=full&page=10&limit=20")]
        [InlineData(TraktSearchResultType.Movie, null, null, null, "search/trakt/123?type=movie")]
        [InlineData(TraktSearchResultType.Movie, null, 10, null, "search/trakt/123?type=movie&page=10")]
        [InlineData(TraktSearchResultType.Movie, null, null, 20, "search/trakt/123?type=movie&limit=20")]
        [InlineData(TraktSearchResultType.Movie, null, 10, 20, "search/trakt/123?type=movie&page=10&limit=20")]
        [InlineData(TraktSearchResultType.Movie, TraktExtendedInfo.None, null, null, "search/trakt/123?type=movie")]
        [InlineData(TraktSearchResultType.Movie, TraktExtendedInfo.None, 10, null, "search/trakt/123?type=movie&page=10")]
        [InlineData(TraktSearchResultType.Movie, TraktExtendedInfo.None, null, 20, "search/trakt/123?type=movie&limit=20")]
        [InlineData(TraktSearchResultType.Movie, TraktExtendedInfo.None, 10, 20, "search/trakt/123?type=movie&page=10&limit=20")]
        [InlineData(TraktSearchResultType.Movie, TraktExtendedInfo.Full, null, null, "search/trakt/123?type=movie&extended=full")]
        [InlineData(TraktSearchResultType.Movie, TraktExtendedInfo.Full, 10, null, "search/trakt/123?type=movie&extended=full&page=10")]
        [InlineData(TraktSearchResultType.Movie, TraktExtendedInfo.Full, null, 20, "search/trakt/123?type=movie&extended=full&limit=20")]
        [InlineData(TraktSearchResultType.Movie, TraktExtendedInfo.Full, 10, 20, "search/trakt/123?type=movie&extended=full&page=10&limit=20")]
        public void TestSearchIDLookupGetRequestHasValidURIPath(TraktSearchResultType? resultTypes, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var searchIDLookupGetRequest = new SearchIDLookupGetRequest
            {
                IdType = (TraktSearchIDType)1,
                LookupId = "123",
                ResultTypes = resultTypes,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            searchIDLookupGetRequest.BuildUri();
            searchIDLookupGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSearchIDLookupGetRequestHasValidOAuthRequirement()
        {
            var searchIDLookupGetRequest = new SearchIDLookupGetRequest { LookupId = default! };
            searchIDLookupGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestSearchIDLookupGetRequestIsGetRequest()
        {
            var searchIDLookupGetRequest = new SearchIDLookupGetRequest { LookupId = default! };
            searchIDLookupGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSearchIDLookupGetRequestHasCorrectRequestObjectType()
        {
            var searchIDLookupGetRequest = new SearchIDLookupGetRequest { LookupId = default! };
            searchIDLookupGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestSearchIDLookupGetRequestValidate()
        {
            var searchIDLookupGetRequest = new SearchIDLookupGetRequest { LookupId = default! };
            Action act = () => searchIDLookupGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
