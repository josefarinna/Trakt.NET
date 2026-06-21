#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserPersonalListItemsReorderPostRequestTests
    {
        private const string URIPath = "users/123/lists/123/items/reorder";

        [Fact]
        public void TestUserPersonalListItemsReorderPostRequestHasValidURIPath()
        {
            var userPersonalListItemsReorderPostRequest = new UserPersonalListItemsReorderPostRequest
            {
                Id = "123",
                ListId = "123"
            };

            userPersonalListItemsReorderPostRequest.BuildUri();
            userPersonalListItemsReorderPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListItemsReorderPostRequestHasValidOAuthRequirement()
        {
            var userPersonalListItemsReorderPostRequest = new UserPersonalListItemsReorderPostRequest { Id = default!, ListId = default! };
            userPersonalListItemsReorderPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPersonalListItemsReorderPostRequestIsPostRequest()
        {
            var userPersonalListItemsReorderPostRequest = new UserPersonalListItemsReorderPostRequest { Id = default!, ListId = default! };
            userPersonalListItemsReorderPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserPersonalListItemsReorderPostRequestHasCorrectRequestObjectType()
        {
            var userPersonalListItemsReorderPostRequest = new UserPersonalListItemsReorderPostRequest { Id = default!, ListId = default! };
            userPersonalListItemsReorderPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserPersonalListItemsReorderPostRequestValidate()
        {
            var userPersonalListItemsReorderPostRequest = new UserPersonalListItemsReorderPostRequest { Id = string.Empty, ListId = default! };
            Action act = () => userPersonalListItemsReorderPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsReorderPostRequest = new UserPersonalListItemsReorderPostRequest { Id = "  ", ListId = default! };
            act = () => userPersonalListItemsReorderPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsReorderPostRequest = new UserPersonalListItemsReorderPostRequest { Id = "id with spaces", ListId = default! };
            act = () => userPersonalListItemsReorderPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsReorderPostRequest = new UserPersonalListItemsReorderPostRequest { Id = default!, ListId = string.Empty };
            act = () => userPersonalListItemsReorderPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsReorderPostRequest = new UserPersonalListItemsReorderPostRequest { Id = default!, ListId = "  " };
            act = () => userPersonalListItemsReorderPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsReorderPostRequest = new UserPersonalListItemsReorderPostRequest { Id = default!, ListId = "id with spaces" };
            act = () => userPersonalListItemsReorderPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
