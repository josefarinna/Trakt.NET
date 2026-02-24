#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowAliasesGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/aliases";

        [Fact]
        public void TestShowAliasesGetRequestHasValidURIPath()
        {
            var showAliasesGetRequest = new ShowAliasesGetRequest { Id = ShowID };

            showAliasesGetRequest.BuildUri();
            showAliasesGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowAliasesGetRequestHasValidOAuthRequirement()
        {
            var showAliasesGetRequest = new ShowAliasesGetRequest { Id = ShowID };
            showAliasesGetRequest.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowAliasesGetRequestIsGetRequest()
        {
            var showAliasesGetRequest = new ShowAliasesGetRequest { Id = ShowID };
            showAliasesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestShowAliasesGetRequestHasCorrectRequestObjectType()
        {
            var showAliasesGetRequest = new ShowAliasesGetRequest { Id = ShowID };
            showAliasesGetRequest.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowAliasesGetRequestValidate()
        {
            var showAliasesGetRequest = new ShowAliasesGetRequest { Id = string.Empty };

            Action act = () => showAliasesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showAliasesGetRequest = new ShowAliasesGetRequest { Id = "  " };

            act = () => showAliasesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            showAliasesGetRequest = new ShowAliasesGetRequest { Id = "id with spaces" };

            act = () => showAliasesGetRequest.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
