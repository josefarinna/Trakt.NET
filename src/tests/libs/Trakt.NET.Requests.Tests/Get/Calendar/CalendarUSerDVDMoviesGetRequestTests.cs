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
        [InlineData(null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        public void TestCalendarUSerDVDMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUSerDVDMoviesGetRequest = new CalendarUSerDVDMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo
            };

            calendarUSerDVDMoviesGetRequest.BuildUri();
            calendarUSerDVDMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUSerDVDMoviesGetRequestHasValidOAuthRequirement()
        {
            var calendarUSerDVDMoviesGetRequest = new CalendarUSerDVDMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUSerDVDMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUSerDVDMoviesGetRequestIsGetRequest()
        {
            var calendarUSerDVDMoviesGetRequest = new CalendarUSerDVDMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUSerDVDMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUSerDVDMoviesGetRequestHasCorrectRequestObjectType()
        {
            var calendarUSerDVDMoviesGetRequest = new CalendarUSerDVDMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUSerDVDMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarUSerDVDMoviesGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarUSerDVDMoviesGetRequest = new CalendarUSerDVDMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                Filter = filter
            };

            calendarUSerDVDMoviesGetRequest.BuildUri();
            calendarUSerDVDMoviesGetRequest.RequestUri.ShouldBe(new Uri(URIPath + "/" + StartDateURIValue + "/7?query=game of thrones", UriKind.Relative));
        }
    }
}
