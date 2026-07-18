#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserSmartListGetRequestTests
    {
        private const string URIPath = "users/123/smart-lists/456";

        [Fact]
        public void TestUserSmartListGetRequestHasValidURIPath()
        {
            var userSmartListGetRequest = new UserSmartListGetRequest
            {
                Id = "123",
                ListId = "456"
            };

            userSmartListGetRequest.BuildUri();
            userSmartListGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSmartListGetRequestHasValidOAuthRequirement()
        {
            var userSmartListGetRequest = new UserSmartListGetRequest { Id = default!, ListId = default! };
            userSmartListGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserSmartListGetRequestIsGetRequest()
        {
            var userSmartListGetRequest = new UserSmartListGetRequest { Id = default!, ListId = default! };
            userSmartListGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserSmartListGetRequestHasCorrectRequestObjectType()
        {
            var userSmartListGetRequest = new UserSmartListGetRequest { Id = default!, ListId = default! };
            userSmartListGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserSmartListGetRequestValidate()
        {
            var userSmartListGetRequest = new UserSmartListGetRequest { Id = string.Empty, ListId = default! };
            Action act = () => userSmartListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListGetRequest = new UserSmartListGetRequest { Id = "  ", ListId = default! };
            act = () => userSmartListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListGetRequest = new UserSmartListGetRequest { Id = "id with spaces", ListId = default! };
            act = () => userSmartListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListGetRequest = new UserSmartListGetRequest { Id = "id", ListId = string.Empty };
            act = () => userSmartListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListGetRequest = new UserSmartListGetRequest { Id = "id", ListId = "  " };
            act = () => userSmartListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListGetRequest = new UserSmartListGetRequest { Id = "id", ListId = "id with spaces" };
            act = () => userSmartListGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
