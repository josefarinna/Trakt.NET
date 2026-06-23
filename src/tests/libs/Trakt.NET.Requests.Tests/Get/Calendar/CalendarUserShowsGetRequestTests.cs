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
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarUserShowsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserShowsGetRequest = new CalendarUserShowsGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            calendarUserShowsGetRequest.BuildUri();
            calendarUserShowsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}?extended=full")]
        public void TestCalendarUserShowsGetRequestHasValidURIPathWithStartDate(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserShowsGetRequest = new CalendarUserShowsGetRequest
            {
                StartDate = StartDateURIValue,
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
    
        [Fact]
        public void TestCalendarUserShowsGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarUserShowsGetRequest = new CalendarUserShowsGetRequest
            {
                Filter = filter
            };

            calendarUserShowsGetRequest.BuildUri();
            calendarUserShowsGetRequest.RequestUri.ShouldBe(new Uri($"{URIPath}?query=game of thrones", UriKind.Relative));
        }
    }
}