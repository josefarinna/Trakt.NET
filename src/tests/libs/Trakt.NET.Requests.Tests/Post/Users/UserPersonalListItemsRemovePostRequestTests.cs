#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserPersonalListItemsRemovePostRequestTests
    {
        private const string URIPath = "users/123/lists/123/items/remove";

        [Fact]
        public void TestUserPersonalListItemsRemovePostRequestHasValidURIPath()
        {
            var userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest
            {
                Id = "123",
                ListId = "123"
            };

            userPersonalListItemsRemovePostRequest.BuildUri();
            userPersonalListItemsRemovePostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListItemsRemovePostRequestHasValidOAuthRequirement()
        {
            var userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = default!, ListId = default! };
            userPersonalListItemsRemovePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPersonalListItemsRemovePostRequestIsPostRequest()
        {
            var userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = default!, ListId = default! };
            userPersonalListItemsRemovePostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserPersonalListItemsRemovePostRequestHasCorrectRequestObjectType()
        {
            var userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = default!, ListId = default! };
            userPersonalListItemsRemovePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserPersonalListItemsRemovePostRequestValidate()
        {
            var userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = string.Empty, ListId = default! };
            Action act = () => userPersonalListItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = "  ", ListId = default! };
            act = () => userPersonalListItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = "id with spaces", ListId = default! };
            act = () => userPersonalListItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = default!, ListId = string.Empty };
            act = () => userPersonalListItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = default!, ListId = "  " };
            act = () => userPersonalListItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = default!, ListId = "id with spaces" };
            act = () => userPersonalListItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
