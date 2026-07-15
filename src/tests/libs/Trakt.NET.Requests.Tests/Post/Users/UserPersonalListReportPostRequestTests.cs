#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.Users
{
    public sealed class UserPersonalListReportPostRequestTests
    {
        private const string URIPath = "users/sean/lists/123/report";

        [Fact]
        public void TestUserPersonalListReportPostRequestHasValidURIPath()
        {
            var userPersonalListReportPostRequest = new UserPersonalListReportPostRequest
            {
                Id = "sean",
                ListId = "123",
                TraktReportPost = new TraktReportPost()
            };

            userPersonalListReportPostRequest.BuildUri();
            userPersonalListReportPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestUserPersonalListReportPostRequestHasValidOAuthRequirement()
        {
            var userPersonalListReportPostRequest = new UserPersonalListReportPostRequest { Id = default!, ListId = default!, TraktReportPost = default! };
            userPersonalListReportPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestUserPersonalListReportPostRequestIsPostRequest()
        {
            var userPersonalListReportPostRequest = new UserPersonalListReportPostRequest { Id = default!, ListId = default!, TraktReportPost = default! };
            userPersonalListReportPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestUserPersonalListReportPostRequestHasCorrectRequestObjectType()
        {
            var userPersonalListReportPostRequest = new UserPersonalListReportPostRequest { Id = default!, ListId = default!, TraktReportPost = default! };
            userPersonalListReportPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.List);
        }

        [Fact]
        public void TestUserPersonalListReportPostRequestValidate()
        {
            var userPersonalListReportPostRequest = new UserPersonalListReportPostRequest { Id = string.Empty, ListId = "123", TraktReportPost = default! };
            Action act = () => userPersonalListReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListReportPostRequest = new UserPersonalListReportPostRequest { Id = "  ", ListId = "123", TraktReportPost = default! };
            act = () => userPersonalListReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListReportPostRequest = new UserPersonalListReportPostRequest { Id = "id with spaces", ListId = "123", TraktReportPost = default! };
            act = () => userPersonalListReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListReportPostRequest = new UserPersonalListReportPostRequest { Id = "sean", ListId = string.Empty, TraktReportPost = default! };
            act = () => userPersonalListReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListReportPostRequest = new UserPersonalListReportPostRequest { Id = "sean", ListId = "  ", TraktReportPost = default! };
            act = () => userPersonalListReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListReportPostRequest = new UserPersonalListReportPostRequest { Id = "sean", ListId = "list id with spaces", TraktReportPost = default! };
            act = () => userPersonalListReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListReportPostRequest = new UserPersonalListReportPostRequest { Id = "sean", ListId = "123", TraktReportPost = default! };
            act = () => userPersonalListReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            userPersonalListReportPostRequest = new UserPersonalListReportPostRequest { Id = "sean", ListId = "123", TraktReportPost = new TraktReportPost() };
            act = () => userPersonalListReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            userPersonalListReportPostRequest = new UserPersonalListReportPostRequest { Id = "sean", ListId = "123", TraktReportPost = new TraktReportPost { Reason = TraktReason.Other } };
            act = () => userPersonalListReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
