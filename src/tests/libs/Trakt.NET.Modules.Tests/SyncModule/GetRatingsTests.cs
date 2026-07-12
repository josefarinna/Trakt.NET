using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetRatingsTests
    {
        private const string GetRatingsUri = "sync/ratings";
        private const uint Page = 2U;
        private const uint Limit = 4U;
        private const uint ItemCount = 4U;
        private const TraktRatingsItemType RatingsType = TraktRatingsItemType.Movie;
        private const TraktExtendedInfo ExtendedInfo = TraktExtendedInfo.Full;

        [Fact]
        public async Task TestGetRatings()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetRatingsUri}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktRatingsItem> response = await client.Sync.GetRatingsAsync(null, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            var items = response.Content!.ToArray();
            items.Length.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);

            items[0].RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            items[0].Rating.ShouldBe(10);
            items[0].Type.ShouldBe(TraktRatingsItemType.Movie);
            items[0].Movie.ShouldNotBeNull();
            items[0].Movie!.Title.ShouldBe("TRON: Legacy");
            items[0].Movie!.IDs!.Trakt.ShouldBe(1U);

            items[1].RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            items[1].Rating.ShouldBe(10);
            items[1].Type.ShouldBe(TraktRatingsItemType.Show);
            items[1].Show.ShouldNotBeNull();
            items[1].Show!.Title.ShouldBe("Breaking Bad");
            items[1].Show!.IDs!.Trakt.ShouldBe(1U);

            items[2].RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            items[2].Rating.ShouldBe(8);
            items[2].Type.ShouldBe(TraktRatingsItemType.Season);
            items[2].Season.ShouldNotBeNull();
            items[2].Season!.Number.ShouldBe(0U);
            items[2].Show.ShouldNotBeNull();
            items[2].Show!.Title.ShouldBe("Breaking Bad");

            items[3].RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2014-09-01T09:10:11.000Z"));
            items[3].Rating.ShouldBe(5);
            items[3].Type.ShouldBe(TraktRatingsItemType.Episode);
            items[3].Episode.ShouldNotBeNull();
            items[3].Episode!.Season.ShouldBe(4U);
            items[3].Episode!.Number.ShouldBe(1U);
            items[3].Show.ShouldNotBeNull();
            items[3].Show!.Title.ShouldBe("Breaking Bad");
        }

        [Fact]
        public async Task TestGetRatingsWithRatingsType()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetRatingsUri}/{RatingsType.ToURI()}?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktRatingsItem> response = await client.Sync.GetRatingsAsync(RatingsType, null, null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithRatingsFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetRatingsUri}/shows/10?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktRatingsItem> response = await client.Sync.GetRatingsAsync(TraktRatingsItemType.Show, [10], null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithRatingsFilterMultiple()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetRatingsUri}/seasons/8,10?page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktRatingsItem> response = await client.Sync.GetRatingsAsync(TraktRatingsItemType.Season, [8, 10], null, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsWithExtendedInfo()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetRatingsUri}?extended={ExtendedInfo.ToURI()}&page={Page}&limit={Limit}", responseContent, Page, 1, Limit, 10);

            TraktPagedResponse<TraktRatingsItem> response = await client.Sync.GetRatingsAsync(null, null, ExtendedInfo, Page, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(Page);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsComplete()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetRatingsUri}/episodes/5,8?extended=full&page=3&limit=10", responseContent, 3, 1, 10, 10);

            TraktPagedResponse<TraktRatingsItem> response = await client.Sync.GetRatingsAsync(TraktRatingsItemType.Episode, [5, 8], TraktExtendedInfo.Full, 3U, 10U, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(10U);
            response.Page.ShouldBe(3U);
            response.PageCount.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetRatingsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetRatingsUri}?page=2&limit={Limit}", responseContent, 2, 5, Limit, 10);

            TraktPagedResponse<TraktRatingsItem> response = await client.Sync.GetRatingsAsync(null, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(5U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetRatingsPagingOnlyHasPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetRatingsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, 10);

            TraktPagedResponse<TraktRatingsItem> response = await client.Sync.GetRatingsAsync(null, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetRatingsPagingOnlyHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetRatingsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, 10);

            TraktPagedResponse<TraktRatingsItem> response = await client.Sync.GetRatingsAsync(null, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetRatingsPagingNotHasPreviousPageOrHasNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetRatingsUri}?page=1&limit={Limit}", responseContent, 1, 1, Limit, 10);

            TraktPagedResponse<TraktRatingsItem> response = await client.Sync.GetRatingsAsync(null, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(1U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeFalse();
        }

        [Fact]
        public async Task TestGetRatingsPagingGetPreviousPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetRatingsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, 10);

            TraktPagedResponse<TraktRatingsItem> response = await client.Sync.GetRatingsAsync(null, null, null, 2, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(2U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeTrue();
            response.HasNextPage.ShouldBeFalse();

            ModuleTestUtility.SetClient(client, $"{GetRatingsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, 10);

            response = await response.GetPreviousPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();
        }

        [Fact]
        public async Task TestGetRatingsPagingGetNextPage()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient($"{GetRatingsUri}?page=1&limit={Limit}", responseContent, 1, 2, Limit, 10);

            TraktPagedResponse<TraktRatingsItem> response = await client.Sync.GetRatingsAsync(null, null, null, 1, Limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(Limit);
            response.Page.ShouldBe(1U);
            response.PageCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBeFalse();
            response.HasNextPage.ShouldBeTrue();

            ModuleTestUtility.SetClient(client, $"{GetRatingsUri}?page=2&limit={Limit}", responseContent, 2, 2, Limit, 10);

            response = await response.GetNextPageAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
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
        public async Task TestGetRatingsThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetRatingsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktRatingsItem>>> act = () => client.Sync.GetRatingsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
