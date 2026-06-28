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
        [InlineData(null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        public void TestCalendarUserNewShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserNewShowsGetRequest = new CalendarUserNewShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo
            };

            calendarUserNewShowsGetRequest.BuildUri();
            calendarUserNewShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUserNewShowsGetRequestHasValidOAuthRequirement()
        {
            var calendarUserNewShowsGetRequest = new CalendarUserNewShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserNewShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUserNewShowsGetRequestIsGetRequest()
        {
            var calendarUserNewShowsGetRequest = new CalendarUserNewShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserNewShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUserNewShowsGetRequestHasCorrectRequestObjectType()
        {
            var calendarUserNewShowsGetRequest = new CalendarUserNewShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserNewShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarUserNewShowsGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarUserNewShowsGetRequest = new CalendarUserNewShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                Filter = filter
            };

            calendarUserNewShowsGetRequest.BuildUri();
            calendarUserNewShowsGetRequest.RequestUri.ShouldBe(new Uri(URIPath + "/" + StartDateURIValue + "/7?query=game of thrones", UriKind.Relative));
        }
    }
}
