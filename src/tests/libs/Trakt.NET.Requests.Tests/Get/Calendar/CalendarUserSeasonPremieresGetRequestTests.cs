#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Calendar
{
    public sealed class CalendarUserSeasonPremieresGetRequestTests
    {
        private const string URIPath = "calendars/my/shows/premieres/123";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestCalendarUserSeasonPremieresGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var calendarUserSeasonPremieresGetRequest = new CalendarUserSeasonPremieresGetRequest
            {
                StartDate = "123",
                ExtendedInfo = extendedInfo
            };

            calendarUserSeasonPremieresGetRequest.BuildUri();
            calendarUserSeasonPremieresGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCalendarUserSeasonPremieresGetRequestHasValidOAuthRequirement()
        {
            var calendarUserSeasonPremieresGetRequest = new CalendarUserSeasonPremieresGetRequest();
            calendarUserSeasonPremieresGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCalendarUserSeasonPremieresGetRequestIsGetRequest()
        {
            var calendarUserSeasonPremieresGetRequest = new CalendarUserSeasonPremieresGetRequest();
            calendarUserSeasonPremieresGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestCalendarUserSeasonPremieresGetRequestHasCorrectRequestObjectType()
        {
            var calendarUserSeasonPremieresGetRequest = new CalendarUserSeasonPremieresGetRequest();
            calendarUserSeasonPremieresGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
