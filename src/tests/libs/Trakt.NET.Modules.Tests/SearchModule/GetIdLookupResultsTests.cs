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

        [Fact]
        public async Task TestGetIdLookupResults()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");

            TraktClient client = ModuleTestUtility.GetClient(GetIDLookupUri,
                                                           responseContent, 1, 1, 10, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response = await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithResultType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}",
                                                           responseContent, 1, 1, 10, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, IDLookupResultType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithResultTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&extended={ExtendedInfo.ToURI()}",
                                                           responseContent, 1, 1, 10, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, IDLookupResultType, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithResultTypeAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&extended={ExtendedInfo.ToURI()}&page={Page}",
                                                           responseContent, Page, 1, 10, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, IDLookupResultType, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithResultTypeAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&extended={ExtendedInfo.ToURI()}&limit={Limit}",
                                                           responseContent, 1, 1, Limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, IDLookupResultType, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithResultTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&page={Page}",
                                                           responseContent, Page, 1, 10, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, IDLookupResultType, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithResultTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&limit={Limit}",
                                                           responseContent, 1, 1, Limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, IDLookupResultType, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithResultTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&page={Page}&limit={Limit}",
                                                           responseContent, Page, 1, Limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, IDLookupResultType, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetIDLookupUri}?extended={ExtendedInfo.ToURI()}",
                                                           responseContent, 1, 1, 10, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetIDLookupUri}?extended={ExtendedInfo.ToURI()}&page={Page}",
                                                           responseContent, Page, 1, 10, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetIDLookupUri}?extended={ExtendedInfo.ToURI()}&limit={Limit}",
                                                           responseContent, 1, 1, Limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, null, ExtendedInfo, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetIDLookupUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                                                           responseContent, Page, 1, Limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetIDLookupUri}?page={Page}",
                                                           responseContent, Page, 1, 10, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetIDLookupUri}?limit={Limit}", responseContent, 1, 1, Limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, null, null, null, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient($"{GetIDLookupUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetIDLookupUri}?type={IDLookupResultType.ToURI()}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}",
                responseContent, Page, 1, Limit, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, IDLookupResultType, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetIdLookupResultsWithResultTypeUnspecified()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient(GetIDLookupUri, responseContent, 1, 1, 10, IDLookupItemCount);

            TraktPagedResponse<TraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(IDLookupType, LookupID, TraktSearchResultType.Unspecified, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)IDLookupItemCount);
            response.ItemCount.ShouldBe(IDLookupItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
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
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetIdLookupResultsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Searchs\\searchresult.json");
			
            TraktClient client = ModuleTestUtility.GetClient("search/trakt/123", statusCode);

            Func<Task<TraktPagedResponse<TraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(TraktSearchIDType.Trakt, "123", cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
