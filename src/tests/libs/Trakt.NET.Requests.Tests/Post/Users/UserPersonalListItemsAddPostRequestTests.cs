#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserPersonalListItemsAddPostRequestTests
    {
        private const string URIPath = "users/123/lists/123/items";

        [Fact]
        public void TestUserPersonalListItemsAddPostRequestHasValidURIPath()
        {
            var userPersonalListItemsAddPostRequest = new UserPersonalListItemsAddPostRequest
            {
                Id = "123",
                ListId = "123"
            };

            userPersonalListItemsAddPostRequest.BuildUri();
            userPersonalListItemsAddPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListItemsAddPostRequestHasValidOAuthRequirement()
        {
            var userPersonalListItemsAddPostRequest = new UserPersonalListItemsAddPostRequest { Id = default!, ListId = default! };
            userPersonalListItemsAddPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPersonalListItemsAddPostRequestIsPostRequest()
        {
            var userPersonalListItemsAddPostRequest = new UserPersonalListItemsAddPostRequest { Id = default!, ListId = default! };
            userPersonalListItemsAddPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserPersonalListItemsAddPostRequestHasCorrectRequestObjectType()
        {
            var userPersonalListItemsAddPostRequest = new UserPersonalListItemsAddPostRequest { Id = default!, ListId = default! };
            userPersonalListItemsAddPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserPersonalListItemsAddPostRequestValidate()
        {
            var userPersonalListItemsAddPostRequest = new UserPersonalListItemsAddPostRequest { Id = string.Empty, ListId = default! };
            Action act = () => userPersonalListItemsAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsAddPostRequest = new UserPersonalListItemsAddPostRequest { Id = "  ", ListId = default! };
            act = () => userPersonalListItemsAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsAddPostRequest = new UserPersonalListItemsAddPostRequest { Id = "id with spaces", ListId = default! };
            act = () => userPersonalListItemsAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsAddPostRequest = new UserPersonalListItemsAddPostRequest { Id = "id", ListId = string.Empty };
            act = () => userPersonalListItemsAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsAddPostRequest = new UserPersonalListItemsAddPostRequest { Id = "id", ListId = "  " };
            act = () => userPersonalListItemsAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsAddPostRequest = new UserPersonalListItemsAddPostRequest { Id = "id", ListId = "id with spaces" };
            act = () => userPersonalListItemsAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
