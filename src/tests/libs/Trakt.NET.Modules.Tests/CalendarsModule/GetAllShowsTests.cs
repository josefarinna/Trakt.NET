using System.Globalization;
using System.Net;

namespace TraktNET.CalendarsModule
{
    public sealed class GetAllShowsTests
    {
        private const string GetAllShowsUri = "calendars/all/shows";

        [Theory]
        [InlineData("2011-04-18T00:00:00.000Z", 7U, null, null, "calendars/all/shows/2011-04-18/7", "Calendars\\calendarshows_minimal.json")]
        [InlineData("2011-04-18T00:00:00.000Z", 7U, null, TraktExtendedInfo.Full, "calendars/all/shows/2011-04-18/7?extended=full", "Calendars\\calendarshows.json")]
        [InlineData("2011-04-18T00:00:00.000Z", 7U, TraktCalendarGroup.Day, null, "calendars/all/shows/2011-04-18/7?group=day", "Calendars\\calendarshows_minimal.json")]
        [InlineData("2011-04-18T00:00:00.000Z", 7U, TraktCalendarGroup.Day, TraktExtendedInfo.Full, "calendars/all/shows/2011-04-18/7?group=day&extended=full", "Calendars\\calendarshows.json")]
        public async Task TestGetAllShows(string startDate, uint days, TraktCalendarGroup? group, TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            DateTime date = TestUtility.ParseUTCDateTime(startDate);

            TraktListResponse<TraktCalendarShow> response = await client.Calendar.GetAllShowsAsync(date, days, group, null, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            List<TraktCalendarShow> calendarShows = [.. response.Content];
            calendarShows.ShouldNotBeEmpty();

            TraktCalendarShow calendarShow = calendarShows[0];
            calendarShow.FirstAired.ShouldNotBeNull();
            calendarShow.Episode.ShouldNotBeNull();
            calendarShow.Show.ShouldNotBeNull();

            calendarShow.Show.Title.ShouldBe("Game of Thrones");
            calendarShow.Episode.Title.ShouldBe("Winter Is Coming");
            calendarShow.Episode.Season.ShouldBe(1U);
            calendarShow.Episode.Number.ShouldBe(1U);
        }

        [Fact]
        public async Task TestGetAllShowsWithFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Calendars\\calendarshows_minimal.json");
            DateTime date = TestUtility.ParseUTCDateTime("2011-04-18T00:00:00.000Z");

            var filter = new TraktFilter
            {
                Year = 2011U,
                Genres = ["action", "thriller"]
            };

            string requestUri = $"{GetAllShowsUri}/2011-04-18/7?{filter}";
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktCalendarShow> response = await client.Calendar.GetAllShowsAsync(date, 7U, filter: filter, cancellationToken: TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            List<TraktCalendarShow> items = [.. response.Content];
            items.ShouldNotBeEmpty();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetAllShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            DateTime date = DateTime.UtcNow;
            string dateString = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            TraktClient client = ModuleTestUtility.GetClient($"{GetAllShowsUri}/{dateString}/1", statusCode);

            Func<Task<TraktListResponse<TraktCalendarShow>>> act = () => client.Calendar.GetAllShowsAsync(date, 1U, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetAllShowsThrowsArgumentException()
        {
            DateTime date = DateTime.UtcNow;
            string dateString = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            TraktClient client = ModuleTestUtility.GetClient($"{GetAllShowsUri}/{dateString}/1", HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktCalendarShow>>> act = () => client.Calendar.GetAllShowsAsync(default, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Calendar.GetAllShowsAsync(DateTime.MinValue, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Calendar.GetAllShowsAsync(date, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
