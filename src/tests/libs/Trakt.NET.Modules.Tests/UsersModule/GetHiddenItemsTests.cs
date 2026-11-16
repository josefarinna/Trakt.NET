using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetHiddenItemsTests
    {
        private readonly string GetHiddenItemsUri = $"users/hidden/{HiddenItemsSection.ToURI()}";
        private const uint HiddenItemsCount = 3U;
        private const uint HiddenItemsLimit = 4U;
        private const uint Page = 2U;
        private const TraktHiddenItemsSection HiddenItemsSection = TraktHiddenItemsSection.Calendar;
        private const TraktHiddenItemType HiddenItemType = TraktHiddenItemType.Movie;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Theory]
        [InlineData(null, null, null, null, "users/hidden/calendar")]
        [InlineData(HiddenItemType, null, null, null, "users/hidden/calendar?type=movie")]
        [InlineData(null, ExtendedInfo, null, null, "users/hidden/calendar?extended=full")]
        [InlineData(null, null, Page, null, "users/hidden/calendar?page=2")]
        [InlineData(null, null, null, HiddenItemsLimit, "users/hidden/calendar?limit=4")]
        [InlineData(HiddenItemType, ExtendedInfo, Page, HiddenItemsLimit, "users/hidden/calendar?type=movie" + $"&extended=full&page=2&limit=4")]
        public async Task TestGetHiddenItems(TraktHiddenItemType? hiddenItemType, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response = await client.Users.GetHiddenItemsAsync(HiddenItemsSection, hiddenItemType, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(limit ?? 10U);
            response.Page.ShouldBe(page ?? 1U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetHiddenItemsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?type={HiddenItemType.ToURI()}" +
                $"&extended={ExtendedInfo.ToURI()}&page=2&limit={HiddenItemsLimit}",
                responseContent, 2, 5, HiddenItemsLimit, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, HiddenItemType, ExtendedInfo, 2, HiddenItemsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetHiddenItemsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?type={HiddenItemType.ToURI()}" +
                $"&extended={ExtendedInfo.ToURI()}&page=2&limit={HiddenItemsLimit}",
                responseContent, 2, 2, HiddenItemsLimit, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, HiddenItemType, ExtendedInfo, 2, HiddenItemsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetHiddenItemsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?type={HiddenItemType.ToURI()}" +
                $"&extended={ExtendedInfo.ToURI()}&page=1&limit={HiddenItemsLimit}",
                responseContent, 1, 2, HiddenItemsLimit, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, HiddenItemType, ExtendedInfo, 1, HiddenItemsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetHiddenItemsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?type={HiddenItemType.ToURI()}" +
                $"&extended={ExtendedInfo.ToURI()}&page=1&limit={HiddenItemsLimit}",
                responseContent, 1, 1, HiddenItemsLimit, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, HiddenItemType, ExtendedInfo, 1, HiddenItemsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetHiddenItemsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?type={HiddenItemType.ToURI()}" +
                $"&extended={ExtendedInfo.ToURI()}&page=2&limit={HiddenItemsLimit}",
                responseContent, 2, 2, HiddenItemsLimit, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, HiddenItemType, ExtendedInfo, 2, HiddenItemsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetHiddenItemsUri}?type={HiddenItemType.ToURI()}" +
                $"&extended={ExtendedInfo.ToURI()}&page=1&limit={HiddenItemsLimit}",
                responseContent, 1, 2, HiddenItemsLimit, HiddenItemsCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetHiddenItemsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?type={HiddenItemType.ToURI()}" +
                $"&extended={ExtendedInfo.ToURI()}&page=1&limit={HiddenItemsLimit}",
                responseContent, 1, 2, HiddenItemsLimit, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, HiddenItemType, ExtendedInfo, 1, HiddenItemsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetHiddenItemsUri}?type={HiddenItemType.ToURI()}" +
                $"&extended={ExtendedInfo.ToURI()}&page=2&limit={HiddenItemsLimit}",
                responseContent, 2, 2, HiddenItemsLimit, HiddenItemsCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetHiddenItemsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetHiddenItemsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HiddenItemsSection, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
