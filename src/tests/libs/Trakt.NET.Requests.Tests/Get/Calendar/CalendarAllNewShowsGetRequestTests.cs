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
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarAllNewShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllNewShowsGetRequest = new CalendarAllNewShowsGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            calendarAllNewShowsGetRequest.BuildUri();
            calendarAllNewShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}?extended=full")]
        public void TestCalendarAllNewShowsGetRequestHasValidURIPathWithStartDate(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllNewShowsGetRequest = new CalendarAllNewShowsGetRequest
            {
                StartDate = StartDateURIValue,
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
    
        [Fact]
        public void TestCalendarAllNewShowsGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarAllNewShowsGetRequest = new CalendarAllNewShowsGetRequest
            {
                Filter = filter
            };

            calendarAllNewShowsGetRequest.BuildUri();
            calendarAllNewShowsGetRequest.RequestUri.ShouldBe(new Uri($"{URIPath}?query=game of thrones", UriKind.Relative));
        }
    }
}