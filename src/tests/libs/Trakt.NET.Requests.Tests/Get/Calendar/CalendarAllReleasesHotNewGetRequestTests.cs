#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarAllReleasesHotNewGetRequestTests
    {
        private const string URIPath = "calendars/releases/hot/new";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        public void TestCalendarAllReleasesHotNewGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var request = new CalendarAllReleasesHotNewGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllReleasesHotNewGetRequestHasValidOAuthRequirement()
        {
            var request = new CalendarAllReleasesHotNewGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllReleasesHotNewGetRequestIsGetRequest()
        {
            var request = new CalendarAllReleasesHotNewGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllReleasesHotNewGetRequestHasCorrectRequestObjectType()
        {
            var request = new CalendarAllReleasesHotNewGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestCalendarAllReleasesHotNewGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var request = new CalendarAllReleasesHotNewGetRequest
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
