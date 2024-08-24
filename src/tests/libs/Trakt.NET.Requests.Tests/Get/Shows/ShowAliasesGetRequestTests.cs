#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowAliasesGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowID;
        private const string URIPath = $"shows/{ShowID}/aliases";

        [Fact]
        public void TestShowAliasesGetRequestHasValidURIPath()
        {
            var showAliasesGetRequest = new ShowAliasesGetRequest { Id = ShowID };

            showAliasesGetRequest.BuildUri();
            showAliasesGetRequest.RequestUri.Should().Be(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowAliasesGetRequestHasValidOAuthRequirement()
        {
            var showAliasesGetRequest = new ShowAliasesGetRequest { Id = ShowID };
            showAliasesGetRequest.OAuthRequirement.Should().Be(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowAliasesGetRequestIsGetRequest()
        {
            var showAliasesGetRequest = new ShowAliasesGetRequest { Id = ShowID };
            showAliasesGetRequest.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void TestShowAliasesGetRequestHasCorrectRequestObjectType()
        {
            var showAliasesGetRequest = new ShowAliasesGetRequest { Id = ShowID };
            showAliasesGetRequest.RequestObjectType.Should().Be(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowAliasesGetRequestValidate()
        {
            var showAliasesGetRequest = new ShowAliasesGetRequest { Id = string.Empty };

            Action act = () => showAliasesGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showAliasesGetRequest = new ShowAliasesGetRequest { Id = "  " };

            act = () => showAliasesGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            showAliasesGetRequest = new ShowAliasesGetRequest { Id = "id with spaces" };

            act = () => showAliasesGetRequest.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
