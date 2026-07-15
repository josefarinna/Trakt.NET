#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserReportPostRequestTests
    {
        private const string URIPath = "users/123/report";

        [Fact]
        public void TestUserReportPostRequestHasValidURIPath()
        {
            var userReportPostRequest = new UserReportPostRequest
            {
                Id = "123",
                TraktReportPost = new TraktReportPost()
            };

            userReportPostRequest.BuildUri();
            userReportPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserReportPostRequestHasValidOAuthRequirement()
        {
            var userReportPostRequest = new UserReportPostRequest { Id = default!, TraktReportPost = default! };
            userReportPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserReportPostRequestIsPostRequest()
        {
            var userReportPostRequest = new UserReportPostRequest { Id = default!, TraktReportPost = default! };
            userReportPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserReportPostRequestHasCorrectRequestObjectType()
        {
            var userReportPostRequest = new UserReportPostRequest { Id = default!, TraktReportPost = default! };
            userReportPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.None);
        }

        [Fact]
        public void TestUserReportPostRequestValidate()
        {
            var userReportPostRequest = new UserReportPostRequest { Id = string.Empty, TraktReportPost = default! };
            Action act = () => userReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userReportPostRequest = new UserReportPostRequest { Id = "  ", TraktReportPost = default! };
            act = () => userReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userReportPostRequest = new UserReportPostRequest { Id = "id with spaces", TraktReportPost = default! };
            act = () => userReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userReportPostRequest = new UserReportPostRequest { Id = "id", TraktReportPost = default! };
            act = () => userReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userReportPostRequest = new UserReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost() };
            act = () => userReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            userReportPostRequest = new UserReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost { Reason = TraktReason.Other } };
            act = () => userReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
