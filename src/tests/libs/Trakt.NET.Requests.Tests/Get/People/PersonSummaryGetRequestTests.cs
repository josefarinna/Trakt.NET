#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.People
{
    public sealed class PersonSummaryGetRequestTests
    {
        private const string URIPath = "people/123";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestPersonSummaryGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var personSummaryGetRequest = new PersonSummaryGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo
            };

            personSummaryGetRequest.BuildUri();
            personSummaryGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestPersonSummaryGetRequestHasValidOAuthRequirement()
        {
            var personSummaryGetRequest = new PersonSummaryGetRequest { Id = default! };
            personSummaryGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestPersonSummaryGetRequestIsGetRequest()
        {
            var personSummaryGetRequest = new PersonSummaryGetRequest { Id = default! };
            personSummaryGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestPersonSummaryGetRequestHasCorrectRequestObjectType()
        {
            var personSummaryGetRequest = new PersonSummaryGetRequest { Id = default! };
            personSummaryGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Person);
        }

        [Fact]
        public void TestPersonSummaryGetRequestValidate()
        {
            var personSummaryGetRequest = new PersonSummaryGetRequest { Id = string.Empty };
            Action act = () => personSummaryGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            personSummaryGetRequest = new PersonSummaryGetRequest { Id = "  " };
            act = () => personSummaryGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            personSummaryGetRequest = new PersonSummaryGetRequest { Id = "id with spaces" };
            act = () => personSummaryGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
