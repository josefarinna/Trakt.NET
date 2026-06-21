#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.People
{
    public sealed class PersonShowCreditsGetRequestTests
    {
        private const string URIPath = "people/123/shows";

        [Theory]
        [InlineData(null, URIPath)]
        [InlineData(TraktExtendedInfo.None, URIPath)]
        [InlineData(TraktExtendedInfo.Full, $"{URIPath}?extended=full")]
        public void TestPersonShowCreditsGetRequestHasValidURIPath(TraktExtendedInfo? extendedInfo, string expectedURIPath)
        {
            var personShowCreditsGetRequest = new PersonShowCreditsGetRequest
            {
                Id = "123",
                ExtendedInfo = extendedInfo
            };

            personShowCreditsGetRequest.BuildUri();
            personShowCreditsGetRequest.RequestUri.ShouldBe(new Uri(expectedURIPath, UriKind.Relative));
        }

        [Fact]
        public void TestPersonShowCreditsGetRequestHasValidOAuthRequirement()
        {
            var personShowCreditsGetRequest = new PersonShowCreditsGetRequest { Id = default! };
            personShowCreditsGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestPersonShowCreditsGetRequestIsGetRequest()
        {
            var personShowCreditsGetRequest = new PersonShowCreditsGetRequest { Id = default! };
            personShowCreditsGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestPersonShowCreditsGetRequestHasCorrectRequestObjectType()
        {
            var personShowCreditsGetRequest = new PersonShowCreditsGetRequest { Id = default! };
            personShowCreditsGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Person);
        }

        [Fact]
        public void TestPersonShowCreditsGetRequestValidate()
        {
            var personShowCreditsGetRequest = new PersonShowCreditsGetRequest { Id = string.Empty };
            Action act = () => personShowCreditsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            personShowCreditsGetRequest = new PersonShowCreditsGetRequest { Id = "  " };
            act = () => personShowCreditsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            personShowCreditsGetRequest = new PersonShowCreditsGetRequest { Id = "id with spaces" };
            act = () => personShowCreditsGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
