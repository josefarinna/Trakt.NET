#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarUSerDVDMoviesGetRequestTests
    {
        private const string URIPath = "calendars/my/dvd/123";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarUSerDVDMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUSerDVDMoviesGetRequest = new CalendarUSerDVDMoviesGetRequest
            {
                StartDate = "123",
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
    }
}
