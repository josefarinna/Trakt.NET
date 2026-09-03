#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Lists
{
    public sealed class ListItemsGetRequestTests
    {
        private const string URIPath = "lists/123/items";

        [Theory]
        [InlineData(null, null, null, null, null, null, URIPath)]
        [InlineData(null, null, null, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, null, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, null, null, TraktExtendedInfo.None, null, null, $"{URIPath}")]
        [InlineData(null, null, null, TraktExtendedInfo.None, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, null, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, null, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, null, null, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, null, null, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(null, null, null, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(null, null, null, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(null, null, TraktSortHow.Unspecified, null, null, null, $"lists/123/items")]
        [InlineData(null, null, TraktSortHow.Unspecified, null, 10, null, $"{URIPath}?page=10")]
        [InlineData(null, null, TraktSortHow.Unspecified, null, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, TraktSortHow.Unspecified, null, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, null, TraktSortHow.Unspecified, TraktExtendedInfo.None, null, null, URIPath)]
        [InlineData(null, null, TraktSortHow.Unspecified, TraktExtendedInfo.None, null, 20, $"{URIPath}?limit=20")]
        [InlineData(null, null, TraktSortHow.Unspecified, TraktExtendedInfo.None, 10, 20, $"{URIPath}?page=10&limit=20")]
        [InlineData(null, null, TraktSortHow.Unspecified, TraktExtendedInfo.Full, null, null, $"{URIPath}?extended=full")]
        [InlineData(null, null, TraktSortHow.Unspecified, TraktExtendedInfo.Full, 10, null, $"{URIPath}?extended=full&page=10")]
        [InlineData(null, null, TraktSortHow.Unspecified, TraktExtendedInfo.Full, null, 20, $"{URIPath}?extended=full&limit=20")]
        [InlineData(null, null, TraktSortHow.Unspecified, TraktExtendedInfo.Full, 10, 20, $"{URIPath}?extended=full&page=10&limit=20")]
        [InlineData(null, null, TraktSortHow.Descending, null, null, null, $"lists/123/items/desc")]
        [InlineData(null, null, TraktSortHow.Descending, null, 10, null, $"{URIPath}/desc?page=10")]
        [InlineData(null, null, TraktSortHow.Descending, null, null, 20, $"{URIPath}/desc?limit=20")]
        [InlineData(null, null, TraktSortHow.Descending, null, 10, 20, $"{URIPath}/desc?page=10&limit=20")]
        [InlineData(null, null, TraktSortHow.Descending, TraktExtendedInfo.None, null, null, $"{URIPath}/desc")]
        [InlineData(null, null, TraktSortHow.Descending, TraktExtendedInfo.None, null, 20, $"{URIPath}/desc?limit=20")]
        [InlineData(null, null, TraktSortHow.Descending, TraktExtendedInfo.None, 10, 20, $"{URIPath}/desc?page=10&limit=20")]
        [InlineData(null, null, TraktSortHow.Descending, TraktExtendedInfo.Full, null, null, $"{URIPath}/desc?extended=full")]
        [InlineData(null, null, TraktSortHow.Descending, TraktExtendedInfo.Full, 10, null, $"{URIPath}/desc?extended=full&page=10")]
        [InlineData(null, null, TraktSortHow.Descending, TraktExtendedInfo.Full, null, 20, $"{URIPath}/desc?extended=full&limit=20")]
        [InlineData(null, null, TraktSortHow.Descending, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/desc?extended=full&page=10&limit=20")]
        [InlineData(null, null, TraktSortHow.Ascending, null, null, null, $"{URIPath}/asc")]
        [InlineData(null, null, TraktSortHow.Ascending, null, 10, null, $"{URIPath}/asc?page=10")]
        [InlineData(null, null, TraktSortHow.Ascending, null, null, 20, $"{URIPath}/asc?limit=20")]
        [InlineData(null, null, TraktSortHow.Ascending, null, 10, 20, $"{URIPath}/asc?page=10&limit=20")]
        [InlineData(null, null, TraktSortHow.Ascending, TraktExtendedInfo.None, null, null, $"{URIPath}/asc")]
        [InlineData(null, null, TraktSortHow.Ascending, TraktExtendedInfo.None, 10, null, $"{URIPath}/asc?page=10")]
        [InlineData(null, null, TraktSortHow.Ascending, TraktExtendedInfo.None, null, 20, $"{URIPath}/asc?limit=20")]
        [InlineData(null, null, TraktSortHow.Ascending, TraktExtendedInfo.None, 10, 20, $"{URIPath}/asc?page=10&limit=20")]
        [InlineData(null, null, TraktSortHow.Ascending, TraktExtendedInfo.Full, null, null, $"{URIPath}/asc?extended=full")]
        [InlineData(null, null, TraktSortHow.Ascending, TraktExtendedInfo.Full, 10, null, $"{URIPath}/asc?extended=full&page=10")]
        [InlineData(null, null, TraktSortHow.Ascending, TraktExtendedInfo.Full, null, 20, $"{URIPath}/asc?extended=full&limit=20")]
        [InlineData(null, null, TraktSortHow.Ascending, TraktExtendedInfo.Full, 10, 20, $"{URIPath}/asc?extended=full&page=10&limit=20")]
        [InlineData(null, TraktSortBy.Rank, null, null, null, null, "lists/123/items/rank")]
        [InlineData(null, TraktSortBy.Rank, TraktSortHow.Ascending, null, null, null, "lists/123/items/rank/asc")]
        [InlineData(null, TraktSortBy.Rank, TraktSortHow.Descending, null, null, null, "lists/123/items/rank/desc")]
        [InlineData(null, TraktSortBy.Rank, TraktSortHow.Descending, TraktExtendedInfo.Full, 10, 20, "lists/123/items/rank/desc?extended=full&page=10&limit=20")]
        [InlineData(null, TraktSortBy.Added, null, null, null, null, "lists/123/items/added")]
        [InlineData(null, TraktSortBy.Title, null, null, null, null, "lists/123/items/title")]
        [InlineData(null, TraktSortBy.Released, null, null, null, null, "lists/123/items/released")]
        [InlineData(null, TraktSortBy.Runtime, null, null, null, null, "lists/123/items/runtime")]
        [InlineData(null, TraktSortBy.Popularity, null, null, null, null, "lists/123/items/popularity")]
        [InlineData(null, TraktSortBy.Percentage, null, null, null, null, "lists/123/items/percentage")]
        [InlineData(null, TraktSortBy.IMDBRating, null, null, null, null, "lists/123/items/imdb_rating")]
        [InlineData(null, TraktSortBy.TMDBRating, null, null, null, null, "lists/123/items/tmdb_rating")]
        [InlineData(null, TraktSortBy.RTTomatoMeter, null, null, null, null, "lists/123/items/rt_tomatometer")]
        [InlineData(null, TraktSortBy.RTAudience, null, null, null, null, "lists/123/items/rt_audience")]
        [InlineData(null, TraktSortBy.Metascore, null, null, null, null, "lists/123/items/metascore")]
        [InlineData(null, TraktSortBy.Votes, null, null, null, null, "lists/123/items/votes")]
        [InlineData(null, TraktSortBy.IMDBVotes, null, null, null, null, "lists/123/items/imdb_votes")]
        [InlineData(null, TraktSortBy.TMDBVotes, null, null, null, null, "lists/123/items/tmdb_votes")]
        [InlineData(null, TraktSortBy.MyRating, null, null, null, null, "lists/123/items/my_rating")]
        [InlineData(null, TraktSortBy.Random, null, null, null, null, "lists/123/items/random")]
        [InlineData(null, TraktSortBy.Watched, null, null, null, null, "lists/123/items/watched")]
        [InlineData(null, TraktSortBy.Collected, null, null, null, null, "lists/123/items/collected")]
        [InlineData(TraktListItemType.Movie, null, null, null, null, null, "lists/123/items/movie")]
        [InlineData(TraktListItemType.Movie, TraktSortBy.Rank, null, null, null, null, "lists/123/items/movie/rank")]
        [InlineData(TraktListItemType.Movie, TraktSortBy.Rank, TraktSortHow.Descending, null, null, null, "lists/123/items/movie/rank/desc")]
        [InlineData(TraktListItemType.Show, null, null, null, null, null, "lists/123/items/show")]
        [InlineData(TraktListItemType.Season, null, null, null, null, null, "lists/123/items/season")]
        [InlineData(TraktListItemType.Episode, null, null, null, null, null, "lists/123/items/episode")]
        [InlineData(TraktListItemType.Person, null, null, null, null, null, "lists/123/items/person")]
        [InlineData(TraktListItemType.Movie, TraktSortBy.Rank, TraktSortHow.Descending, TraktExtendedInfo.Full, 10, 20, "lists/123/items/movie/rank/desc?extended=full&page=10&limit=20")]
        public void TestListItemsGetRequestHasValidURIPath(TraktListItemType? type, TraktSortBy? sortBy, TraktSortHow? sortHow, TraktExtendedInfo? extendedInfo, int? page, int? limit, string expectedURIPath)
        {
            var listItemsGetRequest = new ListItemsGetRequest
            {
                Id = "123",
                Type = type,
                SortBy = sortBy,
                SortHow = sortHow,
                ExtendedInfo = extendedInfo,
                Page = (uint?)page,
                Limit = (uint?)limit
            };

            listItemsGetRequest.BuildUri();
            listItemsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestListItemsGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "batman" };
            var request = new ListItemsGetRequest
            {
                Id = "123",
                Filter = filter
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"{URIPath}?query=batman", UriKind.Relative));
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
