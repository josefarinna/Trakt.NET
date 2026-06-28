#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarUserFinalesGetRequestTests
    {
        private const string URIPath = "calendars/my/shows/finales";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        public void TestCalendarUserFinalesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserFinalesGetRequest = new CalendarUserFinalesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo
            };

            calendarUserFinalesGetRequest.BuildUri();
            calendarUserFinalesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUserFinalesGetRequestHasValidOAuthRequirement()
        {
            var calendarUserFinalesGetRequest = new CalendarUserFinalesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserFinalesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUserFinalesGetRequestIsGetRequest()
        {
            var calendarUserFinalesGetRequest = new CalendarUserFinalesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserFinalesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUserFinalesGetRequestHasCorrectRequestObjectType()
        {
            var calendarUserFinalesGetRequest = new CalendarUserFinalesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserFinalesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarUserFinalesGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarUserFinalesGetRequest = new CalendarUserFinalesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                Filter = filter
            };

            calendarUserFinalesGetRequest.BuildUri();
            calendarUserFinalesGetRequest.RequestUri.ShouldBe(new Uri(URIPath + "/" + StartDateURIValue + "/7?query=game of thrones", UriKind.Relative));
        }
    }
}
