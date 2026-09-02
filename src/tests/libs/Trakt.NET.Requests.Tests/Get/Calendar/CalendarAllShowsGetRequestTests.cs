#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarAllShowsGetRequestTests
    {
        private const string URIPath = "calendars/all/shows";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, null, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        [InlineData(null, TraktCalendarGroup.Day, $"{URIPath}/{StartDateURIValue}/7?group=day")]
        [InlineData(TraktExtendedInfo.Full, TraktCalendarGroup.Day, $"{URIPath}/{StartDateURIValue}/7?group=day&extended=full")]
        public void TestCalendarAllShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, TraktCalendarGroup? group, string expectedURIPath)
        {
            var calendarAllShowsGetRequest = new CalendarAllShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo,
                Group = group
            };

            calendarAllShowsGetRequest.BuildUri();
            calendarAllShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllShowsGetRequestHasValidOAuthRequirement()
        {
            var calendarAllShowsGetRequest = new CalendarAllShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarAllShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllShowsGetRequestIsGetRequest()
        {
            var calendarAllShowsGetRequest = new CalendarAllShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarAllShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllShowsGetRequestHasCorrectRequestObjectType()
        {
            var calendarAllShowsGetRequest = new CalendarAllShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarAllShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarAllShowsGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarAllShowsGetRequest = new CalendarAllShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                Filter = filter
            };

            calendarAllShowsGetRequest.BuildUri();
            calendarAllShowsGetRequest.RequestUri.ShouldBe(new Uri(URIPath + "/" + StartDateURIValue + "/7?query=game of thrones", UriKind.Relative));
        }
    }
}
