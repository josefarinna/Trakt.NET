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
        [InlineData(null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        public void TestCalendarAllMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllMoviesGetRequest = new CalendarAllMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo
            };

            calendarAllMoviesGetRequest.BuildUri();
            calendarAllMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllMoviesGetRequestHasValidOAuthRequirement()
        {
            var calendarAllMoviesGetRequest = new CalendarAllMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarAllMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllMoviesGetRequestIsGetRequest()
        {
            var calendarAllMoviesGetRequest = new CalendarAllMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarAllMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllMoviesGetRequestHasCorrectRequestObjectType()
        {
            var calendarAllMoviesGetRequest = new CalendarAllMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarAllMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarAllMoviesGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarAllMoviesGetRequest = new CalendarAllMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                Filter = filter
            };

            calendarAllMoviesGetRequest.BuildUri();
            calendarAllMoviesGetRequest.RequestUri.ShouldBe(new Uri(URIPath + "/" + StartDateURIValue + "/7?query=game of thrones", UriKind.Relative));
        }
    }
}
