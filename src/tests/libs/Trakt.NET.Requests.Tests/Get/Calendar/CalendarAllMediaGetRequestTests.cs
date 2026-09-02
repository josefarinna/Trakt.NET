#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarAllMediaGetRequestTests
    {
        private const string URIPath = "calendars/all/media";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, null, null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, null, null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        [InlineData(null, TraktCalendarMediaType.Movie, null, $"{URIPath}/{StartDateURIValue}/7?type=movie")]
        [InlineData(null, null, TraktCalendarGroup.Day, $"{URIPath}/{StartDateURIValue}/7?group=day")]
        [InlineData(TraktExtendedInfo.Full, TraktCalendarMediaType.Show, TraktCalendarGroup.Day, $"{URIPath}/{StartDateURIValue}/7?group=day&type=show&extended=full")]
        public void TestCalendarAllMediaGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, TraktCalendarMediaType? type, TraktCalendarGroup? group, string expectedURIPath)
        {
            var request = new CalendarAllMediaGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo,
                Type = type,
                Group = group
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllMediaGetRequestHasValidOAuthRequirement()
        {
            var request = new CalendarAllMediaGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllMediaGetRequestIsGetRequest()
        {
            var request = new CalendarAllMediaGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllMediaGetRequestHasCorrectRequestObjectType()
        {
            var request = new CalendarAllMediaGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestCalendarAllMediaGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var request = new CalendarAllMediaGetRequest
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
