#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarAllShowsGetRequestTests
    {
        private const string URIPath = "calendars/all/shows/123";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarAllShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllShowsGetRequest = new CalendarAllShowsGetRequest
            {
                StartDate = "123",
                ExtendedInfo = extendedInfo
            };

            calendarAllShowsGetRequest.BuildUri();
            calendarAllShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllShowsGetRequestHasValidOAuthRequirement()
        {
            var calendarAllShowsGetRequest = new CalendarAllShowsGetRequest();
            calendarAllShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllShowsGetRequestIsGetRequest()
        {
            var calendarAllShowsGetRequest = new CalendarAllShowsGetRequest();
            calendarAllShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllShowsGetRequestHasCorrectRequestObjectType()
        {
            var calendarAllShowsGetRequest = new CalendarAllShowsGetRequest();
            calendarAllShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
