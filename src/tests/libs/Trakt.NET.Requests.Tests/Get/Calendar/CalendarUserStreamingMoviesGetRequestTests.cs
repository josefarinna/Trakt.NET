#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarUserStreamingMoviesGetRequestTests
    {
        private const string URIPath = "calendars/my/streaming/123";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarUserStreamingMoviesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest
            {
                StartDate = "123",
                ExtendedInfo = extendedInfo
            };

            calendarUserStreamingMoviesGetRequest.BuildUri();
            calendarUserStreamingMoviesGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUserStreamingMoviesGetRequestHasValidOAuthRequirement()
        {
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest();
            calendarUserStreamingMoviesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUserStreamingMoviesGetRequestIsGetRequest()
        {
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest();
            calendarUserStreamingMoviesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUserStreamingMoviesGetRequestHasCorrectRequestObjectType()
        {
            var calendarUserStreamingMoviesGetRequest = new CalendarUserStreamingMoviesGetRequest();
            calendarUserStreamingMoviesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
