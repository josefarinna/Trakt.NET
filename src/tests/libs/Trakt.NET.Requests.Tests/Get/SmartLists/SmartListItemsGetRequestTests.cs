#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.SmartLists
{
    public sealed class SmartListItemsGetRequestTests
    {
        private const string URIPath = "smart-lists/123/items";

        [Theory]
        [InlineData(null, null, null, null, null, null, null, null, URIPath)]
        [InlineData(null, null, null, "us", null, null, null, null, $"{URIPath}?watchnow=us")]
        [InlineData(null, null, null, null, "us", null, null, null, $"{URIPath}?watchnow_country=us")]
        [InlineData(null, null, null, "us", "us", null, null, null, $"{URIPath}?watchnow=us&watchnow_country=us")]
        [InlineData(null, null, null, null, null, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, null, null, null, null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, null, null, null, null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, null, null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, null, null, null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, null, null, "us", "us", TraktExtendedInfo.Full, 10, 20, $"{URIPath}?watchnow=us&watchnow_country=us&extended=full&page=10&limit=20")]
        [InlineData(null, null, TraktSortHow.Ascending, null, null, null, null, null, $"{URIPath}/asc")]
        [InlineData(null, null, TraktSortHow.Descending, null, null, null, null, null, $"{URIPath}/desc")]
        [InlineData(null, TraktSortBy.Rank, null, null, null, null, null, null, $"{URIPath}/rank")]
        [InlineData(null, TraktSortBy.Rank, TraktSortHow.Ascending, null, null, null, null, null, $"{URIPath}/rank/asc")]
        [InlineData(null, TraktSortBy.Rank, TraktSortHow.Descending, null, null, null, null, null, $"{URIPath}/rank/desc")]
        [InlineData(TraktSmartListItemType.All, null, null, null, null, null, null, null, $"{URIPath}/all")]
        [InlineData(TraktSmartListItemType.Movies, null, null, null, null, null, null, null, $"{URIPath}/movies")]
        [InlineData(TraktSmartListItemType.Shows, null, null, null, null, null, null, null, $"{URIPath}/shows")]
        [InlineData(TraktSmartListItemType.Movies, TraktSortBy.Rank, null, null, null, null, null, null, $"{URIPath}/movies/rank")]
        [InlineData(TraktSmartListItemType.Movies, TraktSortBy.Rank, TraktSortHow.Descending, null, null, null, null, null, $"{URIPath}/movies/rank/desc")]
        [InlineData(TraktSmartListItemType.Movies, TraktSortBy.Rank, TraktSortHow.Descending, "us", "us", TraktExtendedInfo.Full, 10, 20, $"{URIPath}/movies/rank/desc?watchnow=us&watchnow_country=us&extended=full&page=10&limit=20")]
        public void TestSmartListItemsGetRequestHasValidURIPath(TraktSmartListItemType? type, TraktSortBy? sortBy,
            TraktSortHow? sortHow, string? watchnow, string? watchnowCountry,
            TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var request = new SmartListItemsGetRequest
            {
                ListId = "123",
                Type = type,
                SortBy = sortBy,
                SortHow = sortHow,
                Watchnow = watchnow,
                WatchnowCountry = watchnowCountry,
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
                Filter = filter
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"{URIPath}?query=game of thrones", UriKind.Relative));
        }

        [Fact]
        public void TestSmartListItemsGetRequestHasValidURIPathWithParentalFilter()
        {
            var filter = new TraktFilter
            {
                ParentalNudity = new Range<uint>(0, 1),
                ParentalIncludeUnrated = true
            };
            var request = new SmartListItemsGetRequest
            {
                ListId = "123",
                Filter = filter
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"{URIPath}?parental_nudity=0-1&parental_include_unrated=true", UriKind.Relative));
        }

        [Fact]
        public void TestSmartListItemsGetRequestHasValidURIPathWithSmartListFilters()
        {
            var filter = new TraktFilter
            {
                Studios = ["warner-bros-pictures"],
                People = ["christopher-nolan"],
                PeopleOperator = TraktFilterOperator.And,
                PeopleRole = TraktPeopleRole.Directing,
                ReleasedWithinDays = 30
            };
            var request = new SmartListItemsGetRequest
            {
                ListId = "123",
                Filter = filter
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"{URIPath}?studios=warner-bros-pictures&people=christopher-nolan&people_operator=and&people_role=directing&released_within_days=30", UriKind.Relative));
        }

        [Fact]
        public void TestSmartListItemsGetRequestHasValidOAuthRequirement()
        {
            var request = new SmartListItemsGetRequest { ListId = default! };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestSmartListItemsGetRequestIsGetRequest()
        {
            var request = new SmartListItemsGetRequest { ListId = default! };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSmartListItemsGetRequestHasCorrectRequestObjectType()
        {
            var request = new SmartListItemsGetRequest { ListId = default! };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestSmartListItemsGetRequestValidate()
        {
            var request = new SmartListItemsGetRequest { ListId = string.Empty };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SmartListItemsGetRequest { ListId = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SmartListItemsGetRequest { ListId = "id with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new SmartListItemsGetRequest { ListId = "id" };
            act = () => request.Validate();
            act.ShouldNotThrow();
        }
    }
}
