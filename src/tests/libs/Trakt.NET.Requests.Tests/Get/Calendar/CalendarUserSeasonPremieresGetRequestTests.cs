#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarUserSeasonPremieresGetRequestTests
    {
        private const string URIPath = "calendars/my/shows/premieres";
        private const string StartDateURIValue = "2024-07-20";

        [Theory]
        [InlineData(null, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.None, $"{URIPath}/{StartDateURIValue}/7")]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}/{StartDateURIValue}/7?extended=full")]
        public void TestCalendarUserSeasonPremieresGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserSeasonPremieresGetRequest = new CalendarUserSeasonPremieresGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                ExtendedInfo = extendedInfo
            };

            calendarUserSeasonPremieresGetRequest.BuildUri();
            calendarUserSeasonPremieresGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUserSeasonPremieresGetRequestHasValidOAuthRequirement()
        {
            var calendarUserSeasonPremieresGetRequest = new CalendarUserSeasonPremieresGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserSeasonPremieresGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUserSeasonPremieresGetRequestIsGetRequest()
        {
            var calendarUserSeasonPremieresGetRequest = new CalendarUserSeasonPremieresGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserSeasonPremieresGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUserSeasonPremieresGetRequestHasCorrectRequestObjectType()
        {
            var calendarUserSeasonPremieresGetRequest = new CalendarUserSeasonPremieresGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
            };
            calendarUserSeasonPremieresGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    
        [Fact]
        public void TestCalendarUserSeasonPremieresGetRequestHasValidURIPathWithFilter()
        {
            var filter = new TraktFilter { Query = "game of thrones" };
            var calendarUserSeasonPremieresGetRequest = new CalendarUserSeasonPremieresGetRequest
            {
                StartDate = StartDateURIValue,
                Days = 7,
                Filter = filter
            };

            calendarUserSeasonPremieresGetRequest.BuildUri();
            calendarUserSeasonPremieresGetRequest.RequestUri.ShouldBe(new Uri(URIPath + "/" + StartDateURIValue + "/7?query=game of thrones", UriKind.Relative));
        }
    }
}
