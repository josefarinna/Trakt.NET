#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarUserShowsGetRequestTests
    {
        private const string URIPath = "calendars/my/shows/123";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarUserShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserShowsGetRequest = new CalendarUserShowsGetRequest
            {
                StartDate = "123",
                ExtendedInfo = extendedInfo
            };

            calendarUserShowsGetRequest.BuildUri();
            calendarUserShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUserShowsGetRequestHasValidOAuthRequirement()
        {
            var calendarUserShowsGetRequest = new CalendarUserShowsGetRequest();
            calendarUserShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUserShowsGetRequestIsGetRequest()
        {
            var calendarUserShowsGetRequest = new CalendarUserShowsGetRequest();
            calendarUserShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUserShowsGetRequestHasCorrectRequestObjectType()
        {
            var calendarUserShowsGetRequest = new CalendarUserShowsGetRequest();
            calendarUserShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
