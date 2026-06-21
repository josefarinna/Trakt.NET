#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Checkin
{
    public sealed class CheckinDeleteRequestTests
    {
        private const string URIPath = "checkin";

        [Fact]
        public void TestCheckinDeleteRequestHasValidURIPath()
        {
            var checkinDeleteRequest = new CheckinDeleteRequest();

            checkinDeleteRequest.BuildUri();
            checkinDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCheckinDeleteRequestHasValidOAuthRequirement()
        {
            var checkinDeleteRequest = new CheckinDeleteRequest();
            checkinDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCheckinDeleteRequestIsDeleteRequest()
        {
            var checkinDeleteRequest = new CheckinDeleteRequest();
            checkinDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestCheckinDeleteRequestHasCorrectRequestObjectType()
        {
            var checkinDeleteRequest = new CheckinDeleteRequest();
            checkinDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }
    }
}
