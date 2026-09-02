using System.Globalization;
using System.Net;

namespace TraktNET.CalendarsModule
{
    public sealed class GetAllMediaTests
    {
        private const string GetAllMediaUri = "calendars/all/media";

        [Theory]
        [InlineData("2012-05-04T00:00:00.000Z", 7U, null, null, null, "calendars/all/media/2012-05-04/7", "Calendars\\calendarmedia.json")]
        [InlineData("2012-05-04T00:00:00.000Z", 7U, TraktCalendarMediaType.Movie, null, TraktExtendedInfo.Full, "calendars/all/media/2012-05-04/7?type=movie&extended=full", "Calendars\\calendarmedia.json")]
        [InlineData("2012-05-04T00:00:00.000Z", 7U, null, TraktCalendarGroup.Day, null, "calendars/all/media/2012-05-04/7?group=day", "Calendars\\calendarmedia.json")]
        [InlineData("2012-05-04T00:00:00.000Z", 7U, TraktCalendarMediaType.Show, TraktCalendarGroup.Day, TraktExtendedInfo.Full, "calendars/all/media/2012-05-04/7?group=day&type=show&extended=full", "Calendars\\calendarmedia.json")]
        public async Task TestGetAllMedia(string startDate, uint days, TraktCalendarMediaType? type, TraktCalendarGroup? group, TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            DateTime date = TestUtility.ParseUTCDateTime(startDate);

            TraktListResponse<TraktCalendarMedia> response = await client.Calendar.GetAllMediaAsync(date, days, type, group, null, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            List<TraktCalendarMedia> items = [.. response.Content!];
            items.ShouldNotBeEmpty();
            items.Count.ShouldBe(2);

            TraktCalendarMedia movieItem = items[0];
            movieItem.Released.ShouldNotBeNull();
            movieItem.Movie.ShouldNotBeNull();
            movieItem.Movie!.Title.ShouldBe("The Avengers");

            TraktCalendarMedia showItem = items[1];
            showItem.FirstAired.ShouldNotBeNull();
            showItem.Show.ShouldNotBeNull();
            showItem.Episode.ShouldNotBeNull();
            showItem.Show!.Title.ShouldBe("Game of Thrones");
        }

        [Fact]
        public async Task TestGetAllMediaWithFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Calendars\\calendarmedia.json");
            DateTime date = TestUtility.ParseUTCDateTime("2011-04-18T00:00:00.000Z");

            string requestUri = $"{GetAllMediaUri}/2011-04-18/7?query=game of thrones";
            var filterObj = new TraktFilter { Query = "game of thrones" };
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktCalendarMedia> response = await client.Calendar.GetAllMediaAsync(date, 7U, filter: filterObj, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            List<TraktCalendarMedia> items = [.. response.Content!];
            items.ShouldNotBeEmpty();
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
        public async Task TestGetAllMediaThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            DateTime date = DateTime.UtcNow;
            string dateString = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            TraktClient client = ModuleTestUtility.GetClient($"{GetAllMediaUri}/{dateString}/1", statusCode);

            Func<Task<TraktListResponse<TraktCalendarMedia>>> act = () => client.Calendar.GetAllMediaAsync(date, 1U, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetAllMediaThrowsArgumentException()
        {
            DateTime date = DateTime.UtcNow;
            string dateString = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            TraktClient client = ModuleTestUtility.GetClient($"{GetAllMediaUri}/{dateString}/1", HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktCalendarMedia>>> act = () => client.Calendar.GetAllMediaAsync(default, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Calendar.GetAllMediaAsync(DateTime.MinValue, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Calendar.GetAllMediaAsync(date, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
