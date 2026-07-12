using System.Net;

namespace TraktNET.SyncModule
{
    public sealed class GetLastActivitiesTests
    {
        private const string GetLastActivitiesUri = "sync/last_activities";

        [Fact]
        public async Task TestGetLastActivities()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Syncs\\Activities\\synclastactivities.json");

            TraktClient client = ModuleTestUtility.GetOAuthClient(GetLastActivitiesUri, responseContent);
            TraktResponse<TraktSyncLastActivities> response = await client.Sync.GetLastActivitiesAsync(TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            TraktSyncLastActivities responseValue = response.Content!;

            responseValue.All.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-30T13:38:37.000Z"));

            responseValue.Movies.ShouldNotBeNull();
            responseValue.Movies.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-11T20:00:28.000Z"));
            responseValue.Movies.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            responseValue.Movies.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-11-07T03:11:00.000Z"));
            responseValue.Movies.WatchlistedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-04T13:48:29.000Z"));
            responseValue.Movies.FavoritedAt.ShouldBe(TestUtility.ParseUTCDateTime("2021-04-07T22:07:11.000Z"));
            responseValue.Movies.RecommendationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2021-04-07T22:07:11.000Z"));
            responseValue.Movies.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            responseValue.Movies.PausedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            responseValue.Movies.HiddenAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            responseValue.Episodes.ShouldNotBeNull();
            responseValue.Episodes.WatchedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-30T13:38:37.000Z"));
            responseValue.Episodes.CollectedAt.ShouldBe(TestUtility.ParseUTCDateTime("2016-11-09T23:16:22.0000000Z"));
            responseValue.Episodes.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            responseValue.Episodes.WatchlistedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            responseValue.Episodes.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            responseValue.Episodes.PausedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            responseValue.Shows.ShouldNotBeNull();
            responseValue.Shows.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-06-25T23:46:52.000Z"));
            responseValue.Shows.WatchlistedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-22T16:39:23.000Z"));
            responseValue.Shows.FavoritedAt.ShouldBe(TestUtility.ParseUTCDateTime("2021-06-28T00:13:46.000Z"));
            responseValue.Shows.RecommendationsAt.ShouldBe(TestUtility.ParseUTCDateTime("2021-06-28T00:13:46.000Z"));
            responseValue.Shows.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            responseValue.Shows.HiddenAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-12-20T19:34:50.000Z"));
            responseValue.Shows.DroppedAt.ShouldBe(TestUtility.ParseUTCDateTime("2026-03-31T14:56:06.000Z"));

            responseValue.Seasons.ShouldNotBeNull();
            responseValue.Seasons.RatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-06-25T23:46:39.000Z"));
            responseValue.Seasons.WatchlistedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-10-06T17:42:50.000Z"));
            responseValue.Seasons.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            responseValue.Seasons.HiddenAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            responseValue.Comments.ShouldNotBeNull();
            responseValue.Comments.LikedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            responseValue.Comments.ReactedAt.ShouldBe(TestUtility.ParseUTCDateTime("2012-10-09T13:13:26.000Z"));
            responseValue.Comments.BlockedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            responseValue.Lists.ShouldNotBeNull();
            responseValue.Lists.LikedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-06-28T21:32:53.000Z"));
            responseValue.Lists.ReactedAt.ShouldBe(TestUtility.ParseUTCDateTime("2012-10-09T13:13:26.000Z"));
            responseValue.Lists.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-10-14T21:47:15.000Z"));
            responseValue.Lists.CommentedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            responseValue.Watchlist.ShouldNotBeNull();
            responseValue.Watchlist.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-22T16:39:23.000Z"));

            responseValue.Favorites.ShouldNotBeNull();
            responseValue.Favorites.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-05-14T19:04:12.000Z"));

            responseValue.Recommendations.ShouldNotBeNull();
            responseValue.Recommendations.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2022-05-14T19:04:12.000Z"));

            responseValue.Collaborations.ShouldNotBeNull();
            responseValue.Collaborations.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            responseValue.Account.ShouldNotBeNull();
            responseValue.Account.SettingsAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-06-26T18:08:03.000Z"));
            responseValue.Account.FollowedAt.ShouldBe(TestUtility.ParseUTCDateTime("2020-12-14T14:12:28.000Z"));
            responseValue.Account.FollowingAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            responseValue.Account.PendingAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
            responseValue.Account.RequestedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            responseValue.SavedFilters.ShouldNotBeNull();
            responseValue.SavedFilters.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));

            responseValue.Notes.ShouldNotBeNull();
            responseValue.Notes.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2015-02-18T12:54:39.000Z"));
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
        public async Task TestGetLastActivitiesThrowsAPIException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetOAuthClient(GetLastActivitiesUri, statusCode);

            Func<Task<TraktResponse<TraktSyncLastActivities>>> act = () => client.Sync.GetLastActivitiesAsync(TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }
    }
}
