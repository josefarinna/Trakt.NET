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
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarUserMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserMoviesGetRequest = new CalendarUserMoviesGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            calendarUserMoviesGetRequest.BuildUri();
            calendarUserMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}?extended=full")]
        public void TestCalendarUserMoviesGetRequestHasValidURIPathWithStartDate(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserMoviesGetRequest = new CalendarUserMoviesGetRequest
            {
                StartDate = StartDateURIValue,
                ExtendedInfo = extendedInfo
            };

            calendarUserMoviesGetRequest.BuildUri();
            calendarUserMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUserMoviesGetRequestHasValidOAuthRequirement()
        {
            var calendarUserMoviesGetRequest = new CalendarUserMoviesGetRequest();
            calendarUserMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUserMoviesGetRequestIsGetRequest()
        {
            var calendarUserMoviesGetRequest = new CalendarUserMoviesGetRequest();
            calendarUserMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUserMoviesGetRequestHasCorrectRequestObjectType()
        {
            var calendarUserMoviesGetRequest = new CalendarUserMoviesGetRequest();
            calendarUserMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
