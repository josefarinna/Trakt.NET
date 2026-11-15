using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieListsTests
    {
        private const string GetMovieListsUriPrefix = "movies";
        private const string GetMovieListsUriSuffix = "lists";
        private const string GetMovieListsUriWithSlug = GetMovieListsUriPrefix + "/" + TestConstants.Movies.MovieSlug + "/" + GetMovieListsUriSuffix;
        private static readonly string GetMovieListsUri = $"{GetMovieListsUriPrefix}/{TestConstants.Movies.TraktMovieID}/{GetMovieListsUriSuffix}";

        [Theory]
        [InlineData(null, null, null, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?extended=full", "Movies\\movielists.json")]
        [InlineData(null, null, null, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?page=4", "Movies\\movielists.json")]
        [InlineData(null, null, null, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, null, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, null, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/updated?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official/updated?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/updated?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official/updated?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        public async Task TestGetMovieListsWithID(TraktListType? listType, TraktListSortOrder? listSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.TraktMovieID, listType, listSortOrder, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);

            IReadOnlyList<TraktList> movieLists = response.Content!;

            TraktList movieList = movieLists[0];

            movieList.Name.ShouldBe("MARVEL Cinematic Universe");
            movieList.Description.ShouldBe("MCU Shows and Movies in chronological order.");

            movieList = movieLists[1];

            movieList.Name.ShouldBe("Top Watched Movies of The Week / >60");
            movieList.Description.ShouldBe("This list is maintained by mdblist.com");
        }

        [Theory]
        [InlineData(null, null, null, null, null, GetMovieListsUriWithSlug, "Movies\\movielists.json")]
        public async Task TestGetMovieListsWithSlug(TraktListType? listType, TraktListSortOrder? listSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieSlug, listType, listSortOrder, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);

            IReadOnlyList<TraktList> movieLists = response.Content!;

            TraktList movieList = movieLists[0];

            movieList.Name.ShouldBe("MARVEL Cinematic Universe");
            movieList.Description.ShouldBe("MCU Shows and Movies in chronological order.");

            movieList = movieLists[1];

            movieList.Name.ShouldBe("Top Watched Movies of The Week / >60");
            movieList.Description.ShouldBe("This list is maintained by mdblist.com");
        }

        [Theory]
        [InlineData(null, null, null, null, null, GetMovieListsUriWithSlug, "Movies\\movielists.json")]
        public async Task TestGetMovieListsWithIDs(TraktListType? listType, TraktListSortOrder? listSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieIDs, listType, listSortOrder, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);

            IReadOnlyList<TraktList> movieLists = response.Content!;

            TraktList movieList = movieLists[0];

            movieList.Name.ShouldBe("MARVEL Cinematic Universe");
            movieList.Description.ShouldBe("MCU Shows and Movies in chronological order.");

            movieList = movieLists[1];

            movieList.Name.ShouldBe("Top Watched Movies of The Week / >60");
            movieList.Description.ShouldBe("This list is maintained by mdblist.com");
        }

        [Fact]
        public async Task TestGetMovieListsWithIDPagingHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.TraktMovieID, page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(false);
        }

        [Fact]
        public async Task TestGetMovieListsWithIDPagingHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.TraktMovieID, page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(true);
        }

        [Fact]
        public async Task TestGetMovieListsWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.TraktMovieID, page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(3U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(true);
        }

        [Fact]
        public async Task TestGetMovieListsWithIDPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.TraktMovieID, page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(false);
        }

        [Fact]
        public async Task TestGetMovieListsWithIDPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.TraktMovieID, page: 2, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(false);

            ModuleTestUtility.SetClient(client, $"{GetMovieListsUri}?page=1", responseContent, 1, 2, 10, 2);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(true);
        }

        [Fact]
        public async Task TestGetMovieListsWithIDPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.TraktMovieID, page: 1, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(true);

            ModuleTestUtility.SetClient(client, $"{GetMovieListsUri}?page=2", responseContent, 2, 2, 10, 2);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(false);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
        public async Task TestGetMovieListsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieListsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktList>>> act = () => client.Movies.GetMovieListsAsync(TestConstants.Movies.TraktMovieID, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldBeOfType(exceptionType);
        }

        [Fact]
        public async Task TestGetMovieListsWithIDsThrowsArgumentException()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieListsUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktPagedResponse<TraktList>>> act = () => client.Movies.GetMovieListsAsync(default(TraktMovieIDs));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieListsAsync(movieIDs);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
