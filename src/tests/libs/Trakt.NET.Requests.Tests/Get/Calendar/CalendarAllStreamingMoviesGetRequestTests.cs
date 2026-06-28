#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarAllStreamingMoviesGetRequestTests
    {
        private const string URIPath = "calendars/all/streaming";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        public void TestCalendarAllStreamingMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllStreamingMoviesGetRequest = new CalendarAllStreamingMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo
            };

            calendarAllStreamingMoviesGetRequest.BuildUri();
            calendarAllStreamingMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllStreamingMoviesGetRequestHasValidOAuthRequirement()
        {
            var calendarAllStreamingMoviesGetRequest = new CalendarAllStreamingMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarAllStreamingMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllStreamingMoviesGetRequestIsGetRequest()
        {
            var calendarAllStreamingMoviesGetRequest = new CalendarAllStreamingMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarAllStreamingMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllStreamingMoviesGetRequestHasCorrectRequestObjectType()
        {
            var calendarAllStreamingMoviesGetRequest = new CalendarAllStreamingMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarAllStreamingMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarAllStreamingMoviesGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarAllStreamingMoviesGetRequest = new CalendarAllStreamingMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                Filter = filter
            };

            calendarAllStreamingMoviesGetRequest.BuildUri();
            calendarAllStreamingMoviesGetRequest.RequestUri.ShouldBe(new Uri(URIPath + "/" + StartDateURIValue + "/7?query=game of thrones", UriKind.Relative));
        }
    }
}
