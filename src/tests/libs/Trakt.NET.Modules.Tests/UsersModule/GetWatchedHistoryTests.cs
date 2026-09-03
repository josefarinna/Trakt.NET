using System.Globalization;
using System.Net;

namespace TraktNET.UsersModule
{
    public sealed class GetWatchedHistoryTests
    {
        private const string GetWatchedHistoryUri = $"users/{Username}/history";
        private const string Username = "sean";
        private const uint Page = 2U;
        private const uint HistoryLimit = 4U;
        private const uint HistoryItemCount = 4U;
        private const uint HistoryItemID = 4U;
        private const TraktSyncItemType HistoryItemType = TraktSyncItemType.Episode;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;
        private static readonly DateTime StartAt = DateTime.UtcNow.AddMonths(-1);
        private static readonly DateTime EndAt = DateTime.UtcNow;
        private readonly string HistoryStartAt = StartAt.ToUniversalTime().ToString("yyyy-MM-ddTHH:00:00Z", CultureInfo.InvariantCulture);
        private readonly string HistoryEndAt = EndAt.ToUniversalTime().ToString("yyyy-MM-ddTHH:00:00Z", CultureInfo.InvariantCulture);

        [Fact]
        public async Task TestGetWatchedHistory()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                GetWatchedHistoryUri,
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response = await client.Users.GetWatchedHistoryAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithOAuthEnforced()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetWatchedHistoryUri, responseContent, 1, 1, 10, HistoryItemCount);
            client.IgnoreOAuthIfOptional = false;

