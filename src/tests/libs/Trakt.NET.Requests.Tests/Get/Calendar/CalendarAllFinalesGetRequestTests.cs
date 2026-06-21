#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarAllFinalesGetRequestTests
    {
        private const string URIPath = "calendars/all/shows/finales/123";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarAllFinalesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllFinalesGetRequest = new CalendarAllFinalesGetRequest
            {
                StartDate = "123",
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
    }
}
