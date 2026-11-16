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

        [Theory]
        [InlineData(null, null, null, Page, Limit, $"{GetRatingsUri}?page=2&limit=4")]
        [InlineData(RatingsType, null, null, Page, Limit, $"{GetRatingsUri}/movies?page=2&limit=4")]
        [InlineData(TraktRatingsItemType.Show, new int[] { 10 }, null, Page, Limit, $"{GetRatingsUri}/shows/10?page=2&limit=4")]
        [InlineData(TraktRatingsItemType.Season, new int[] { 8, 10 }, null, Page, Limit, $"{GetRatingsUri}/seasons/8,10?page=2&limit=4")]
        [InlineData(null, null, ExtendedInfo, Page, Limit, $"{GetRatingsUri}?extended=full&page=2&limit=4")]
        [InlineData(TraktRatingsItemType.Episode, new int[] { 5, 8 }, ExtendedInfo, 3U, 10U, $"{GetRatingsUri}/episodes/5,8?extended=full&page=3&limit=10")]
        public async Task TestGetRatings(TraktRatingsItemType? ratingsItemType, int[]? ratingsFilter, TraktExtendedInfo? extendedInfo, uint page, uint limit, string requestUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratings.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, 10);

            TraktPagedResponse<TraktRatingsItem> response = await client.Sync.GetRatingsAsync(ratingsItemType, ratingsFilter, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            var items = response.Content.ToArray();
            items.Length.ShouldBe((int)ItemCount);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(limit);
            response.Page.ShouldBe(page);
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
        public async Task TestGetRatingsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetRatingsUri, statusCode);

            Func<Task<TraktPagedResponse<TraktRatingsItem>>> act = () => client.Sync.GetRatingsAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
