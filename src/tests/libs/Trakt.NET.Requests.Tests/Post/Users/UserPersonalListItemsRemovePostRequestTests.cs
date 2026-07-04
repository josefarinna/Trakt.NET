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
                ListId = "123",
                TraktUserPersonalListItemsRemovePost = new TraktUserPersonalListItemsRemovePost()
            };

            userPersonalListItemsRemovePostRequest.BuildUri();
            userPersonalListItemsRemovePostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListItemsRemovePostRequestHasValidOAuthRequirement()
        {
            var userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = default!, ListId = default!, TraktUserPersonalListItemsRemovePost = default! };
            userPersonalListItemsRemovePostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPersonalListItemsRemovePostRequestIsPostRequest()
        {
            var userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = default!, ListId = default!, TraktUserPersonalListItemsRemovePost = default! };
            userPersonalListItemsRemovePostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserPersonalListItemsRemovePostRequestHasCorrectRequestObjectType()
        {
            var userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = default!, ListId = default!, TraktUserPersonalListItemsRemovePost = default! };
            userPersonalListItemsRemovePostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserPersonalListItemsRemovePostRequestValidate()
        {
            var userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = string.Empty, ListId = default!, TraktUserPersonalListItemsRemovePost = default! };
            Action act = () => userPersonalListItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = "  ", ListId = default!, TraktUserPersonalListItemsRemovePost = default! };
            act = () => userPersonalListItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = "id with spaces", ListId = default!, TraktUserPersonalListItemsRemovePost = default! };
            act = () => userPersonalListItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = "id", ListId = string.Empty, TraktUserPersonalListItemsRemovePost = default! };
            act = () => userPersonalListItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = "id", ListId = "  ", TraktUserPersonalListItemsRemovePost = default! };
            act = () => userPersonalListItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = "id", ListId = "id with spaces", TraktUserPersonalListItemsRemovePost = default! };
            act = () => userPersonalListItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = "id", ListId = "listid", TraktUserPersonalListItemsRemovePost = default! };
            act = () => userPersonalListItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListItemsRemovePostRequest = new UserPersonalListItemsRemovePostRequest { Id = "id", ListId = "listid", TraktUserPersonalListItemsRemovePost = new TraktUserPersonalListItemsRemovePost() };
            act = () => userPersonalListItemsRemovePostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
