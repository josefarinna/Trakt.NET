#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.SmartLists
{
    public sealed class SmartListGetRequestTests
    {
        private const string URIPath = "smart-lists/123";

        [Fact]
        public void TestSmartListGetRequestHasValidURIPath()
        {
            var smartListGetRequest = new SmartListGetRequest
            {
                Id = "123"
            };

            smartListGetRequest.BuildUri();
            smartListGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestSmartListGetRequestHasValidURIPathWithExtendedInfo()
        {
            var smartListGetRequest = new SmartListGetRequest
            {
                Id = "123",
                ExtendedInfo = TraktExtendedInfo.Full
            };

            smartListGetRequest.BuildUri();
            smartListGetRequest.RequestUri.ShouldBe(new Uri($"{URIPath}?extended=full", UriKind.Relative));
        }

        [Fact]
        public void TestSmartListGetRequestHasValidOAuthRequirement()
        {
            var smartListGetRequest = new SmartListGetRequest { Id = default! };
            smartListGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestSmartListGetRequestIsGetRequest()
        {
            var smartListGetRequest = new SmartListGetRequest { Id = default! };
            smartListGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestSmartListGetRequestHasCorrectRequestObjectType()
        {
            var smartListGetRequest = new SmartListGetRequest { Id = default! };
            smartListGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestSmartListGetRequestValidate()
        {
            var smartListGetRequest = new SmartListGetRequest { Id = string.Empty };
            Action act = () => smartListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            smartListGetRequest = new SmartListGetRequest { Id = "  " };
            act = () => smartListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            smartListGetRequest = new SmartListGetRequest { Id = "id with spaces" };
            act = () => smartListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