            TraktPagedResponse<TraktHistoryItem> response = await client.Users.GetWatchedHistoryAsync(Username, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithOAuthEnforcedForUsernameMe()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient("users/me/history", responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response = await client.Users.GetWatchedHistoryAsync("me", cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndId()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndStartDate()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}?start_at={HistoryStartAt}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, StartAt, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndStartDateAndEndDate()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, StartAt, EndAt, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}?start_at={HistoryStartAt}" +
                $"&end_at={HistoryEndAt}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, StartAt,
                                                          EndAt, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, StartAt, EndAt,
                                                          null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}?start_at={HistoryStartAt}" +
                $"&end_at={HistoryEndAt}&extended={ExtendedInfo.ToURI()}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, StartAt, EndAt,
                                                          null, ExtendedInfo, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}?start_at={HistoryStartAt}" +
                $"&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, StartAt,
                                                          null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}?start_at={HistoryStartAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, StartAt, null,
                                                          null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}?start_at={HistoryStartAt}" +
                $"&extended={ExtendedInfo.ToURI()}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, StartAt, null,
                                                          null, ExtendedInfo, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}?start_at={HistoryStartAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, StartAt, null,
                                                          null, ExtendedInfo, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndStartDateAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, StartAt,
                                                          null, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndStartDateAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, StartAt,
                                                          null, null, null, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndStartDateAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, StartAt,
                                                          null, null, null, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndEndDateAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?end_at={HistoryEndAt}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, null,
                                                          EndAt, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndEndDateAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?end_at={HistoryEndAt}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, null, EndAt,
                                                          null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndEndDateAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?end_at={HistoryEndAt}&extended={ExtendedInfo.ToURI()}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, null, EndAt,
                                                          null, ExtendedInfo, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndEndDateAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?end_at={HistoryEndAt}&extended={ExtendedInfo.ToURI()}&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID, null, EndAt,
                                                          null, ExtendedInfo, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndEndDateAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?end_at={HistoryEndAt}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          null, EndAt, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndEndDateAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?end_at={HistoryEndAt}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          null, EndAt, null, null, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndIdAndEndDateAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?end_at={HistoryEndAt}&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          null, EndAt, null, null, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}" +
                $"&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt,
                                                          null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt, null,
                                                          null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}" +
                $"&extended={ExtendedInfo.ToURI()}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt, null,
                                                          null, ExtendedInfo, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}&extended={ExtendedInfo.ToURI()}" +
                $"&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt, null,
                                                          null, ExtendedInfo, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDate()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt, null,
                                                          null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt, null,
                                                          null, null, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}" +
                $"&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt, null,
                                                          null, null, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt,
                                                          EndAt, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt, EndAt,
                                                          null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt, EndAt,
                                                          null, ExtendedInfo, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt, EndAt,
                                                          null, ExtendedInfo, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndEndDate()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}&end_at={HistoryEndAt}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt, EndAt, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndEndDateAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}" +
                $"&end_at={HistoryEndAt}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt, EndAt,
                                                          null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndEndDateAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}" +
                $"&end_at={HistoryEndAt}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt, EndAt,
                                                          null, null, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndStartDateAndEndDateAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?start_at={HistoryStartAt}" +
                $"&end_at={HistoryEndAt}&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, StartAt, EndAt,
                                                          null, null, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndEndDateAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?end_at={HistoryEndAt}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, null,
                                                          EndAt, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndEndDateAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, null, EndAt,
                                                          null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndEndDateAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, null, EndAt,
                                                          null, ExtendedInfo, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndEndDateAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, null, EndAt,
                                                          null, ExtendedInfo, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndEndDate()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?end_at={HistoryEndAt}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, null, EndAt, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndEndDateAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?end_at={HistoryEndAt}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, null,
                                                          EndAt, null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndEndDateAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?end_at={HistoryEndAt}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, null,
                                                          EndAt, null, null, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndEndDateAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?end_at={HistoryEndAt}" +
                $"&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, null, EndAt,
                                                          null, null, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null,
                                                          null, null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, null, null,
                                                          null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?extended={ExtendedInfo.ToURI()}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, null, null,
                                                          null, ExtendedInfo, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?extended={ExtendedInfo.ToURI()}" +
                $"&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, null, null,
                                                          null, ExtendedInfo, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, null, null,
                                                          null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, null, null,
                                                          null, null, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithTypeAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}?page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, null, null, null,
                                                          null, null, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt,
                                                          null, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, null,
                                                          null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&extended={ExtendedInfo.ToURI()}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, null,
                                                          null, ExtendedInfo, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&extended={ExtendedInfo.ToURI()}" +
                $"&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, null,
                                                          null, ExtendedInfo, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDate()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndEndDateAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&end_at={HistoryEndAt}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, EndAt, null, ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndEndDateAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, EndAt,
                                                          null, ExtendedInfo, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndEndDateAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, EndAt,
                                                          null, ExtendedInfo, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndEndDateAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&end_at={HistoryEndAt}&extended={ExtendedInfo.ToURI()}" +
                $"&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, EndAt,
                                                          null, ExtendedInfo, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndEndDate()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&end_at={HistoryEndAt}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, EndAt, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndEndDateAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&end_at={HistoryEndAt}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, EndAt,
                                                          null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndEndDateAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&end_at={HistoryEndAt}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, EndAt,
                                                          null, null, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndEndDateAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, EndAt,
                                                          null, null, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, null,
                                                          null, null, Page, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, null,
                                                          null, null, null, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithStartDateAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?start_at={HistoryStartAt}&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, StartAt, null,
                                                          null, null, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithEndDateAndExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?end_at={HistoryEndAt}&extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, endAt: EndAt, extendedInfo: ExtendedInfo,
                                                          cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithEndDateAndExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?end_at={HistoryEndAt}&extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, endAt: EndAt, extendedInfo: ExtendedInfo,
                                                          page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithEndDateAndExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?end_at={HistoryEndAt}&extended={ExtendedInfo.ToURI()}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, endAt: EndAt, extendedInfo: ExtendedInfo,
                                                          limit: HistoryLimit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithEndDateAndExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?end_at={HistoryEndAt}&extended={ExtendedInfo.ToURI()}" +
                $"&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, endAt: EndAt, extendedInfo: ExtendedInfo,
                                                          page: Page, limit: HistoryLimit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithEndDate()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?end_at={HistoryEndAt}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, null, null, null, EndAt, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithEndDateAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?end_at={HistoryEndAt}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, endAt: EndAt, page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithEndDateAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?end_at={HistoryEndAt}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, endAt: EndAt, limit: HistoryLimit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithEndDateAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?end_at={HistoryEndAt}&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, endAt: EndAt, page: Page, limit: HistoryLimit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?extended={ExtendedInfo.ToURI()}",
                responseContent, 1, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, extendedInfo: ExtendedInfo, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithExtendedInfoAndPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?extended={ExtendedInfo.ToURI()}&page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, extendedInfo: ExtendedInfo, page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithExtendedInfoAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?extended={ExtendedInfo.ToURI()}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, extendedInfo: ExtendedInfo, limit: HistoryLimit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithExtendedInfoAndPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, extendedInfo: ExtendedInfo, page: Page, limit: HistoryLimit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?page={Page}",
                responseContent, Page, 1, 10, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, page: Page, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(10u);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, limit: HistoryLimit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1u);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithPageAndLimit()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, page: Page, limit: HistoryLimit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryWithFilter()
        {
            var filter = new TraktFilter { Query = "batman" };
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");

            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}?query=batman&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, filter: filter, page: Page, limit: HistoryLimit, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={Page}&limit={HistoryLimit}",
                responseContent, Page, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          StartAt, EndAt, null, ExtendedInfo, Page, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={2}&limit={HistoryLimit}",
                responseContent, 2, 5, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          StartAt, EndAt, null, ExtendedInfo, 2, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={2}&limit={HistoryLimit}",
                responseContent, 2, 2, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          StartAt, EndAt, null, ExtendedInfo, 2, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={1}&limit={HistoryLimit}",
                responseContent, 1, 2, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          StartAt, EndAt, null, ExtendedInfo, 1, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={1}&limit={HistoryLimit}",
                responseContent, 1, 1, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          StartAt, EndAt, null, ExtendedInfo, 1, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={2}&limit={HistoryLimit}",
                responseContent, 2, 2, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          StartAt, EndAt, null, ExtendedInfo, 2, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client,
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={1}&limit={HistoryLimit}",
                responseContent, 1, 2, HistoryLimit, HistoryItemCount);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetWatchedHistoryPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Users\\history.json");
			
            TraktClient client = ModuleTestUtility.GetClient(
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page={1}&limit={HistoryLimit}",
                responseContent, 1, 2, HistoryLimit, HistoryItemCount);

            TraktPagedResponse<TraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(Username, HistoryItemType, HistoryItemID,
                                                          StartAt, EndAt, null, ExtendedInfo, 1, HistoryLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client,
                $"{GetWatchedHistoryUri}/{HistoryItemType.ToURI()}/{HistoryItemID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={ExtendedInfo.ToURI()}&page=2&limit={HistoryLimit}",
                responseContent, 2, 2, HistoryLimit, HistoryItemCount);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
			response.Content.Count.ShouldBe((int)HistoryItemCount);
            response.ItemCount.ShouldBe(HistoryItemCount);
            response.Limit.ShouldBe(HistoryLimit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiUserNotFoundException))]
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
        public async Task TestGetWatchedHistoryThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetWatchedHistoryUri, statusCode);

            Func<Task<TraktPagedResponse<TraktHistoryItem>>> act = () => client.Users.GetWatchedHistoryAsync(Username, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
