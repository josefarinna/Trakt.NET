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
                ListId = "123"
            };

            userPersonalListUpdatePutRequest.BuildUri();
            userPersonalListUpdatePutRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListUpdatePutRequestHasValidOAuthRequirement()
        {
            var userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = default!, ListId = default! };
            userPersonalListUpdatePutRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPersonalListUpdatePutRequestIsPutRequest()
        {
            var userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = default!, ListId = default! };
            userPersonalListUpdatePutRequest.Method.ShouldBe(HttpMethod.Put);
        }

        [Fact]
        public void TestUserPersonalListUpdatePutRequestHasCorrectRequestObjectType()
        {
            var userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = default!, ListId = default! };
            userPersonalListUpdatePutRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserPersonalListUpdatePutRequestValidate()
        {
            var userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = string.Empty, ListId = default! };
            Action act = () => userPersonalListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = "  ", ListId = default! };
            act = () => userPersonalListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = "id with spaces", ListId = default! };
            act = () => userPersonalListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = default!, ListId = string.Empty };
            act = () => userPersonalListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = default!, ListId = "  " };
            act = () => userPersonalListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListUpdatePutRequest = new UserPersonalListUpdatePutRequest { Id = default!, ListId = "id with spaces" };
            act = () => userPersonalListUpdatePutRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
