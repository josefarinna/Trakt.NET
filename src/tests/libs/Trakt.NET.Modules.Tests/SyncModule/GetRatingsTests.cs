using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetRatingsTests
    {
        private const string GetRatingsUri = "sync/ratings";
        private const uint ItemCount = 4U;

        [Theory]
        [InlineData(null, null, null, null, null, GetRatingsUri)]
        [InlineData(TraktRatingsItemType.Movie, null, null, null, null, $"{GetRatingsUri}/movies")]
        [InlineData(TraktRatingsItemType.Show, "10", null, null, null, $"{GetRatingsUri}/shows/10")]
        [InlineData(TraktRatingsItemType.Season, "8,10", null, null, null, $"{GetRatingsUri}/seasons/8,10")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, null, $"{GetRatingsUri}?extended=full")]
        [InlineData(null, null, null, 2U, null, $"{GetRatingsUri}?page=2")]
        [InlineData(null, null, null, null, 5U, $"{GetRatingsUri}?limit=5")]
        [InlineData(TraktRatingsItemType.Episode, "5,8", TraktExtendedInfo.Full, 3U, 10U, $"{GetRatingsUri}/episodes/5,8?extended=full&page=3&limit=10")]
        public async Task TestGetRatingsParametrized(TraktRatingsItemType? type, string? ratingsFilterStr, TraktExtendedInfo? extendedInfo,
            uint? page, uint? limit, string expectedUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Ratings\\syncratings.json");
            uint expectedPage = page ?? 1U;
            uint expectedLimit = limit ?? 10U;

            int[]? ratingsFilter = ratingsFilterStr?.Split(',').Select(int.Parse).ToArray();

            TraktClient client = ModuleTestUtility.GetOAuthClient(expectedUri, responseContent, expectedPage, 1, expectedLimit, 10);

            TraktPagedResponse<TraktRatingsItem> response = await client.Sync.GetRatingsAsync(
                type, ratingsFilter, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            var items = response.Content!.ToArray();
            items.Length.ShouldBe((int)ItemCount);

            response.Page.ShouldBe(expectedPage);
            response.Limit.ShouldBe(expectedLimit);

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
