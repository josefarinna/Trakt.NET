using System.Globalization;
using System.Net;

namespace TraktNET.CalendarsModule
{
    public sealed class GetAllFinalesTests
    {
        private const string GetAllFinalesUri = "calendars/all/shows/finales";

        [Theory]
        [InlineData(null, null, null, GetAllFinalesUri, "Calendars\\calendarshowsfinales_minimal.json")]
        [InlineData("2011-04-18", null, null, "calendars/all/shows/finales/2011-04-18", "Calendars\\calendarshowsfinales_minimal.json")]
        [InlineData(null, 7U, null, "calendars/all/shows/finales/7", "Calendars\\calendarshowsfinales_minimal.json")]
        [InlineData("2011-04-18", 7U, null, "calendars/all/shows/finales/2011-04-18/7", "Calendars\\calendarshowsfinales_minimal.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, "calendars/all/shows/finales?extended=full", "Calendars\\calendarshowsfinales.json")]
        [InlineData("2011-04-18", 7U, TraktExtendedInfo.Full, "calendars/all/shows/finales/2011-04-18/7?extended=full", "Calendars\\calendarshowsfinales.json")]
        public async Task TestGetAllFinales(string? startDate, uint? days, TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            DateTime? date = startDate != null ? DateTime.Parse(startDate, CultureInfo.InvariantCulture) : null;

            TraktListResponse<TraktCalendarShow> response = await client.Calendar.GetAllFinalesAsync(date, days, null, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            List<TraktCalendarShow> calendarShows = [.. response.Content!];
            calendarShows.ShouldNotBeEmpty();

            TraktCalendarShow calendarShow = calendarShows[0];
            calendarShow.FirstAired.ShouldNotBeNull();
            calendarShow.Episode.ShouldNotBeNull();
            calendarShow.Show.ShouldNotBeNull();

            // Verificación de datos específicos del JSON (basado en calendarshows_minimal.json)
            calendarShow.Show!.Title.ShouldBe("Game of Thrones");
            calendarShow.Episode!.Title.ShouldBe("Fire and Blood");
            calendarShow.Episode!.Season.ShouldBe(1U);
            calendarShow.Episode!.Number.ShouldBe(10U);
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
        public async Task TestGetAllFinalesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetAllFinalesUri, statusCode);

            try
            {
                await client.Calendar.GetAllFinalesAsync(cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }
    }
}
