#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.SmartLists
{
    public sealed class SmartListItemsGetRequestTests
    {
        private const string URIPath = "smart-lists/123/items/movies";

        [Theory]
        [InlineData(TraktSortBy.Rank, TraktSortHow.Ascending, null, null, null, null, $"{URIPath}/rank/asc")]
        [InlineData(TraktSortBy.Rank, TraktSortHow.Descending, null, null, null, null, $"{URIPath}/rank/desc")]
        [InlineData(TraktSortBy.Added, TraktSortHow.Ascending, null, null, null, null, $"{URIPath}/added/asc")]
        [InlineData(TraktSortBy.Rank, TraktSortHow.Ascending, "us", null, null, null, $"{URIPath}/rank/asc?watchnow=us")]
        [InlineData(TraktSortBy.Rank, TraktSortHow.Ascending, null, TraktExtendedInfo.None, null, null, $"{URIPath}/rank/asc")]
        [InlineData(TraktSortBy.Rank, TraktSortHow.Ascending, null, TraktExtendedInfo.Full, null, null, $"{URIPath}/rank/asc?extended=full")]
        [InlineData(TraktSortBy.Rank, TraktSortHow.Ascending, null, null, 10, null, $"{URIPath}/rank/asc?page=10")]
        [InlineData(TraktSortBy.Rank, TraktSortHow.Ascending, null, null, null, 20, $"{URIPath}/rank/asc?limit=20")]
        [InlineData(TraktSortBy.Rank, TraktSortHow.Ascending, null, null, 10, 20, $"{URIPath}/rank/asc?page=10&limit=20")]
        [InlineData(TraktSortBy.Rank, TraktSortHow.Ascending, "us", TraktExtendedInfo.Full, 10, 20, $"{URIPath}/rank/asc?watchnow=us&extended=full&page=10&limit=20")]
        public void TestSmartListItemsGetRequestHasValidURIPath(TraktSortBy sortBy, TraktSortHow sortHow,
            string? watchnow, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var request = new SmartListItemsGetRequest
            {
                ListId = "123",
                Type = TraktSmartListMediaType.Movies,
                SortBy = sortBy,
                SortHow = sortHow,
                Watchnow = watchnow,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSmartListItemsGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var request = new SmartListItemsGetRequest
            {
                ListId = "123",
                Type = TraktSmartListMediaType.Movies,
                SortBy = TraktSortBy.Rank,
                SortHow = TraktSortHow.Ascending,
                Filter = filter
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"{URIPath}/rank/asc?query=game of thrones", UriKind.Relative));
        }

        [Fact]
        public void TestSmartListItemsGetRequestHasValidOAuthRequirement()
        {
            var request = new SmartListItemsGetRequest { ListId = default!, Type = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestSmartListItemsGetRequestIsGetRequest()
        {
            var request = new SmartListItemsGetRequest { ListId = default!, Type = default! };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSmartListItemsGetRequestHasCorrectRequestObjectType()
        {
            var request = new SmartListItemsGetRequest { ListId = default!, Type = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestSmartListItemsGetRequestValidate()
        {
            var request = new SmartListItemsGetRequest { ListId = string.Empty, Type = TraktSmartListMediaType.Movies, SortBy = TraktSortBy.Rank, SortHow = TraktSortHow.Ascending };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SmartListItemsGetRequest { ListId = "  ", Type = TraktSmartListMediaType.Movies, SortBy = TraktSortBy.Rank, SortHow = TraktSortHow.Ascending };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SmartListItemsGetRequest { ListId = "id with spaces", Type = TraktSmartListMediaType.Movies, SortBy = TraktSortBy.Rank, SortHow = TraktSortHow.Ascending };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SmartListItemsGetRequest { ListId = "id", Type = TraktSmartListMediaType.Unspecified, SortBy = TraktSortBy.Rank, SortHow = TraktSortHow.Ascending };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SmartListItemsGetRequest { ListId = "id", Type = TraktSmartListMediaType.Movies, SortBy = TraktSortBy.Unspecified, SortHow = TraktSortHow.Ascending };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SmartListItemsGetRequest { ListId = "id", Type = TraktSmartListMediaType.Movies, SortBy = TraktSortBy.Rank, SortHow = TraktSortHow.Unspecified };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SmartListItemsGetRequest { ListId = "id", Type = TraktSmartListMediaType.Movies, SortBy = TraktSortBy.Rank, SortHow = TraktSortHow.Ascending };
            act = () => request.Validate();
            act.ShouldNotThrow();
        }
    }
}
