#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarAllMoviesGetRequestTests
    {
        private const string URIPath = "calendars/all/movies";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarAllMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllMoviesGetRequest = new CalendarAllMoviesGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            calendarAllMoviesGetRequest.BuildUri();
            calendarAllMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}?extended=full")]
        public void TestCalendarAllMoviesGetRequestHasValidURIPathWithStartDate(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllMoviesGetRequest = new CalendarAllMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                ExtendedInfo = extendedInfo
            };

            calendarAllMoviesGetRequest.BuildUri();
            calendarAllMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllMoviesGetRequestHasValidOAuthRequirement()
        {
            var calendarAllMoviesGetRequest = new CalendarAllMoviesGetRequest();
            calendarAllMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllMoviesGetRequestIsGetRequest()
        {
            var calendarAllMoviesGetRequest = new CalendarAllMoviesGetRequest();
            calendarAllMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllMoviesGetRequestHasCorrectRequestObjectType()
        {
            var calendarAllMoviesGetRequest = new CalendarAllMoviesGetRequest();
            calendarAllMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarAllMoviesGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarAllMoviesGetRequest = new CalendarAllMoviesGetRequest
            {
                Filter = filter
            };

            calendarAllMoviesGetRequest.BuildUri();
            calendarAllMoviesGetRequest.RequestUri.ShouldBe(new Uri($"{URIPath}?query=game of thrones", UriKind.Relative));
        }
    }
}