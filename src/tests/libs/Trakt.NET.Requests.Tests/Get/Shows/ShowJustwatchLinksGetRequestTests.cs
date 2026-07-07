#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowJustwatchLinksGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string Country = "us";
        private const string URIPath = $"shows/{ShowID}/watchnow/justwatch_links/{Country}";

        [Fact]
        public void TestShowJustwatchLinksGetRequestHasValidURIPath()
        {
            var request = new ShowJustwatchLinksGetRequest
            {
                Id = ShowID,
                Country = Country
            };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowJustwatchLinksGetRequestHasValidOAuthRequirement()
        {
            var request = new ShowJustwatchLinksGetRequest { Id = ShowID, Country = Country };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowJustwatchLinksGetRequestIsGetRequest()
        {
            var request = new ShowJustwatchLinksGetRequest { Id = ShowID, Country = Country };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestShowJustwatchLinksGetRequestHasCorrectRequestObjectType()
        {
            var request = new ShowJustwatchLinksGetRequest { Id = ShowID, Country = Country };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowJustwatchLinksGetRequestValidate()
        {
            var request = new ShowJustwatchLinksGetRequest { Id = string.Empty, Country = Country };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new ShowJustwatchLinksGetRequest { Id = "  ", Country = Country };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new ShowJustwatchLinksGetRequest { Id = "id with spaces", Country = Country };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new ShowJustwatchLinksGetRequest { Id = ShowID, Country = string.Empty };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new ShowJustwatchLinksGetRequest { Id = ShowID, Country = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new ShowJustwatchLinksGetRequest { Id = ShowID, Country = "country with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
