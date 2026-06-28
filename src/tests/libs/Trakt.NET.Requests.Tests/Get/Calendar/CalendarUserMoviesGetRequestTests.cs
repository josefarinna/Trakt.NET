#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarUserMoviesGetRequestTests
    {
        private const string URIPath = "calendars/my/movies";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        public void TestCalendarUserMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserMoviesGetRequest = new CalendarUserMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo
            };

            calendarUserMoviesGetRequest.BuildUri();
            calendarUserMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUserMoviesGetRequestHasValidOAuthRequirement()
        {
            var calendarUserMoviesGetRequest = new CalendarUserMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUserMoviesGetRequestIsGetRequest()
        {
            var calendarUserMoviesGetRequest = new CalendarUserMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUserMoviesGetRequestHasCorrectRequestObjectType()
        {
            var calendarUserMoviesGetRequest = new CalendarUserMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarUserMoviesGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarUserMoviesGetRequest = new CalendarUserMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                Filter = filter
            };

            calendarUserMoviesGetRequest.BuildUri();
            calendarUserMoviesGetRequest.RequestUri.ShouldBe(new Uri(URIPath + "/" + StartDateURIValue + "/7?query=game of thrones", UriKind.Relative));
        }
    }
}
