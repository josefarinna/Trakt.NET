#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PutRequests.Users
{
    public sealed class UserPersonalListItemUpdatePutRequestTests
    {
        private const string URIPath = "users/123/lists/123/items/123";

        [Fact]
        public void TestUserPersonalListItemUpdatePutRequestHasValidURIPath()
        {
            var userPersonalListItemUpdatePutRequest = new UserPersonalListItemUpdatePutRequest
            {
                ListItemId = 123U,
                Id = "123",
                ListId = "123"
            };

            userPersonalListItemUpdatePutRequest.BuildUri();
            userPersonalListItemUpdatePutRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListItemUpdatePutRequestHasValidOAuthRequirement()
        {
            var userPersonalListItemUpdatePutRequest = new UserPersonalListItemUpdatePutRequest { Id = default!, ListId = default! };
            userPersonalListItemUpdatePutRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPersonalListItemUpdatePutRequestIsPutRequest()
        {
            var userPersonalListItemUpdatePutRequest = new UserPersonalListItemUpdatePutRequest { Id = default!, ListId = default! };
            userPersonalListItemUpdatePutRequest.Method.ShouldBe(HttpMethod.Put);
        }

        [Fact]
        public void TestUserPersonalListItemUpdatePutRequestHasCorrectRequestObjectType()
        {
            var userPersonalListItemUpdatePutRequest = new UserPersonalListItemUpdatePutRequest { Id = default!, ListId = default! };
            userPersonalListItemUpdatePutRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserPersonalListItemUpdatePutRequestValidate()
        {
            var userPersonalListItemUpdatePutRequest = new UserPersonalListItemUpdatePutRequest { Id = string.Empty, ListId = default! };
            Action act = () => userPersonalListItemUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemUpdatePutRequest = new UserPersonalListItemUpdatePutRequest { Id = "  ", ListId = default! };
            act = () => userPersonalListItemUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemUpdatePutRequest = new UserPersonalListItemUpdatePutRequest { Id = "id with spaces", ListId = default! };
            act = () => userPersonalListItemUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemUpdatePutRequest = new UserPersonalListItemUpdatePutRequest { Id = default!, ListId = string.Empty };
            act = () => userPersonalListItemUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemUpdatePutRequest = new UserPersonalListItemUpdatePutRequest { Id = default!, ListId = "  " };
            act = () => userPersonalListItemUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemUpdatePutRequest = new UserPersonalListItemUpdatePutRequest { Id = default!, ListId = "id with spaces" };
            act = () => userPersonalListItemUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
