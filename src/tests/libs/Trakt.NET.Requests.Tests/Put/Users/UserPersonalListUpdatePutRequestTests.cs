#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PutRequests.Users
{
    public sealed class UserPersonalListUpdatePutRequestTests
    {
        private const string URIPath = "users/123/lists/123";

        [Fact]
        public void TestUserPersonalListUpdatePutRequestHasValidURIPath()
        {
            var userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest
            {
                Id = "123",
                ListId = "123",
                TraktUserPersonalListPost = new TraktUserPersonalListPost()
            };

            userPersonalListUpdatePutRequest.BuildUri();
            userPersonalListUpdatePutRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListUpdatePutRequestHasValidOAuthRequirement()
        {
            var userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = default!, ListId = default!, TraktUserPersonalListPost = default! };
            userPersonalListUpdatePutRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPersonalListUpdatePutRequestIsPutRequest()
        {
            var userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = default!, ListId = default!, TraktUserPersonalListPost = default! };
            userPersonalListUpdatePutRequest.Method.ShouldBe(HttpMethod.Put);
        }

        [Fact]
        public void TestUserPersonalListUpdatePutRequestHasCorrectRequestObjectType()
        {
            var userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = default!, ListId = default!, TraktUserPersonalListPost = default! };
            userPersonalListUpdatePutRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserPersonalListUpdatePutRequestValidate()
        {
            var userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = string.Empty, ListId = default!, TraktUserPersonalListPost = default! };
            Action act = () => userPersonalListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = "  ", ListId = default!, TraktUserPersonalListPost = default! };
            act = () => userPersonalListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = "id with spaces", ListId = default!, TraktUserPersonalListPost = default! };
            act = () => userPersonalListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = "id", ListId = string.Empty, TraktUserPersonalListPost = default! };
            act = () => userPersonalListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = "id", ListId = "  ", TraktUserPersonalListPost = default! };
            act = () => userPersonalListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = "id", ListId = "id with spaces", TraktUserPersonalListPost = default! };
            act = () => userPersonalListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = "id", ListId = "listid", TraktUserPersonalListPost = default! };
            act = () => userPersonalListUpdatePutRequest.Validate();
            act.ShouldNotThrow();

            userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = "id", ListId = "listid", TraktUserPersonalListPost = new TraktUserPersonalListPost() };
            act = () => userPersonalListUpdatePutRequest.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
