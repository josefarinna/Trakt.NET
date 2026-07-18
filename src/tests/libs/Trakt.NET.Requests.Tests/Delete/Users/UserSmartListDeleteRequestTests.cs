#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.DeleteRequests.Users
{
    public sealed class UserSmartListDeleteRequestTests
    {
        private const string URIPath = "users/123/smart-lists/456";

        [Fact]
        public void TestUserSmartListDeleteRequestHasValidURIPath()
        {
            var userSmartListDeleteRequest = new UserSmartListDeleteRequest
            {
                Id = "123",
                ListId = "456"
            };

            userSmartListDeleteRequest.BuildUri();
            userSmartListDeleteRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSmartListDeleteRequestHasValidOAuthRequirement()
        {
            var userSmartListDeleteRequest = new UserSmartListDeleteRequest { Id = default!, ListId = default! };
            userSmartListDeleteRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserSmartListDeleteRequestIsDeleteRequest()
        {
            var userSmartListDeleteRequest = new UserSmartListDeleteRequest { Id = default!, ListId = default! };
            userSmartListDeleteRequest.Method.ShouldBe(HttpMethod.Delete);
        }

        [Fact]
        public void TestUserSmartListDeleteRequestHasCorrectRequestObjectType()
        {
            var userSmartListDeleteRequest = new UserSmartListDeleteRequest { Id = default!, ListId = default! };
            userSmartListDeleteRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserSmartListDeleteRequestValidate()
        {
            var userSmartListDeleteRequest = new UserSmartListDeleteRequest { Id = string.Empty, ListId = default! };
            Action act = () => userSmartListDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListDeleteRequest = new UserSmartListDeleteRequest { Id = "  ", ListId = default! };
            act = () => userSmartListDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListDeleteRequest = new UserSmartListDeleteRequest { Id = "id with spaces", ListId = default! };
            act = () => userSmartListDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListDeleteRequest = new UserSmartListDeleteRequest { Id = "id", ListId = string.Empty };
            act = () => userSmartListDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListDeleteRequest = new UserSmartListDeleteRequest { Id = "id", ListId = "  " };
            act = () => userSmartListDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListDeleteRequest = new UserSmartListDeleteRequest { Id = "id", ListId = "id with spaces" };
            act = () => userSmartListDeleteRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListDeleteRequest = new UserSmartListDeleteRequest { Id = "id", ListId = "listid" };
            act = () => userSmartListDeleteRequest.Validate();
            act.ShouldNotThrow();
        }
    }
}
