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
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarUserStreamingMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            calendarUserStreamingMoviesGetRequest.BuildUri();
            calendarUserStreamingMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}?extended=full")]
        public void TestCalendarUserStreamingMoviesGetRequestHasValidURIPathWithStartDate(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                ExtendedInfo = extendedInfo
            };

            calendarUserStreamingMoviesGetRequest.BuildUri();
            calendarUserStreamingMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUserStreamingMoviesGetRequestHasValidOAuthRequirement()
        {
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest();
            calendarUserStreamingMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUserStreamingMoviesGetRequestIsGetRequest()
        {
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest();
            calendarUserStreamingMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUserStreamingMoviesGetRequestHasCorrectRequestObjectType()
        {
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest();
            calendarUserStreamingMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarUserStreamingMoviesGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest
            {
                Filter = filter
            };

            calendarUserStreamingMoviesGetRequest.BuildUri();
            calendarUserStreamingMoviesGetRequest.RequestUri.ShouldBe(new Uri($"{URIPath}?query=game of thrones", UriKind.Relative));
        }
    }
}