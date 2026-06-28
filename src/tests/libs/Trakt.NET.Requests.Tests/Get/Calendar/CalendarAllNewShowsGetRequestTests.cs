#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarAllNewShowsGetRequestTests
    {
        private const string URIPath = "calendars/all/shows/new";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        public void TestCalendarAllNewShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllNewShowsGetRequest = new CalendarAllNewShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo
            };

            calendarAllNewShowsGetRequest.BuildUri();
            calendarAllNewShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllNewShowsGetRequestHasValidOAuthRequirement()
        {
            var calendarAllNewShowsGetRequest = new CalendarAllNewShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarAllNewShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllNewShowsGetRequestIsGetRequest()
        {
            var calendarAllNewShowsGetRequest = new CalendarAllNewShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarAllNewShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllNewShowsGetRequestHasCorrectRequestObjectType()
        {
            var calendarAllNewShowsGetRequest = new CalendarAllNewShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarAllNewShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarAllNewShowsGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarAllNewShowsGetRequest = new CalendarAllNewShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                Filter = filter
            };

            calendarAllNewShowsGetRequest.BuildUri();
            calendarAllNewShowsGetRequest.RequestUri.ShouldBe(new Uri(URIPath + "/" + StartDateURIValue + "/7?query=game of thrones", UriKind.Relative));
        }
    }
}
