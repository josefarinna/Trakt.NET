#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarAllFinalesGetRequestTests
    {
        private const string URIPath = "calendars/all/shows/finales";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarAllFinalesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllFinalesGetRequest = new CalendarAllFinalesGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            calendarAllFinalesGetRequest.BuildUri();
            calendarAllFinalesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}?extended=full")]
        public void TestCalendarAllFinalesGetRequestHasValidURIPathWithStartDate(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllFinalesGetRequest = new CalendarAllFinalesGetRequest
            {
                StartDate = StartDateURIValue,
                ExtendedInfo = extendedInfo
            };

            calendarAllFinalesGetRequest.BuildUri();
            calendarAllFinalesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllFinalesGetRequestHasValidOAuthRequirement()
        {
            var calendarAllFinalesGetRequest = new CalendarAllFinalesGetRequest();
            calendarAllFinalesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllFinalesGetRequestIsGetRequest()
        {
            var calendarAllFinalesGetRequest = new CalendarAllFinalesGetRequest();
            calendarAllFinalesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllFinalesGetRequestHasCorrectRequestObjectType()
        {
            var calendarAllFinalesGetRequest = new CalendarAllFinalesGetRequest();
            calendarAllFinalesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarAllFinalesGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarAllFinalesGetRequest = new CalendarAllFinalesGetRequest
            {
                Filter = filter
            };

            calendarAllFinalesGetRequest.BuildUri();
            calendarAllFinalesGetRequest.RequestUri.ShouldBe(new Uri($"{URIPath}?query=game of thrones", UriKind.Relative));
        }
    }
}