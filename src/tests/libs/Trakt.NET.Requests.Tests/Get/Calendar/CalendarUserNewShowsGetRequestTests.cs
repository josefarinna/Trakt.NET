#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarUserNewShowsGetRequestTests
    {
        private const string URIPath = "calendars/my/shows/new";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarUserNewShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserNewShowsGetRequest = new CalendarUserNewShowsGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            calendarUserNewShowsGetRequest.BuildUri();
            calendarUserNewShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}?extended=full")]
        public void TestCalendarUserNewShowsGetRequestHasValidURIPathWithStartDate(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserNewShowsGetRequest = new CalendarUserNewShowsGetRequest
            {
                StartDate = StartDateURIValue,
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
    
        [Fact]
        public void TestCalendarUserNewShowsGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarUserNewShowsGetRequest = new CalendarUserNewShowsGetRequest
            {
                Filter = filter
            };

            calendarUserNewShowsGetRequest.BuildUri();
            calendarUserNewShowsGetRequest.RequestUri.ShouldBe(new Uri($"{URIPath}?query=game of thrones", UriKind.Relative));
        }
    }
}