#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserPersonalListAddPostRequestTests
    {
        private const string URIPath = "users/123/lists";

        [Fact]
        public void TestUserPersonalListAddPostRequestHasValidURIPath()
        {
            var userPersonalListAddPostRequest = new UserPersonalListAddPostRequest
            {
                Id = "123"
            };

            userPersonalListAddPostRequest.BuildUri();
            userPersonalListAddPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListAddPostRequestHasValidOAuthRequirement()
        {
            var userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = default! };
            userPersonalListAddPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPersonalListAddPostRequestIsPostRequest()
        {
            var userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = default! };
            userPersonalListAddPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserPersonalListAddPostRequestHasCorrectRequestObjectType()
        {
            var userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = default! };
            userPersonalListAddPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserPersonalListAddPostRequestValidate()
        {
            var userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = string.Empty };
            Action act = () => userPersonalListAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = "  " };
            act = () => userPersonalListAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListAddPostRequest = new UserPersonalListAddPostRequest { Id = "id with spaces" };
            act = () => userPersonalListAddPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
