#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarAllSeasonPremieresGetRequestTests
    {
        private const string URIPath = "calendars/all/shows/premieres";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarAllSeasonPremieresGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllSeasonPremieresGetRequest = new CalendarAllSeasonPremieresGetRequest
            {
                ExtendedInfo = extendedInfo
            };

            calendarAllSeasonPremieresGetRequest.BuildUri();
            calendarAllSeasonPremieresGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}?extended=full")]
        public void TestCalendarAllSeasonPremieresGetRequestHasValidURIPathWithStartDate(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarAllSeasonPremieresGetRequest = new CalendarAllSeasonPremieresGetRequest
            {
                StartDate = StartDateURIValue,
                ExtendedInfo = extendedInfo
            };

            calendarAllSeasonPremieresGetRequest.BuildUri();
            calendarAllSeasonPremieresGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarAllSeasonPremieresGetRequestHasValidOAuthRequirement()
        {
            var calendarAllSeasonPremieresGetRequest = new CalendarAllSeasonPremieresGetRequest();
            calendarAllSeasonPremieresGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestCalendarAllSeasonPremieresGetRequestIsGetRequest()
        {
            var calendarAllSeasonPremieresGetRequest = new CalendarAllSeasonPremieresGetRequest();
            calendarAllSeasonPremieresGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarAllSeasonPremieresGetRequestHasCorrectRequestObjectType()
        {
            var calendarAllSeasonPremieresGetRequest = new CalendarAllSeasonPremieresGetRequest();
            calendarAllSeasonPremieresGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
