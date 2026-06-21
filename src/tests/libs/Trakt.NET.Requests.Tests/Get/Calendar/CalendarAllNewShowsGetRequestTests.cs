#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarAllNewShowsGetRequestTests
    {
        private const string URIPath = "calendars/all/shows/new/123";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarAllNewShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllNewShowsGetRequest = new CalendarAllNewShowsGetRequest
            {
                StartDate = "123",
                ExtendedInfo = extendedInfo
            };

            calendarAllNewShowsGetRequest.BuildUri();
            calendarAllNewShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllNewShowsGetRequestHasValidOAuthRequirement()
        {
            var calendarAllNewShowsGetRequest = new CalendarAllNewShowsGetRequest();
            calendarAllNewShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllNewShowsGetRequestIsGetRequest()
        {
            var calendarAllNewShowsGetRequest = new CalendarAllNewShowsGetRequest();
            calendarAllNewShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllNewShowsGetRequestHasCorrectRequestObjectType()
        {
            var calendarAllNewShowsGetRequest = new CalendarAllNewShowsGetRequest();
            calendarAllNewShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
