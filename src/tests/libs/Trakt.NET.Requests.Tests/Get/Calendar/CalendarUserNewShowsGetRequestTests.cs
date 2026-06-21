#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarUserNewShowsGetRequestTests
    {
        private const string URIPath = "calendars/my/shows/new/123";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarUserNewShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserNewShowsGetRequest = new CalendarUserNewShowsGetRequest
            {
                StartDate = "123",
                ExtendedInfo = extendedInfo
            };

            calendarUserNewShowsGetRequest.BuildUri();
            calendarUserNewShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUserNewShowsGetRequestHasValidOAuthRequirement()
        {
            var calendarUserNewShowsGetRequest = new CalendarUserNewShowsGetRequest();
            calendarUserNewShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUserNewShowsGetRequestIsGetRequest()
        {
            var calendarUserNewShowsGetRequest = new CalendarUserNewShowsGetRequest();
            calendarUserNewShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUserNewShowsGetRequestHasCorrectRequestObjectType()
        {
            var calendarUserNewShowsGetRequest = new CalendarUserNewShowsGetRequest();
            calendarUserNewShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
