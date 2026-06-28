#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarUserStreamingMoviesGetRequestTests
    {
        private const string URIPath = "calendars/my/streaming";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        public void TestCalendarUserStreamingMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo
            };

            calendarUserStreamingMoviesGetRequest.BuildUri();
            calendarUserStreamingMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUserStreamingMoviesGetRequestHasValidOAuthRequirement()
        {
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserStreamingMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUserStreamingMoviesGetRequestIsGetRequest()
        {
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserStreamingMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUserStreamingMoviesGetRequestHasCorrectRequestObjectType()
        {
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserStreamingMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarUserStreamingMoviesGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                Filter = filter
            };

            calendarUserStreamingMoviesGetRequest.BuildUri();
            calendarUserStreamingMoviesGetRequest.RequestUri.ShouldBe(new Uri(URIPath + "/" + StartDateURIValue + "/7?query=game of thrones", UriKind.Relative));
        }
    }
}
