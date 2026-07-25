#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserApproveFollowerPostRequestTests
    {
        private const string URIPath = "users/requests/123";

        [Fact]
        public void TestUserApproveFollowerPostRequestHasValidURIPath()
        {
            var userApproveFollowerPostRequest = new UserApproveFollowerPostRequest
            {
                Id = 123
            };

            userApproveFollowerPostRequest.BuildUri();
            userApproveFollowerPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserApproveFollowerPostRequestHasValidOAuthRequirement()
        {
            var userApproveFollowerPostRequest = new UserApproveFollowerPostRequest { Id = default! };
            userApproveFollowerPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserApproveFollowerPostRequestIsPostRequest()
        {
            var userApproveFollowerPostRequest = new UserApproveFollowerPostRequest { Id = default! };
            userApproveFollowerPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserApproveFollowerPostRequestHasCorrectRequestObjectType()
        {
            var userApproveFollowerPostRequest = new UserApproveFollowerPostRequest { Id = default! };
            userApproveFollowerPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.User);
        }

        [Fact]
        public void TestUserApproveFollowerPostRequestValidate()
        {
            var userApproveFollowerPostRequest = new UserApproveFollowerPostRequest { Id = 0 };
            Action act = () => userApproveFollowerPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
