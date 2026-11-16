using System.Globalization;
using System.Net;

namespace TraktNET.CalendarsModule
{
    public sealed class GetHotNewShowsTests
    {
        private const string GetHotNewShowsUri = "calendars/releases/hot/new";

        [Theory]
        [InlineData("2011-04-18T00:00:00.000Z", 7U, null, "calendars/releases/hot/new/2011-04-18/7", "Calendars\\calendarshows.json")]
        [InlineData("2011-04-18T00:00:00.000Z", 7U, TraktExtendedInfo.Full, "calendars/releases/hot/new/2011-04-18/7?extended=full", "Calendars\\calendarshows.json")]
        public async Task TestGetHotNewShows(string startDate, uint days, TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            DateTime date = TestUtility.ParseUTCDateTime(startDate);

            TraktListResponse<TraktCalendarShow> response = await client.Calendar.GetHotNewShowsAsync(date, days, null, extendedInfo, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();

            List<TraktCalendarShow> items = [.. response.Content];
            items.ShouldNotBeEmpty();

            TraktCalendarShow showItem = items[0];
            showItem.FirstAired.ShouldNotBeNull();
            showItem.Show.ShouldNotBeNull();
            showItem.Episode.ShouldNotBeNull();
            showItem.Show.Title.ShouldBe("Game of Thrones");
        }

        [Fact]
        public async Task TestGetHotNewShowsWithFilter()
        {
            string responseContent = await TestUtility.GetJsonFileContentAsync("Calendars\\calendarshows.json");
            DateTime date = TestUtility.ParseUTCDateTime("2011-04-18T00:00:00.000Z");

            string requestUri = $"{GetHotNewShowsUri}/2011-04-18/7?query=game of thrones";
            var filterObj = new TraktFilter { Query = "game of thrones" };
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktCalendarShow> response = await client.Calendar.GetHotNewShowsAsync(date, 7U, filterObj, null, TestContext.Current.CancellationToken);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.HasValue.ShouldBeTrue();
            response.Content.ShouldNotBeNull();

            List<TraktCalendarShow> items = [.. response.Content];
            items.ShouldNotBeEmpty();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiNotFoundException))]
        public async Task TestGetHotNewShowsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            DateTime date = DateTime.UtcNow;
            string dateString = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            TraktClient client = ModuleTestUtility.GetClient($"{GetHotNewShowsUri}/{dateString}/1", statusCode);

            Func<Task<TraktListResponse<TraktCalendarShow>>> act = () => client.Calendar.GetHotNewShowsAsync(date, 1U, cancellationToken: TestContext.Current.CancellationToken);
            (await act.ShouldThrowAsync(exceptionType)).ShouldNotBeNull();
        }

        [Fact]
        public async Task TestGetHotNewShowsThrowsArgumentException()
        {
            DateTime date = DateTime.UtcNow;
            string dateString = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            TraktClient client = ModuleTestUtility.GetClient($"{GetHotNewShowsUri}/{dateString}/1", HttpStatusCode.OK);

            Func<Task<TraktListResponse<TraktCalendarShow>>> act = () => client.Calendar.GetHotNewShowsAsync(default, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Calendar.GetHotNewShowsAsync(DateTime.MinValue, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<ArgumentNullException>();

            act = () => client.Calendar.GetHotNewShowsAsync(date, default, cancellationToken: TestContext.Current.CancellationToken);
            await act.ShouldThrowAsync<TraktRequestValidationException>();
        }
    }
}
