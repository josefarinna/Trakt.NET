#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.PostRequests.People
{
    public sealed class PersonRefreshPostRequestTests
    {
        private const string URIPath = "people/123/refresh";

        [Fact]
        public void TestPersonRefreshPostRequestHasValidURIPath()
        {
            var personRefreshPostRequest = new PersonRefreshPostRequest
            {
                Id = "123"
            };

            personRefreshPostRequest.BuildUri();
            personRefreshPostRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestPersonRefreshPostRequestHasValidOAuthRequirement()
        {
            var personRefreshPostRequest = new PersonRefreshPostRequest { Id = default! };
            personRefreshPostRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.Required);
        }

        [Fact]
        public void TestPersonRefreshPostRequestIsPostRequest()
        {
            var personRefreshPostRequest = new PersonRefreshPostRequest { Id = default! };
            personRefreshPostRequest.Method.ShouldBe(HttpMethod.Post);
        }

        [Fact]
        public void TestPersonRefreshPostRequestHasCorrectRequestObjectType()
        {
            var personRefreshPostRequest = new PersonRefreshPostRequest { Id = default! };
            personRefreshPostRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Person);
        }

        [Fact]
        public void TestPersonRefreshPostRequestValidate()
        {
            var personRefreshPostRequest = new PersonRefreshPostRequest { Id = string.Empty };
            Action act = () => personRefreshPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            personRefreshPostRequest = new PersonRefreshPostRequest { Id = "  " };
            act = () => personRefreshPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            personRefreshPostRequest = new PersonRefreshPostRequest { Id = "id with spaces" };
            act = () => personRefreshPostRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
