#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserSmartListDraftsGetRequestTests
    {
        private const string URIPath = "users/123/smart-list-drafts";

        [Fact]
        public void TestUserSmartListDraftsGetRequestHasValidURIPath()
        {
            var userSmartListDraftsGetRequest = new UserSmartListDraftsGetRequest
            {
                Id = "123"
            };

            userSmartListDraftsGetRequest.BuildUri();
            userSmartListDraftsGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSmartListDraftsGetRequestHasValidOAuthRequirement()
        {
            var userSmartListDraftsGetRequest = new UserSmartListDraftsGetRequest { Id = default! };
            userSmartListDraftsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserSmartListDraftsGetRequestIsGetRequest()
        {
            var userSmartListDraftsGetRequest = new UserSmartListDraftsGetRequest { Id = default! };
            userSmartListDraftsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserSmartListDraftsGetRequestHasCorrectRequestObjectType()
        {
            var userSmartListDraftsGetRequest = new UserSmartListDraftsGetRequest { Id = default! };
            userSmartListDraftsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserSmartListDraftsGetRequestValidate()
        {
            var userSmartListDraftsGetRequest = new UserSmartListDraftsGetRequest { Id = string.Empty };
            Action act = () => userSmartListDraftsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListDraftsGetRequest = new UserSmartListDraftsGetRequest { Id = "  " };
            act = () => userSmartListDraftsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListDraftsGetRequest = new UserSmartListDraftsGetRequest { Id = "id with spaces" };
            act = () => userSmartListDraftsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
