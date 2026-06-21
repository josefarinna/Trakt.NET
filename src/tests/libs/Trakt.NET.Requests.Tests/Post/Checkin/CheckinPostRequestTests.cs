#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Checkin
{
    public sealed class CheckinPostRequestTests
    {
        private const string URIPath = "checkin";

        [Fact]
        public void TestCheckinPostRequestHasValidURIPath()
        {
            var checkinPostRequest = new CheckinPostRequest
            {
                TraktCheckin = new TraktCheckin()
            };

            checkinPostRequest.BuildUri();
            checkinPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestCheckinPostRequestHasValidOAuthRequirement()
        {
            var checkinPostRequest = new CheckinPostRequest { TraktCheckin = default! };
            checkinPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestCheckinPostRequestIsPostRequest()
        {
            var checkinPostRequest = new CheckinPostRequest { TraktCheckin = default! };
            checkinPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestCheckinPostRequestHasCorrectRequestObjectType()
        {
            var checkinPostRequest = new CheckinPostRequest { TraktCheckin = default! };
            checkinPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestCheckinPostRequestValidate()
        {
            var checkinPostRequest = new CheckinPostRequest { TraktCheckin = default! };
            Action act = () => checkinPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
