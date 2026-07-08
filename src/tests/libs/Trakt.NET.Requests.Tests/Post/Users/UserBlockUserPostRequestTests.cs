#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserBlockUserPostRequestTests
    {
        private const string URIPath = "users/123/block";

        [Fact]
        public void TestUserBlockUserPostRequestHasValidURIPath()
        {
            var userBlockUserPostRequest = new UserBlockUserPostRequest
            {
                Id = "123"
            };

            userBlockUserPostRequest.BuildUri();
            userBlockUserPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserBlockUserPostRequestHasValidOAuthRequirement()
        {
            var userBlockUserPostRequest = new UserBlockUserPostRequest { Id = default! };
            userBlockUserPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserBlockUserPostRequestIsPostRequest()
        {
            var userBlockUserPostRequest = new UserBlockUserPostRequest { Id = default! };
            userBlockUserPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserBlockUserPostRequestHasCorrectRequestObjectType()
        {
            var userBlockUserPostRequest = new UserBlockUserPostRequest { Id = default! };
            userBlockUserPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserBlockUserPostRequestValidate()
        {
            var userBlockUserPostRequest = new UserBlockUserPostRequest { Id = string.Empty };
            Action act = () => userBlockUserPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userBlockUserPostRequest = new UserBlockUserPostRequest { Id = "  " };
            act = () => userBlockUserPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userBlockUserPostRequest = new UserBlockUserPostRequest { Id = "id with spaces" };
            act = () => userBlockUserPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
