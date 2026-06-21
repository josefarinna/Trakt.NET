#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Lists
{
    public sealed class ListItemsGetRequestTests
    {
        private const string URIPath = "lists/123/items";

        [Theory]
        [InlineData(null, null, null, null, URIPath)]
        [InlineData(null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.None, null, null, $"{URIPath}")]
        [InlineData(null, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(null, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktSortHow.Unspecified, null, null, null, $"lists/123/items")]
        [InlineData(TraktSortHow.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(TraktSortHow.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktSortHow.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(TraktSortHow.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(TraktSortHow.Descending, null, null, null, $"lists/123/items/desc")]
        [InlineData(TraktSortHow.Descending, null, 10, null, $"{URIPath}/desc?page=10")]
        [InlineData(TraktSortHow.Descending, null, null, 20, $"{URIPath}/desc?limit=20")]
        [InlineData(TraktSortHow.Descending, null, 10, 20, $"{URIPath}/desc?page=10&limit=20")]
        [InlineData(TraktSortHow.Descending, TraktExtendedInfo.None, null, null, $"{URIPath}/desc")]
        [InlineData(TraktSortHow.Descending, TraktExtendedInfo.None, null, 20, $"{URIPath}/desc?limit=20")]
        [InlineData(TraktSortHow.Descending, TraktExtendedInfo.None, 10, 20, $"{URIPath}/desc?page=10&limit=20")]
        [InlineData(TraktSortHow.Descending, TraktExtendedInfo.Full, null, null, $"{URIPath}/desc?extended=full")]
        [InlineData(TraktSortHow.Descending, TraktExtendedInfo.Full, 10, null, $"{URIPath}/desc?extended=full&page=10")]
        [InlineData(TraktSortHow.Descending, TraktExtendedInfo.Full, null, 20, $"{URIPath}/desc?extended=full&limit=20")]
        [InlineData(TraktSortHow.Descending, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/desc?extended=full&page=10&limit=20")]
        [InlineData(TraktSortHow.Ascending, null, null, null, $"{URIPath}/asc")]
        [InlineData(TraktSortHow.Ascending, null, 10, null, $"{URIPath}/asc?page=10")]
        [InlineData(TraktSortHow.Ascending, null, null, 20, $"{URIPath}/asc?limit=20")]
        [InlineData(TraktSortHow.Ascending, null, 10, 20, $"{URIPath}/asc?page=10&limit=20")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.None, null, null, $"{URIPath}/asc")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.None, 10, null, $"{URIPath}/asc?page=10")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.None, null, 20, $"{URIPath}/asc?limit=20")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.None, 10, 20, $"{URIPath}/asc?page=10&limit=20")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.Full, null, null, $"{URIPath}/asc?extended=full")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.Full, 10, null, $"{URIPath}/asc?extended=full&page=10")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.Full, null, 20, $"{URIPath}/asc?extended=full&limit=20")]
        [InlineData(TraktSortHow.Ascending, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/asc?extended=full&page=10&limit=20")]
        public void TestListItemsGetRequestHasValidURIPath(TraktSortHow? sortHow, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var listItemsGetRequest = new ListItemsGetRequest
            {
                Id = "123",
                SortHow = sortHow,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            listItemsGetRequest.BuildUri();
            listItemsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestListItemsGetRequestHasValidOAuthRequirement()
        {
            var listItemsGetRequest = new ListItemsGetRequest { Id = default! };
            listItemsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestListItemsGetRequestIsGetRequest()
        {
            var listItemsGetRequest = new ListItemsGetRequest { Id = default! };
            listItemsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestListItemsGetRequestHasCorrectRequestObjectType()
        {
            var listItemsGetRequest = new ListItemsGetRequest { Id = default! };
            listItemsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestListItemsGetRequestValidate()
        {
            
            var listItemsGetRequest = new ListItemsGetRequest { Id = string.Empty };
            Action act = () => listItemsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            
            listItemsGetRequest = new ListItemsGetRequest { Id = "  " };
            act = () => listItemsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            
            listItemsGetRequest = new ListItemsGetRequest { Id = "id with spaces" };
            act = () => listItemsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
