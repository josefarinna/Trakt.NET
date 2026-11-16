using System.Net;

namespace TraktNET.SeasonsModule
{
    public sealed class GetSeasonListsTests
    {
        private const string GetSeasonListsUri = $"shows/{TestConstants.Shows.ShowID}/seasons/1/lists";
        private const uint SeasonNr = 1U;
        private const uint ListItemCount = 2U;
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const TraktListType ListType = TraktListType.Official;
        private const TraktListSortOrder ListSortOrder = TraktListSortOrder.Comments;

        [Theory]
        [InlineData(null, null, null, null, null, GetSeasonListsUri)]
        [InlineData(ListType, null, null, null, null, $"{GetSeasonListsUri}/official")]
        [InlineData(null, ListSortOrder, null, null, null, $"{GetSeasonListsUri}/comments")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, null, $"{GetSeasonListsUri}?extended=full")]
        [InlineData(null, null, null, Page, null, $"{GetSeasonListsUri}?page=2")]
        [InlineData(null, null, null, null, Limit, $"{GetSeasonListsUri}?limit=4")]
        [InlineData(ListType, ListSortOrder, TraktExtendedInfo.Full, Page, Limit, $"{GetSeasonListsUri}/official/comments?extended=full&page=2&limit=4")]
        public async Task TestGetSeasonListsWithID(TraktListType? listType, TraktListSortOrder? listSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonlists.json");

            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Seasons.GetSeasonListsAsync(TestConstants.Shows.TraktShowID, SeasonNr, listType, listSortOrder, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSeasonListsWithSlug()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonlists.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/lists", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Seasons.GetSeasonListsAsync(TestConstants.Shows.ShowSlug, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSeasonListsWithIDs()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonlists.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/lists", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Seasons.GetSeasonListsAsync(TestConstants.Shows.ShowIDs, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSeasonListsWithShow()
        {
            var show = new TraktShow
            {
                IDs = TestConstants.Shows.ShowIDs
            };

            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonlists.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"shows/{TestConstants.Shows.ShowSlug}/seasons/{SeasonNr}/lists", responseContent, 1, 1, 10, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Seasons.GetSeasonListsAsync(show, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetSeasonListsWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonlists.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 5, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Seasons.GetSeasonListsAsync(TestConstants.Shows.TraktShowID, SeasonNr, ListType, ListSortOrder, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSeasonListsWithIDPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonlists.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Seasons.GetSeasonListsAsync(TestConstants.Shows.TraktShowID, SeasonNr, ListType, ListSortOrder, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSeasonListsWithIDPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonlists.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Seasons.GetSeasonListsAsync(TestConstants.Shows.TraktShowID, SeasonNr, ListType, ListSortOrder, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSeasonListsWithIDPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonlists.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 1, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Seasons.GetSeasonListsAsync(TestConstants.Shows.TraktShowID, SeasonNr, ListType, ListSortOrder, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetSeasonListsWithIDPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonlists.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Seasons.GetSeasonListsAsync(TestConstants.Shows.TraktShowID, SeasonNr, ListType, ListSortOrder, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetSeasonListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetSeasonListsWithIDPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Seasons\\seasonlists.json");
            
            TraktClient client = ModuleTestUtility.GetClient($"{GetSeasonListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=1&limit={Limit}", responseContent, 1, 2, Limit, ListItemCount);

            TraktPagedResponse<TraktList> response = await client.Seasons.GetSeasonListsAsync(TestConstants.Shows.TraktShowID, SeasonNr, ListType, ListSortOrder, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetSeasonListsUri}/{ListType.ToURI()}/{ListSortOrder.ToURI()}?page=2&limit={Limit}", responseContent, 2, 2, Limit, ListItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)ListItemCount);
            response.ItemCount.ShouldBe(ListItemCount);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiSeasonNotFoundException))]
        public async Task TestGetSeasonListsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonListsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktList>>> act = () => client.Seasons.GetSeasonListsAsync(TestConstants.Shows.TraktShowID, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetSeasonListsWithIDsThrowsArgumentException()
        {
            TraktClient client = ModuleTestUtility.GetClient(GetSeasonListsUri, HttpStatusCode.OK);

            Func<Task<TraktPagedResponse<TraktList>>> act = () => client.Seasons.GetSeasonListsAsync(default(TraktShowIDs)!, SeasonNr, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonListsAsync(default(TraktShow)!, SeasonNr);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonListsAsync(new TraktShowIDs(), SeasonNr);
            await act.ShouldThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonListsAsync(0, SeasonNr);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
