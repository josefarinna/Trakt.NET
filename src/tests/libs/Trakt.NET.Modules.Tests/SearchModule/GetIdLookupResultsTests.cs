using System.Net;

namespace TraktNET.SearchModule
{
    public sealed class GetIdLookupResultsTests
    {
        private readonly string GetIDLookupUri = $"search/{IDLookupType.ToURI()}/{LookupID}";
        private const string LookupID = "tt0848228";
        private const uint IDLookupItemCount = 10U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktSearchIDType IDLookupType = TraktSearchIDType.ImDB;
        private const TraktSearchResultType IDLookupResultType = TraktSearchResultType.Movie;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, null, $"search/imdb/{LookupID}")]
        [InlineData(IDLookupResultType, null, null, null, $"search/imdb/{LookupID}?type=movie")]
        [InlineData(null, ExtendedInfo, null, null, $"search/imdb/{LookupID}?extended=full")]
        [InlineData(null, null, Page, null, $"search/imdb/{LookupID}?page=2")]
        [InlineData(null, null, null, Limit, $"search/imdb/{LookupID}?limit=4")]
        [InlineData(IDLookupResultType, ExtendedInfo, Page, Limit, $"search/imdb/{LookupID}?type=movie&extended=full&page=2&limit=4")]
        [InlineData(TraktSearchResultType.Unspecified, null, null, null, $"search/imdb/{LookupID}")]
        public async Task TestGetIdLookupResults(TraktSearchResultType? searchResultTypes, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response = await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, searchResultTypes, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, IDLookupResultType, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetIdLookupResultsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}", responseContent, 2, 2, Limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, IDLookupResultType, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetIdLookupResultsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}", responseContent, 1, 2, Limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, IDLookupResultType, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetIdLookupResultsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}", responseContent, 1, 1, Limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, IDLookupResultType, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetIdLookupResultsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}", responseContent, 2, 2, Limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, IDLookupResultType, ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}", responseContent, 1, 2, Limit, IDLookupItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetIdLookupResultsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}", responseContent, 1, 2, Limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, IDLookupResultType, ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}", responseContent, 2, 2, Limit, IDLookupItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetIdLookupResultsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient("search/trakt/123", statusCode);

            Func<Task<TraktPagedResponse<TraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(TraktSearchIDType.Trakt, "123", cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
