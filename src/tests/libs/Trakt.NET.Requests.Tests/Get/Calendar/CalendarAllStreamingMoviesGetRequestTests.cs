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
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarAllStreamingMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllStreamingMoviesGetRequest = new CalendarAllStreamingMoviesGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            calendarAllStreamingMoviesGetRequest.BuildUri();
            calendarAllStreamingMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}?extended=full")]
        public void TestCalendarAllStreamingMoviesGetRequestHasValidURIPathWithStartDate(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllStreamingMoviesGetRequest = new CalendarAllStreamingMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                ExtendedInfo = extendedInfo
            };

            calendarAllStreamingMoviesGetRequest.BuildUri();
            calendarAllStreamingMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllStreamingMoviesGetRequestHasValidOAuthRequirement()
        {
            var calendarAllStreamingMoviesGetRequest = new CalendarAllStreamingMoviesGetRequest();
            calendarAllStreamingMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllStreamingMoviesGetRequestIsGetRequest()
        {
            var calendarAllStreamingMoviesGetRequest = new CalendarAllStreamingMoviesGetRequest();
            calendarAllStreamingMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllStreamingMoviesGetRequestHasCorrectRequestObjectType()
        {
            var calendarAllStreamingMoviesGetRequest = new CalendarAllStreamingMoviesGetRequest();
            calendarAllStreamingMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarAllStreamingMoviesGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarAllStreamingMoviesGetRequest = new CalendarAllStreamingMoviesGetRequest
            {
                Filter = filter
            };

            calendarAllStreamingMoviesGetRequest.BuildUri();
            calendarAllStreamingMoviesGetRequest.RequestUri.ShouldBe(new Uri($"{URIPath}?query=game of thrones", UriKind.Relative));
        }
    }
}