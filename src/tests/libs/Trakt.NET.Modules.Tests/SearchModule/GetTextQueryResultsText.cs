using System.Net;

namespace TraktNET.SearchModule
{
    public sealed class GetTextQueryResults
    {
        private readonly string GetTextQueryUri = $"search/{TextQueryTypeMovie.ToURI()}?query={TextQuery}";
        private readonly string GetTextQueryUriMulitpleTypes = $"search/{TextQueryTypeMovie.ToURI()},{TextQueryTypeShow.ToURI()}?query={TextQuery}";
        private const TraktSearchResultType TextQueryTypes = TraktSearchResultType.Movie | TraktSearchResultType.Show;
        private const string TextQuery = "batman";
        private const uint TextQueryItemCount = 10U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktSearchResultType TextQueryTypeMovie = TraktSearchResultType.Movie;
        private const TraktSearchResultType TextQueryTypeShow = TraktSearchResultType.Show;
        private const TraktSearchField TextQuerySearchFieldTitle = TraktSearchField.Title;
        private const TraktSearchField TextQuerySearchFieldOverview = TraktSearchField.Overview;
        private const TraktSearchField TextQuerySearchFields = TextQuerySearchFieldTitle | TextQuerySearchFieldOverview;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private readonly TraktFilter Filter = new()
        {
            Year = 2011U,
            Genres = ["action", "thriller"],
            Languages = ["en", "de"],
            Countries = ["us"],
            Runtimes = new Range<uint>(70, 140),
            Ratings = new Range<uint>(70, 95)
        };

