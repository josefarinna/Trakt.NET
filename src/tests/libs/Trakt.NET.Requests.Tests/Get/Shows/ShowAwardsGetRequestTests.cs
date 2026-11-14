#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests.Shows
{
    public sealed class ShowAwardsGetRequestTests
    {
        private const string ShowID = TestConstants.Shows.ShowSlug;
        private const string URIPath = $"shows/{ShowID}/awards";

        [Fact]
        public void TestShowAwardsGetRequestHasValidURIPath()
        {
            var request = new ShowAwardsGetRequest { Id = ShowID };

            request.BuildUri();
            request.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestShowAwardsGetRequestHasValidOAuthRequirement()
        {
            var request = new ShowAwardsGetRequest { Id = ShowID };
            request.OAuthRequirement.ShouldBe(TraktOAuthRequirement.NotRequired);
        }

        [Fact]
        public void TestShowAwardsGetRequestIsGetRequest()
        {
            var request = new ShowAwardsGetRequest { Id = ShowID };
            request.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestShowAwardsGetRequestHasCorrectRequestObjectType()
        {
            var request = new ShowAwardsGetRequest { Id = ShowID };
            request.RequestObjectType.ShouldBe(TraktRequestObjectType.Show);
        }

        [Fact]
        public void TestShowAwardsGetRequestValidate()
        {
            var request = new ShowAwardsGetRequest { Id = string.Empty };
            Action act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new ShowAwardsGetRequest { Id = "  " };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();

            request = new ShowAwardsGetRequest { Id = "id with spaces" };
            act = () => request.Validate();
            act.ShouldThrow<TraktRequestValidationException>();
        }
    }
}
