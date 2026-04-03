using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetPlaybackProgressTests
    {
        private const string GetPlaybackUri = "sync/playback";

        [Theory]
        [InlineData(null, null, null, null, null, GetPlaybackUri)]
        [InlineData(TraktSyncType.Movie, null, null, null, null, $"{GetPlaybackUri}/movies")]
        [InlineData(null, "2015-02-18T12:54:39.000Z", null, null, null, $"{GetPlaybackUri}?start_at=2015-02-18T12:54:39.000Z")]
        [InlineData(null, "2015-02-18T12:54:39.000Z", "2016-11-07T03:11:00.000Z", null, null, $"{GetPlaybackUri}?start_at=2015-02-18T12:54:39.000Z&end_at=2016-11-07T03:11:00.000Z")]
        [InlineData(null, null, null, 2U, null, $"{GetPlaybackUri}?page=2")]
        [InlineData(null, null, null, null, 5U, $"{GetPlaybackUri}?limit=5")]
        [InlineData(TraktSyncType.Episode, "2015-02-18T12:54:39.000Z", null, 2U, null, $"{GetPlaybackUri}/episodes?start_at=2015-02-18T12:54:39.000Z")]
        [InlineData(TraktSyncType.Movie, "2015-02-18T12:54:39.000Z", "2016-11-07T03:11:00.000Z", 3U, 10U, $"{GetPlaybackUri}/movies?start_at=2015-02-18T12:54:39.000Z&end_at=2016-11-07T03:11:00.000Z&page=3&limit=10")]
        public async Task TestGetPlaybackProgress(TraktSyncType? type, string? startAtStr, string? endAtStr,
            uint? page, uint? limit, string expectedUri)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Playback\\syncplaybackprogress.json");
            uint expectedPage = page ?? 1U;
            uint expectedLimit = limit ?? 10U;

            DateTime? startAt = startAtStr != null ? TestUtility.ParseUTCDateTime(startAtStr) : null;
            DateTime? endAt = endAtStr != null ? TestUtility.ParseUTCDateTime(endAtStr) : null;

            TraktClient client = ModuleTestUtility.GetOAuthClient(expectedUri, responseContent, expectedPage, 1, expectedLimit, 10);

            TraktPagedResponse<TraktSyncPlaybackProgressItem> response = await client.Sync.GetPlaybackProgressAsync(type, startAt, endAt, expectedPage, expectedLimit, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Content.Count.ShouldBe(2);
            response.ItemCount.ShouldBe(10U);
            response.Limit.ShouldBe(expectedLimit);
            response.Page.ShouldBe(expectedPage);
            response.PageCount.ShouldBe(1U);
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
        public async Task TestGetPlaybackProgressThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetPlaybackUri, statusCode);

            Func<Task<TraktPagedResponse<TraktSyncPlaybackProgressItem>>> act = () => client.Sync.GetPlaybackProgressAsync(cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