        [Fact]
        public async Task TestGetTextQueryResults()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(GetTextQueryUri, responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypes()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(GetTextQueryUriMulitpleTypes, responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFieldTitle, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFields, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTextQueryUri}&{Filter}",
                                                           responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null, Filter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient($"{GetTextQueryUriMulitpleTypes}&{Filter}",
                                                           responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, null, Filter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFieldTitle, Filter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle, Filter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFields, Filter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields, Filter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&{Filter}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null, Filter, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&{Filter}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, null, Filter, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndExtendedInfoAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, Filter, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndExtendedInfoAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle,
                                                             Filter, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndExtendedInfoAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFields,
                                                             Filter, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndExtendedInfoAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields,
                                                             Filter, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&{Filter}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null,
                                                             Filter, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&{Filter}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, null,
                                                             Filter, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndExtendedInfoAndPageAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFieldTitle,
                                                             Filter, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndExtendedInfoAndPageAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle,
                                                             Filter, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndExtendedInfoAndPageAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFields,
                                                             Filter, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndExtendedInfoAndPageAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields,
                                                             Filter, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&{Filter}&extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null,
                                                             Filter, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&{Filter}&extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, null,
                                                             Filter, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndExtendedInfoAndLimitAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFieldTitle,
                                                             Filter, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndExtendedInfoAndLimitAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle,
                                                             Filter, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndExtendedInfoAndLimitAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFields,
                                                             Filter, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndExtendedInfoAndLimitAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields,
                                                             Filter, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&{Filter}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null,
                                                             Filter, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&{Filter}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, null,
                                                             Filter, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndPageAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFieldTitle,
                                                             Filter, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndPageAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle,
                                                             Filter, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndPageAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFields,
                                                             Filter, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndPageAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields,
                                                             Filter, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&{Filter}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null,
                                                             Filter, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&{Filter}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, null,
                                                             Filter, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndLimitAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFieldTitle,
                                                             Filter, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndLimitAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle,
                                                             Filter, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndLimitAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFields,
                                                             Filter, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndLimitAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields,
                                                             Filter, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&{Filter}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null,
                                                             Filter, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&{Filter}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, null,
                                                             Filter, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndPageAndLimitAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFieldTitle,
                                                             Filter, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndPageAndLimitAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle,
                                                             Filter, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithFilterAndPageAndLimitAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFields,
                                                             Filter, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithFilterAndPageAndLimitAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields,
                                                             Filter, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null,
                                                             null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, null,
                                                             null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithExtendedInfoAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithExtendedInfoAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle,
                                                             null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithExtendedInfoAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFields, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithExtendedInfoAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields,
                                                             null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null,
                                                             null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, null,
                                                             null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithExtendedInfoAndPageAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFieldTitle,
                                                             null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithExtendedInfoAndPageAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle,
                                                             null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithExtendedInfoAndPageAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFields,
                                                             null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithExtendedInfoAndPageAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields,
                                                             null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null,
                                                             null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, null,
                                                             null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithExtendedInfoAndLimitAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFieldTitle,
                                                             null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithExtendedInfoAndLimitAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle,
                                                             null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithExtendedInfoAndLimitAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFields,
                                                             null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithExtendedInfoAndLimitAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&extended={ExtendedInfo.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields,
                                                             null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null,
                                                             null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, null, null,
                                                             ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithExtendedInfoAndPageAndLimitAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFieldTitle,
                                                             null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithExtendedInfoAndPageAndLimitAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle,
                                                             null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithExtendedInfoAndPageAndLimitAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFields,
                                                             null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithExtendedInfoAndPageAndLimitAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields,
                                                             null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null,
                                                             null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, null,
                                                             null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithPageAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, null,
                                                             null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithPageAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery,
                                                             TextQuerySearchFieldTitle, null,
                                                             null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithPageAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFields, null,
                                                             null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithPageAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields,
                                                             null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null,
                                                             null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, null,
                                                             null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithLimitAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, null,
                                                             null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithLimitAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle,
                                                             null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithLimitAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFields, null, null,
                                                             null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithLimitAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields,
                                                             null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, null,
                                                             null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, null,
                                                             null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithPageAndLimitAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, null,
                                                             null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithPageAndLimitAndField()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle,
                                                             null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsWithPageAndLimitAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFields,
                                                             null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesWithPageAndLimitAndMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields,
                                                             null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, Filter,
                                                             ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFieldTitle,
                                                             Filter, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsCompleteWithMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery, TextQuerySearchFields,
                                                             Filter, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsMultipleTypesCompleteWithMultipleFields()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldTitle.ToURI()},{TextQuerySearchFieldOverview.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TextQuery, TextQuerySearchFields,
                                                             Filter, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetTextQueryResultsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 5, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, Filter,
                                                             ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetTextQueryResultsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, Filter,
                                                             ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetTextQueryResultsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, Filter,
                                                             ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetTextQueryResultsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 1, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, Filter,
                                                             ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetTextQueryResultsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, Filter,
                                                             ExtendedInfo, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, TextQueryItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetTextQueryResultsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=1&limit={Limit}",
                responseContent, 1, 2, Limit, TextQueryItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypeMovie, TextQuery,
                                                             TextQuerySearchFieldTitle, Filter,
                                                             ExtendedInfo, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldTitle.ToURI()}&{Filter}&extended={ExtendedInfo.ToURI()}&page=2&limit={Limit}",
                responseContent, 2, 2, Limit, TextQueryItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)TextQueryItemCount);
            response.ItemCount.ShouldBe(TextQueryItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        public async Task TestGetTextQueryResultsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient("search/movie?query=avengers", statusCode);

            try
            {
                await client.Search.GetTextQueryResultsAsync(TraktSearchResultType.Movie, "avengers", cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetTextQueryResultsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient("search/movie?query=avengers", "{}");

#pragma warning disable CS8625
            Func<Task<TraktPagedResponse<TraktSearchResult>>> act =
                () => client.Search.GetTextQueryResultsAsync(TraktSearchResultType.Movie, null, cancellationToken: TestContext.Current.CancellationToken);
#pragma warning restore CS8625
            await act.ShouldThrowAsync<TraktRequestValidationException>();

            act = () => client.Search.GetTextQueryResultsAsync(TraktSearchResultType.Movie, string.Empty, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
