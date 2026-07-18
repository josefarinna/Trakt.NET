#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarAllReleasesHotFinalesGetRequestTests
    {
        private const string URIPath = "calendars/releases/hot/finales";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        public void TestCalendarAllReleasesHotFinalesGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var request = new CalendarAllReleasesHotFinalesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllReleasesHotFinalesGetRequestHasValidOAuthRequirement()
        {
            var request = new CalendarAllReleasesHotFinalesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllReleasesHotFinalesGetRequestIsGetRequest()
        {
            var request = new CalendarAllReleasesHotFinalesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllReleasesHotFinalesGetRequestHasCorrectRequestObjectType()
        {
            var request = new CalendarAllReleasesHotFinalesGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestCalendarAllReleasesHotFinalesGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var request = new CalendarAllReleasesHotFinalesGetRequest
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
