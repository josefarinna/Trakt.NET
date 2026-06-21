#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Lists
{
    public sealed class ListsPopularGetRequestTests
    {
        private const string URIPath = "lists/popular";

        [Theory]
        [InlineData(null, null, null, null, URIPath)]
        [InlineData(null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktListType.Unspecified, null, null, null, URIPath)]
        [InlineData(TraktListType.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktListType.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktListType.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktListType.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktListType.Unspecified, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktListType.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktListType.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktListType.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktListType.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktListType.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktListType.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktListType.Personal, null, null, null, $"{URIPath}/personal")]
        [InlineData(TraktListType.Personal, null, 10, null, $"{URIPath}/personal?page=10")]
        [InlineData(TraktListType.Personal, null, null, 20, $"{URIPath}/personal?limit=20")]
        [InlineData(TraktListType.Personal, null, 10, 20, $"{URIPath}/personal?page=10&limit=20")]
        [InlineData(TraktListType.Personal, TraktExtendedInfo.None, null, null, $"{URIPath}/personal")]
        [InlineData(TraktListType.Personal, TraktExtendedInfo.None, 10, null, $"{URIPath}/personal?page=10")]
        [InlineData(TraktListType.Personal, TraktExtendedInfo.None, null, 20, $"{URIPath}/personal?limit=20")]
        [InlineData(TraktListType.Personal, TraktExtendedInfo.None, 10, 20, $"{URIPath}/personal?page=10&limit=20")]
        [InlineData(TraktListType.Personal, TraktExtendedInfo.Full, null, null, $"{URIPath}/personal?extended=full")]
        [InlineData(TraktListType.Personal, TraktExtendedInfo.Full, 10, null, $"{URIPath}/personal?extended=full&page=10")]
        [InlineData(TraktListType.Personal, TraktExtendedInfo.Full, null, 20, $"{URIPath}/personal?extended=full&limit=20")]
        [InlineData(TraktListType.Personal, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/personal?extended=full&page=10&limit=20")]
        public void TestListsPopularGetRequestHasValidURIPath(TraktListType? type, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var listsPopularGetRequest = new ListsPopularGetRequest
            {
                Type = type,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            listsPopularGetRequest.BuildUri();
            listsPopularGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestListsPopularGetRequestHasValidOAuthRequirement()
        {
            var listsPopularGetRequest = new ListsPopularGetRequest();
            listsPopularGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestListsPopularGetRequestIsGetRequest()
        {
            var listsPopularGetRequest = new ListsPopularGetRequest();
            listsPopularGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestListsPopularGetRequestHasCorrectRequestObjectType()
        {
            var listsPopularGetRequest = new ListsPopularGetRequest();
            listsPopularGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }
    }
}
