#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarUserFinalesGetRequestTests
    {
        private const string URIPath = "calendars/my/shows/finales/123";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarUserFinalesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserFinalesGetRequest = new CalendarUserFinalesGetRequest
            {
                StartDate = "123",
                ExtendedInfo = extendedInfo
            };

            calendarUserFinalesGetRequest.BuildUri();
            calendarUserFinalesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUserFinalesGetRequestHasValidOAuthRequirement()
        {
            var calendarUserFinalesGetRequest = new CalendarUserFinalesGetRequest();
            calendarUserFinalesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUserFinalesGetRequestIsGetRequest()
        {
            var calendarUserFinalesGetRequest = new CalendarUserFinalesGetRequest();
            calendarUserFinalesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUserFinalesGetRequestHasCorrectRequestObjectType()
        {
            var calendarUserFinalesGetRequest = new CalendarUserFinalesGetRequest();
            calendarUserFinalesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
