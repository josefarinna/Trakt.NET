#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarUserMediaGetRequestTests
    {
        private const string URIPath = "calendars/my/media";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, null, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        [InlineData(null, TraktCalendarMediaType.Movie, $"{URIPath}/{StartDateURIValue}/7?type=movie")]
        [InlineData(TraktExtendedInfo.Full, TraktCalendarMediaType.Show, $"{URIPath}/{StartDateURIValue}/7?type=show&extended=full")]
        public void TestCalendarUserMediaGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, TraktCalendarMediaType? type, string expectedURIPath)
        {
            var request = new CalendarUserMediaGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo,
                Type = type
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUserMediaGetRequestHasValidOAuthRequirement()
        {
            var request = new CalendarUserMediaGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUserMediaGetRequestIsGetRequest()
        {
            var request = new CalendarUserMediaGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUserMediaGetRequestHasCorrectRequestObjectType()
        {
            var request = new CalendarUserMediaGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestCalendarUserMediaGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var request = new CalendarUserMediaGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                Filter = filter
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri($"{URIPath}/{StartDateURIValue}/7?query=game of thrones", UriKind.Relative));
        }
    }
}
