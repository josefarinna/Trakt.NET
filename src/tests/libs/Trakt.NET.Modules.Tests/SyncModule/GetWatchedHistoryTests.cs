using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetWatchedHistoryTests
    {
        private const string GetWatchedHistoryUri = "sync/history";
        private const uint ItemCount = 4U;

        [Theory]
        [InlineData(null, null, null, null, null, null, null, GetWatchedHistoryUri)]
        [InlineData(TraktSyncItemType.Movie, null, null, null, null, null, null, $"{GetWatchedHistoryUri}/movies")]
        [InlineData(TraktSyncItemType.Show, 123U, null, null, null, null, null, $"{GetWatchedHistoryUri}/shows/123")]
        [InlineData(null, null, "2024-01-01T00:00:00.000Z", null, null, null, null, $"{GetWatchedHistoryUri}?start_at=2024-01-01T00:00:00.000Z")]
        [InlineData(null, null, null, "2024-01-01T00:00:00.000Z", null, null, null, $"{GetWatchedHistoryUri}?end_at=2024-01-01T00:00:00.000Z")]
        [InlineData(TraktSyncItemType.Episode, 251U, "2024-01-01T00:00:00.000Z", "2024-02-01T00:00:00.000Z", TraktExtendedInfo.Full, 2U, 10U, $"{GetWatchedHistoryUri}/episodes/251?start_at=2024-01-01T00:00:00.000Z&end_at=2024-02-01T00:00:00.000Z&extended=full&page=2&limit=10")]
        public async Task TestGetWatchedHistoryParametrized(TraktSyncItemType? historyItemType, uint? itemId, string? startAtStr, string? endAtStr,
            TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string expectedUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\History\\syncwatchedhistory.json");
            uint expectedPage = page ?? 1U;
            uint expectedLimit = limit ?? 10U;

            DateTime? startAt = startAtStr != null ? TestUtility.ParseUTCDateTime(startAtStr) : null;
            DateTime? endAt = endAtStr != null ? TestUtility.ParseUTCDateTime(endAtStr) : null;

            TraktClient client = ModuleTestUtility.GetOAuthClient(expectedUri, responseContent, expectedPage, 1, expectedLimit, 10);

            TraktPagedResponse<TraktHistoryItem> response = await client.Sync.GetWatchedHistoryAsync(
                historyItemType, itemId, startAt, endAt, extendedInfo, page, limit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe((int)ItemCount);
            response.Page.ShouldBe(expectedPage);
            response.Limit.ShouldBe(expectedLimit);

            var firstItem = response.Content[0];
            firstItem.ID.ShouldBe(1982346U);
            firstItem.Type.ShouldBe(TraktSyncItemType.Movie);
            firstItem.Movie.ShouldNotBeNull();
            firstItem.Movie!.Title.ShouldBe("The Dark Knight");
            firstItem.Action.ShouldBe(TraktHistoryActionType.Scrobble);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetWatchedHistoryThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetWatchedHistoryUri, statusCode);

            Func<Task<TraktPagedResponse<TraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
