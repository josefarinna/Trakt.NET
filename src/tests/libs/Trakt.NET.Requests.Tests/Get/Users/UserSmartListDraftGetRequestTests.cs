#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Users
{
    public sealed class UserSmartListDraftGetRequestTests
    {
        private const string URIPath = "users/123/lists/456/smart-list-draft";

        [Fact]
        public void TestUserSmartListDraftGetRequestHasValidURIPath()
        {
            var userSmartListDraftGetRequest = new UserSmartListDraftGetRequest
            {
                Id = "123",
                ListId = "456"
            };

            userSmartListDraftGetRequest.BuildUri();
            userSmartListDraftGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserSmartListDraftGetRequestHasValidOAuthRequirement()
        {
            var userSmartListDraftGetRequest = new UserSmartListDraftGetRequest { Id = default!, ListId = default! };
            userSmartListDraftGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserSmartListDraftGetRequestIsGetRequest()
        {
            var userSmartListDraftGetRequest = new UserSmartListDraftGetRequest { Id = default!, ListId = default! };
            userSmartListDraftGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestUserSmartListDraftGetRequestHasCorrectRequestObjectType()
        {
            var userSmartListDraftGetRequest = new UserSmartListDraftGetRequest { Id = default!, ListId = default! };
            userSmartListDraftGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserSmartListDraftGetRequestValidate()
        {
            var userSmartListDraftGetRequest = new UserSmartListDraftGetRequest { Id = string.Empty, ListId = default! };
            Action act = () => userSmartListDraftGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListDraftGetRequest = new UserSmartListDraftGetRequest { Id = "  ", ListId = default! };
            act = () => userSmartListDraftGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListDraftGetRequest = new UserSmartListDraftGetRequest { Id = "id with spaces", ListId = default! };
            act = () => userSmartListDraftGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListDraftGetRequest = new UserSmartListDraftGetRequest { Id = "id", ListId = string.Empty };
            act = () => userSmartListDraftGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListDraftGetRequest = new UserSmartListDraftGetRequest { Id = "id", ListId = "  " };
            act = () => userSmartListDraftGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListDraftGetRequest = new UserSmartListDraftGetRequest { Id = "id", ListId = "id with spaces" };
            act = () => userSmartListDraftGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userSmartListDraftGetRequest = new UserSmartListDraftGetRequest { Id = "id", ListId = "listid" };
            act = () => userSmartListDraftGetRequest.Validate();
            act.ShouldNotThrow();
        }
    }
}
