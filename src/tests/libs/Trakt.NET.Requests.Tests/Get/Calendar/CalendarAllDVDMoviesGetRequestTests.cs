#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarAllDVDMoviesGetRequestTests
    {
        private const string URIPath = "calendars/all/dvd/123";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarAllDVDMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllDVDMoviesGetRequest = new CalendarAllDVDMoviesGetRequest
            {
                StartDate = "123",
                ExtendedInfo = extendedInfo
            };

            calendarAllDVDMoviesGetRequest.BuildUri();
            calendarAllDVDMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllDVDMoviesGetRequestHasValidOAuthRequirement()
        {
            var calendarAllDVDMoviesGetRequest = new CalendarAllDVDMoviesGetRequest();
            calendarAllDVDMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllDVDMoviesGetRequestIsGetRequest()
        {
            var calendarAllDVDMoviesGetRequest = new CalendarAllDVDMoviesGetRequest();
            calendarAllDVDMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllDVDMoviesGetRequestHasCorrectRequestObjectType()
        {
            var calendarAllDVDMoviesGetRequest = new CalendarAllDVDMoviesGetRequest();
            calendarAllDVDMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
