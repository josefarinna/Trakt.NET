#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.People
{
    public sealed class PersonReportPostRequestTests
    {
        private const string URIPath = "people/123/report";

        [Fact]
        public void TestPersonReportPostRequestHasValidURIPath()
        {
            var personReportPostRequest = new PersonReportPostRequest
            {
                Id = "123",
                TraktReportPost = new TraktReportPost()
            };

            personReportPostRequest.BuildUri();
            personReportPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestPersonReportPostRequestHasValidOAuthRequirement()
        {
            var personReportPostRequest = new PersonReportPostRequest { Id = default!, TraktReportPost = default! };
            personReportPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestPersonReportPostRequestIsPostRequest()
        {
            var personReportPostRequest = new PersonReportPostRequest { Id = default!, TraktReportPost = default! };
            personReportPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestPersonReportPostRequestHasCorrectRequestObjectType()
        {
            var personReportPostRequest = new PersonReportPostRequest { Id = default!, TraktReportPost = default! };
            personReportPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Person);
        }

        [Fact]
        public void TestPersonReportPostRequestValidate()
        {
            var personReportPostRequest = new PersonReportPostRequest { Id = string.Empty, TraktReportPost = default! };
            Action act = () => personReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            personReportPostRequest = new PersonReportPostRequest { Id = "  ", TraktReportPost = default! };
            act = () => personReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            personReportPostRequest = new PersonReportPostRequest { Id = "id with spaces", TraktReportPost = default! };
            act = () => personReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            personReportPostRequest = new PersonReportPostRequest { Id = "id", TraktReportPost = default! };
            act = () => personReportPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            personReportPostRequest = new PersonReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost() };
            act = () => personReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();

            personReportPostRequest = new PersonReportPostRequest { Id = "id", TraktReportPost = new TraktReportPost { Reason = TraktReason.Other } };
            act = () => personReportPostRequest.Validate();
            act.ShouldThrow<TraktPostValidationException>();
        }
    }
}
