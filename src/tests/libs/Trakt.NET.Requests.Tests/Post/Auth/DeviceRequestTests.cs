#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Auth
{
    public sealed class DeviceRequestTests
    {
        private const string URIPath = "oauth/device/code";

        [Fact]
        public void TestDeviceRequestHasValidURIPath()
        {
            var deviceRequest = new DeviceRequest
            {
                TraktDevicePost = new TraktDevicePost()
            };

            deviceRequest.BuildUri();
            deviceRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestDeviceRequestHasValidOAuthRequirement()
        {
            var deviceRequest = new DeviceRequest { TraktDevicePost = default! };
            deviceRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestDeviceRequestIsPostRequest()
        {
            var deviceRequest = new DeviceRequest { TraktDevicePost = default! };
            deviceRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestDeviceRequestHasCorrectRequestObjectType()
        {
            var deviceRequest = new DeviceRequest { TraktDevicePost = default! };
            deviceRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestDeviceRequestValidate()
        {
            var deviceRequest = new DeviceRequest { TraktDevicePost = default! };
            Action act = () => deviceRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}

