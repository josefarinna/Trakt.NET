#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarUserShowsGetRequestTests
    {
        private const string URIPath = "calendars/my/shows";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        public void TestCalendarUserShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserShowsGetRequest = new CalendarUserShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo
            };

            calendarUserShowsGetRequest.BuildUri();
            calendarUserShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUserShowsGetRequestHasValidOAuthRequirement()
        {
            var calendarUserShowsGetRequest = new CalendarUserShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserShowsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUserShowsGetRequestIsGetRequest()
        {
            var calendarUserShowsGetRequest = new CalendarUserShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserShowsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUserShowsGetRequestHasCorrectRequestObjectType()
        {
            var calendarUserShowsGetRequest = new CalendarUserShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserShowsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarUserShowsGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarUserShowsGetRequest = new CalendarUserShowsGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                Filter = filter
            };

            calendarUserShowsGetRequest.BuildUri();
            calendarUserShowsGetRequest.RequestUri.ShouldBe(new Uri(URIPath + "/" + StartDateURIValue + "/7?query=game of thrones", UriKind.Relative));
        }
    }
}
