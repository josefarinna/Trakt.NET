using System.Globalization;
using System.Net;

namespace TraktNET.CalendarsModule
{
    public sealed class GetAllSeasonPremieresTests
    {
        private const string GetAllSeasonPremieresUri = "calendars/all/shows/premieres";

        [Theory]
        [InlineData("2011-04-18T00:00:00.000Z", 7U, null, "calendars/all/shows/premieres/2011-04-18/7", "Calendars\\calendarshows_minimal.json")]
        [InlineData("2011-04-18T00:00:00.000Z", 7U, TraktExtendedInfo.Full, "calendars/all/shows/premieres/2011-04-18/7?extended=full", "Calendars\\calendarshows.json")]
        public async Task TestGetAllSeasonPremieres(string startDate, uint days, TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            DateTime date = TestUtility.ParseUTCDateTime(startDate);

            TraktListResponse<TraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(date, days, null, extendedInfo, TestContext.Current.CancellationToken);

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
        public async Task TestGetAllSeasonPremieresWithFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Calendars\\calendarshows_minimal.json");
            DateTime date = TestUtility.ParseUTCDateTime("2011-04-18T00:00:00.000Z");

            var filter = new TraktFilter
            {
                Year = 2011U,
                Genres = ["action", "thriller"]
            };

            string requestUri = $"{GetAllSeasonPremieresUri}/2011-04-18/7?{filter}";
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(date, 7U, filter, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            List<TraktCalendarShow> items = [.. response.Content];
            items.ShouldNotBeEmpty();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetAllSeasonPremieresThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            DateTime date = DateTime.UtcNow;
            string dateString = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            TraktClient client = ModuleTestUtility.GetClient($"{GetAllSeasonPremieresUri}/{dateString}/1", statusCode);

            Func<Task<TraktListResponse<TraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync(date, 1U, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetAllSeasonPremieresThrowsArgumentException()
        {
            DateTime date = DateTime.UtcNow;
            string dateString = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            TraktClient client = ModuleTestUtility.GetClient($"{GetAllSeasonPremieresUri}/{dateString}/1", HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync(default, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Calendar.GetAllSeasonPremieresAsync(DateTime.MinValue, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Calendar.GetAllSeasonPremieresAsync(date, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
