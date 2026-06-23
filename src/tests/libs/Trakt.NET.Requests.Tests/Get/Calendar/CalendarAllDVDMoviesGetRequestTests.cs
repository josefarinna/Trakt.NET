#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarAllDVDMoviesGetRequestTests
    {
        private const string URIPath = "calendars/all/dvd";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarAllDVDMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllDVDMoviesGetRequest = new CalendarAllDVDMoviesGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            calendarAllDVDMoviesGetRequest.BuildUri();
            calendarAllDVDMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}?extended=full")]
        public void TestCalendarAllDVDMoviesGetRequestHasValidURIPathWithStartDate(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllDVDMoviesGetRequest = new CalendarAllDVDMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                ExtendedInfo = extendedInfo
            };

            calendarAllDVDMoviesGetRequest.BuildUri();
            calendarAllDVDMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllDVDMoviesGetRequestHasValidOAuthRequirement()
        {
            var calendarAllDVDMoviesGetRequest = new CalendarAllDVDMoviesGetRequest();
            calendarAllDVDMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllDVDMoviesGetRequestIsGetRequest()
        {
            var calendarAllDVDMoviesGetRequest = new CalendarAllDVDMoviesGetRequest();
            calendarAllDVDMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllDVDMoviesGetRequestHasCorrectRequestObjectType()
        {
            var calendarAllDVDMoviesGetRequest = new CalendarAllDVDMoviesGetRequest();
            calendarAllDVDMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarAllDVDMoviesGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarAllDVDMoviesGetRequest = new CalendarAllDVDMoviesGetRequest
            {
                Filter = filter
            };

            calendarAllDVDMoviesGetRequest.BuildUri();
            calendarAllDVDMoviesGetRequest.RequestUri.ShouldBe(new Uri($"{URIPath}?query=game of thrones", UriKind.Relative));
        }
    }
}