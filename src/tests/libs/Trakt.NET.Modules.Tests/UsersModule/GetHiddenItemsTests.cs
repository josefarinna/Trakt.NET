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

        [Fact]
        public async Task TestGetHiddenItems()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetHiddenItemsUri, responseContent, 1, 1, 10, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetHiddenItemsWithType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?type={HiddenItemType.ToURI()}",
                responseContent, 1, 1, 10, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, HiddenItemType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetHiddenItemsWithTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?type={HiddenItemType.ToURI()}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, HiddenItemType, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetHiddenItemsWithTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?type={HiddenItemType.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, HiddenItemType, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetHiddenItemsWithTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?type={HiddenItemType.ToURI()}&limit={HiddenItemsLimit}",
                responseContent, 1, 1, HiddenItemsLimit, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, HiddenItemType, null, null, HiddenItemsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetHiddenItemsWithTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?type={HiddenItemType.ToURI()}&page={Page}&limit={HiddenItemsLimit}",
                responseContent, Page, 1, HiddenItemsLimit, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, HiddenItemType, null, Page, HiddenItemsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetHiddenItemsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetHiddenItemsWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetHiddenItemsWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?extended={ExtendedInfo.ToURI()}&limit={HiddenItemsLimit}",
                responseContent, 1, 1, HiddenItemsLimit, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, null, ExtendedInfo, null, HiddenItemsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetHiddenItemsWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={HiddenItemsLimit}",
                responseContent, Page, 1, HiddenItemsLimit, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, null, ExtendedInfo, Page, HiddenItemsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetHiddenItemsWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetHiddenItemsUri}?page={Page}", responseContent, Page, 1, 10, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetHiddenItemsWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?limit={HiddenItemsLimit}",
                responseContent, 1, 1, HiddenItemsLimit, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, null, null, null, HiddenItemsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetHiddenItemsWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?page={Page}&limit={HiddenItemsLimit}",
                responseContent, Page, 1, HiddenItemsLimit, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, null, null, Page, HiddenItemsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetHiddenItemsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\hiddenitems.json");
			
            TraktClient client = ModuleTestUtility.GetOAuthClient(
                $"{GetHiddenItemsUri}?type={HiddenItemType.ToURI()}" +
                $"&extended={ExtendedInfo.ToURI()}&page={Page}&limit={HiddenItemsLimit}",
                responseContent, Page, 1, HiddenItemsLimit, HiddenItemsCount);

            TraktPagedResponse<TraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HiddenItemsSection, HiddenItemType, ExtendedInfo, Page, HiddenItemsLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HiddenItemsCount);
            response.ItemCount.ShouldBe(HiddenItemsCount);
            response.Limit.ShouldBe(HiddenItemsLimit);
            response.Page.ShouldBe(Page);
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
        public async Task TestGetHiddenItemsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetHiddenItemsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HiddenItemsSection, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
