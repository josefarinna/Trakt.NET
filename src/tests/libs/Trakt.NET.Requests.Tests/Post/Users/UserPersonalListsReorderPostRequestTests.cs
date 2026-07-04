#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserPersonalListsReorderPostRequestTests
    {
        private const string URIPath = "users/123/lists/reorder";

        [Fact]
        public void TestUserPersonalListsReorderPostRequestHasValidURIPath()
        {
            var userPersonalListsReorderPostRequest = new UserPersonalListsReorderPostRequest
            {
                Id = "123",
                TraktListItemsReorderPost = new TraktListItemsReorderPost()
            };

            userPersonalListsReorderPostRequest.BuildUri();
            userPersonalListsReorderPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListsReorderPostRequestHasValidOAuthRequirement()
        {
            var userPersonalListsReorderPostRequest = new UserPersonalListsReorderPostRequest { Id = default!, TraktListItemsReorderPost = default! };
            userPersonalListsReorderPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPersonalListsReorderPostRequestIsPostRequest()
        {
            var userPersonalListsReorderPostRequest = new UserPersonalListsReorderPostRequest { Id = default!, TraktListItemsReorderPost = default! };
            userPersonalListsReorderPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserPersonalListsReorderPostRequestHasCorrectRequestObjectType()
        {
            var userPersonalListsReorderPostRequest = new UserPersonalListsReorderPostRequest { Id = default!, TraktListItemsReorderPost = default! };
            userPersonalListsReorderPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserPersonalListsReorderPostRequestValidate()
        {
            var userPersonalListsReorderPostRequest = new UserPersonalListsReorderPostRequest { Id = string.Empty, TraktListItemsReorderPost = default! };
            Action act = () => userPersonalListsReorderPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListsReorderPostRequest = new UserPersonalListsReorderPostRequest { Id = "  ", TraktListItemsReorderPost = default! };
            act = () => userPersonalListsReorderPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListsReorderPostRequest = new UserPersonalListsReorderPostRequest { Id = "id with spaces", TraktListItemsReorderPost = default! };
            act = () => userPersonalListsReorderPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListsReorderPostRequest = new UserPersonalListsReorderPostRequest { Id = "id", TraktListItemsReorderPost = default! };
            act = () => userPersonalListsReorderPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListsReorderPostRequest = new UserPersonalListsReorderPostRequest { Id = "id", TraktListItemsReorderPost = new TraktListItemsReorderPost() };
            act = () => userPersonalListsReorderPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
