#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserSmartListsGetRequestTests
    {
        private const string URIPath = "users/123/smart-lists";

        [Fact]
        public void TestUserSmartListsGetRequestHasValidURIPath()
        {
            var userSmartListsGetRequest = new UserSmartListsGetRequest
            {
                Id = "123"
            };

            userSmartListsGetRequest.BuildUri();
            userSmartListsGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSmartListsGetRequestHasValidOAuthRequirement()
        {
            var userSmartListsGetRequest = new UserSmartListsGetRequest { Id = default! };
            userSmartListsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void TestUserSmartListsGetRequestIsGetRequest()
        {
            var userSmartListsGetRequest = new UserSmartListsGetRequest { Id = default! };
            userSmartListsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserSmartListsGetRequestHasCorrectRequestObjectType()
        {
            var userSmartListsGetRequest = new UserSmartListsGetRequest { Id = default! };
            userSmartListsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserSmartListsGetRequestValidate()
        {
            var userSmartListsGetRequest = new UserSmartListsGetRequest { Id = string.Empty };
            Action act = () => userSmartListsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListsGetRequest = new UserSmartListsGetRequest { Id = "  " };
            act = () => userSmartListsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListsGetRequest = new UserSmartListsGetRequest { Id = "id with spaces" };
            act = () => userSmartListsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
