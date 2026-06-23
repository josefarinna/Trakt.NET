#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarUSerDVDMoviesGetRequestTests
    {
        private const string URIPath = "calendars/my/dvd";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarUSerDVDMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUSerDVDMoviesGetRequest = new CalendarUSerDVDMoviesGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            calendarUSerDVDMoviesGetRequest.BuildUri();
            calendarUSerDVDMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}?extended=full")]
        public void TestCalendarUSerDVDMoviesGetRequestHasValidURIPathWithStartDate(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUSerDVDMoviesGetRequest = new CalendarUSerDVDMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                ExtendedInfo = extendedInfo
            };

            calendarUSerDVDMoviesGetRequest.BuildUri();
            calendarUSerDVDMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUSerDVDMoviesGetRequestHasValidOAuthRequirement()
        {
            var calendarUSerDVDMoviesGetRequest = new CalendarUSerDVDMoviesGetRequest();
            calendarUSerDVDMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUSerDVDMoviesGetRequestIsGetRequest()
        {
            var calendarUSerDVDMoviesGetRequest = new CalendarUSerDVDMoviesGetRequest();
            calendarUSerDVDMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUSerDVDMoviesGetRequestHasCorrectRequestObjectType()
        {
            var calendarUSerDVDMoviesGetRequest = new CalendarUSerDVDMoviesGetRequest();
            calendarUSerDVDMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarUSerDVDMoviesGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarUSerDVDMoviesGetRequest = new CalendarUSerDVDMoviesGetRequest
            {
                Filter = filter
            };

            calendarUSerDVDMoviesGetRequest.BuildUri();
            calendarUSerDVDMoviesGetRequest.RequestUri.ShouldBe(new Uri($"{URIPath}?query=game of thrones", UriKind.Relative));
        }
    }
}