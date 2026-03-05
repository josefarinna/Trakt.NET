using System.Globalization;
using System.Net;

namespace TraktNET.CalendarsModule
{
    public sealed class GetAllStreamingMoviesTests
    {
        private const string GetAllStreamingMoviesUri = "calendars/all/streaming";

        [Theory]
        [InlineData(null, null, null, GetAllStreamingMoviesUri, "Calendars\\calendarmovies_minimal.json")]
        [InlineData("2012-05-04", null, null, "calendars/all/streaming/2012-05-04", "Calendars\\calendarmovies_minimal.json")]
        [InlineData(null, 7U, null, "calendars/all/streaming/7", "Calendars\\calendarmovies_minimal.json")]
        [InlineData("2012-05-04", 7U, null, "calendars/all/streaming/2012-05-04/7", "Calendars\\calendarmovies_minimal.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, "calendars/all/streaming?extended=full", "Calendars\\calendarmovies.json")]
        [InlineData("2012-05-04", 7U, TraktExtendedInfo.Full, "calendars/all/streaming/2012-05-04/7?extended=full", "Calendars\\calendarmovies.json")]
        public async Task TestGetAllStreamingMovies(string? startDate, uint? days, TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            DateTime? date = startDate != null ? DateTime.Parse(startDate, CultureInfo.InvariantCulture) : null;

            TraktListResponse<TraktCalendarMovie> response = await client.Calendar.GetAllStreamingMoviesAsync(date, days, null, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            List<TraktCalendarMovie> calendarMovies = [.. response.Content!];
            calendarMovies.ShouldNotBeEmpty();

            TraktCalendarMovie calendarMovie = calendarMovies[0];
            calendarMovie.Released.ShouldNotBeNull();
            calendarMovie.Movie.ShouldNotBeNull();

            // Verificación de datos basada en calendarmovies_minimal.json
            calendarMovie.Released.ShouldBe(DateTime.Parse("2012-05-04", CultureInfo.InvariantCulture));
            calendarMovie.Movie!.Title.ShouldBe("The Avengers");
            calendarMovie.Movie!.Year.ShouldBe(2012U);
            calendarMovie.Movie!.IDs.ShouldNotBeNull();
            calendarMovie.Movie!.IDs!.Trakt.ShouldBe(14701U);
            calendarMovie.Movie!.IDs!.Slug.ShouldBe("the-avengers-2012");
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
        public async Task TestGetAllStreamingMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetAllStreamingMoviesUri, statusCode);

            try
            {
                await client.Calendar.GetAllStreamingMoviesAsync(cancellationToken: TestContext.Current.CancellationToken);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }
    }
}
