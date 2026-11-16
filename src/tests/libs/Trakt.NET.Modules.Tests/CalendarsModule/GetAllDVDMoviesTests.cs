using System.Globalization;
using System.Net;

namespace TraktNET.CalendarsModule
{
    public sealed class GetAllDVDMoviesTests
    {
        private const string GetAllDVDMoviesUri = "calendars/all/dvd";

        [Theory]
        [InlineData("2012-05-04T00:00:00.000Z", 7U, null, "calendars/all/dvd/2012-05-04/7", "Calendars\\calendarmovies_minimal.json")]
        [InlineData("2012-05-04T00:00:00.000Z", 7U, TraktExtendedInfo.Full, "calendars/all/dvd/2012-05-04/7?extended=full", "Calendars\\calendarmovies.json")]
        public async Task TestGetAllDVDMovies(string startDate, uint days, TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            DateTime date = TestUtility.ParseUTCDateTime(startDate);

            TraktListResponse<TraktCalendarMovie> response = await client.Calendar.GetAllDVDMoviesAsync(date, days, null, extendedInfo, TestContext.Current.CancellationToken);

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

            calendarMovie.Released.ShouldBe(TestUtility.ParseUTCDateTime("2012-05-04T00:00:00.000Z"));
            calendarMovie.Movie!.Title.ShouldBe("The Avengers");
            calendarMovie.Movie!.Year.ShouldBe(2012U);
            calendarMovie.Movie!.IDs.ShouldNotBeNull();
            calendarMovie.Movie!.IDs!.Trakt.ShouldBe(14701U);
            calendarMovie.Movie!.IDs!.Slug.ShouldBe("the-avengers-2012");
        }

        [Fact]
        public async Task TestGetAllDVDMoviesWithFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Calendars\\calendarmovies_minimal.json");
            DateTime date = TestUtility.ParseUTCDateTime("2011-04-18T00:00:00.000Z");

            var filter = new TraktFilter
            {
                Year = 2011U,
                Genres = ["action", "thriller"]
            };

            string requestUri = $"{GetAllDVDMoviesUri}/2011-04-18/7?{filter}";
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktCalendarMovie> response = await client.Calendar.GetAllDVDMoviesAsync(date, 7U, filter, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();

            List<TraktCalendarMovie> items = [.. response.Content!];
            items.ShouldNotBeEmpty();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetAllDVDMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            DateTime date = DateTime.UtcNow;
            string dateString = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            TraktClient client = ModuleTestUtility.GetClient($"{GetAllDVDMoviesUri}/{dateString}/1", statusCode);

            Func<Task<TraktListResponse<TraktCalendarMovie>>> act = () => client.Calendar.GetAllDVDMoviesAsync(date, 1U, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetAllDVDMoviesThrowsArgumentException()
        {
            DateTime date = DateTime.UtcNow;
            string dateString = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            TraktClient client = ModuleTestUtility.GetClient($"{GetAllDVDMoviesUri}/{dateString}/1", HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktCalendarMovie>>> act = () => client.Calendar.GetAllDVDMoviesAsync(default, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Calendar.GetAllDVDMoviesAsync(DateTime.MinValue, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Calendar.GetAllDVDMoviesAsync(date, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
